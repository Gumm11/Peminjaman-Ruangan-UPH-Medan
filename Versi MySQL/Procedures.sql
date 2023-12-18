DELIMITER //
-- frmLogin, frmOTP, frmAdminPassword------------------------------------------------------------------------------------------------

-- Mencari jika email yang dimasukkan adalah milik staff. 
CREATE PROCEDURE GetStaffEmail(IN p_Staff_Email VARCHAR(255))
BEGIN
    SELECT Staff_Email, Staff_Role
    FROM Staff
    WHERE Staff_Email = p_Staff_Email;
END //

-- Mencari password dan peran Staff. 
CREATE PROCEDURE GetStaffPasswordAndRole(IN p_Staff_Email VARCHAR(255))
BEGIN
    SELECT Staff_Password, Staff_Role
    FROM Staff
    WHERE Staff_Email = p_Staff_Email;
END //

-- frmMenu------------------------------------------------------------------------------------------------
-- Mendapatkan informasi mengenai ruangan tertentu. 
CREATE PROCEDURE GetRuanganDetails(IN p_Ruangan_Name VARCHAR(255)) -- digunakan frmAdminMenu 
BEGIN
    SELECT Ruangan_Capacity, Ruangan_Location, Ruangan_Type
    FROM Ruangan
    WHERE Ruangan_Name = p_Ruangan_Name;
END //

-- Mencari semua ruangan yang tersedia untuk tanggal dan waktu tertentu. 
CREATE PROCEDURE GetAvailRoomFromDateTime( -- frmAdminMenu
    IN p_SelectedDate DATE,
    IN p_StartTime TIME,
    IN p_EndTime TIME,
    OUT p_Ruangan_Name VARCHAR(255)
)
BEGIN
    SELECT DISTINCT F.Ruangan_Name
    INTO p_Ruangan_Name
    FROM Form F
    JOIN Form_Time FT ON F.FormID = FT.FormID
    WHERE F.Form_Date = p_SelectedDate
        AND FT.TimeStart >= p_StartTime
        AND FT.TimeEnd <= p_EndTime
        AND F.Room_Approval IN (0, 1)
        AND F.Form_Status = 'active';
END //

-- Mencari semua form milik User yang telah dikonfirmasi (tolak/setuju) untuk notifikasi. 
CREATE PROCEDURE GetUserApprovedForms(
    IN p_Sender_Email VARCHAR(255),
    OUT p_FormID INT,
    OUT p_Ruangan_Name VARCHAR(255),
    OUT p_Form_Date DATE,
    OUT p_TimeStart TIME,
    OUT p_TimeEnd TIME,
    OUT p_Room_Approval INT
)
BEGIN
    SELECT f.FormID, f.Ruangan_Name, f.Form_Date, ft.TimeStart, ft.TimeEnd, f.Room_Approval
    INTO p_FormID, p_Ruangan_Name, p_Form_Date, p_TimeStart, p_TimeEnd, p_Room_Approval
    FROM Form f
    JOIN Form_Time ft ON f.FormID = ft.FormID
    WHERE f.User_Email = p_Sender_Email
        AND f.Form_Status = 'active'
        AND (f.Room_Approval = 1 OR f.Room_Approval = 2)
    ORDER BY f.Form_Date DESC, ft.TimeStart DESC;
END //

-- frmReserve------------------------------------------------------------------------------------------------
-- Mengambil tabel equipment.
CREATE PROCEDURE GetAllEquipment()
BEGIN
    SELECT *
    FROM Equipment;
END //

-- Memasukkan data ke dalam tabel Form, dan mendapatkan ID yang tergenerate agar dapat digunakan untuk Insert
-- ke dalam tabel Form_Equipment dan Form_Time. 
CREATE PROCEDURE InsertFormData(
    IN p_RuanganName VARCHAR(255),
    IN p_FormDate DATE,
    IN p_UserEmail VARCHAR(255),
    IN p_FormDescription VARCHAR(255),
    IN p_UserAssociate VARCHAR(255),
    OUT p_NewFormID INT
)
BEGIN
    INSERT INTO Form (Ruangan_Name, Form_Date, User_Email, Form_Description, User_Associate, Rejection_Reason)
    VALUES (p_RuanganName, p_FormDate, p_UserEmail, p_FormDescription, p_UserAssociate, NULL);

    SET p_NewFormID = LAST_INSERT_ID();
END //

-- Memasukkan data berupa waktu yang telah dipilih User dan mengasosiasikannya dengan formID yang telah dibuat. 
CREATE PROCEDURE InsertFormTime(
    IN p_FormID INT,
    IN p_StartTime TIME,
    IN p_EndTime TIME
)
BEGIN
    INSERT INTO Form_Time (FormID, TimeStart, TimeEnd)
    VALUES (p_FormID, p_StartTime, p_EndTime);
END //

-- Memasukkan data berupa peralatan dan jumlahnya 
-- yang telah dipilih User dan mengasosiasikannya dengan formID yang telah dibuat. 
CREATE PROCEDURE InsertFormEquipment(
    IN p_FormID INT,
    IN p_EquipmentID INT,
    IN p_EquipmentQuantity INT
)
BEGIN
    INSERT INTO Form_Equipment (FormID, EquipmentID, Equipment_Quantity)
    VALUES (p_FormID, p_EquipmentID, p_EquipmentQuantity);
END //

-- Menghitung jika terdapat ruangan yang direserve untuk tanggal tertentu yang pending/sudah disetujui.
CREATE PROCEDURE CountForms(
    IN p_SelectedDate DATE,
    OUT p_FormCount INT
)
BEGIN
    SELECT COUNT(*) AS FormCount
    INTO p_FormCount
    FROM Form
    WHERE Form_Date = p_SelectedDate
        AND Form_Status = 'active'
        AND Room_Approval IN (0, 1);
END //

-- Mengambil semua time slot yang sudah direserve untuk ruangan dan tanggal tertentu. 
CREATE PROCEDURE GetDistinctFormTimes(
    IN p_SelectedDate DATE,
    IN p_RuanganName VARCHAR(255)
)
BEGIN
    SELECT DISTINCT ft.TimeStart, ft.TimeEnd
    FROM Form_Time ft
    JOIN Form f ON ft.FormID = f.FormID
    WHERE f.Form_Date = p_SelectedDate
        AND f.Room_Approval IN (0, 1)
        AND f.Form_Status = 'active'
        AND f.Ruangan_Name = p_RuanganName;
END //

-- Mengambil jumlah total untuk peralatan tertentu. 
CREATE PROCEDURE GetEquipmentQuantity(
    IN p_EquipmentID INT,
    OUT p_Equipment_Quantity INT
)
BEGIN
    SELECT Equipment_Quantity
    INTO p_Equipment_Quantity
    FROM Equipment
    WHERE EquipmentID = p_EquipmentID;
END //

-- Mengambil jumlah total yang telah direserve semua user untuk 1 peralatan pada tanggal dan waktu tertentu. 
CREATE PROCEDURE GetTotalQuantityUsed(
    IN p_FormDate DATE,
    IN p_StartTime TIME,
    IN p_EndTime TIME,
    IN p_EquipmentID INT,
    OUT p_TotalQuantityUsed INT
)
BEGIN
    SELECT SUM(FE.Equipment_Quantity) AS TotalQuantityUsed
    INTO p_TotalQuantityUsed
    FROM Form AS F
    JOIN Form_Equipment AS FE ON F.FormID = FE.FormID
    JOIN Form_Time AS FT ON F.FormID = FT.FormID
    WHERE
        F.Form_Date = p_FormDate
        AND FT.TimeStart = p_StartTime
        AND FT.TimeEnd = p_EndTime
        AND FE.EquipmentID = p_EquipmentID
        AND F.Form_Status = 'active'
        AND F.Room_Approval IN (0, 1);
END //

-- Mencari jika ada 1 pun form yang menggunakan sebuah ruangan pada tanggal dan waktu tertentu. 
CREATE PROCEDURE CountFormsByRoomAndTime(
    IN p_RoomName VARCHAR(255),
    IN p_SelectedDate DATE,
    IN p_StartTime TIME,
    IN p_EndTime TIME,
    OUT p_FormCount INT
)
BEGIN
    SELECT COUNT(*) AS FormCount
    INTO p_FormCount
    FROM Form f
    JOIN Form_Time ft ON f.FormID = ft.FormID
    WHERE
        f.Ruangan_Name = p_RoomName
        AND f.Form_Date = p_SelectedDate
        AND f.Form_Status = 'active'
        AND f.Room_Approval IN (0, 1)
        AND ft.TimeStart = p_StartTime
        AND ft.TimeEnd = p_EndTime;
END //

-- frmReservedDetail------------------------------------------------------------------------------------------------

-- Mencari semua time slot yang telah direserve sebuah form. 
CREATE PROCEDURE GetFormTime( -- digunakan frmMyReserve, frmPendingForm, dan frmSecurity
    IN p_FormID INT,
    OUT p_TimeStart TIME,
    OUT p_TimeEnd TIME
)
BEGIN
    SELECT TimeStart, TimeEnd
    INTO p_TimeStart, p_TimeEnd
    FROM Form_Time
    WHERE FormID = p_FormID;
END //

-- Select data dari sebuah form. 
CREATE PROCEDURE GetFormData(
    IN p_FormID INT
)
BEGIN
    SELECT *
    FROM Form
    WHERE FormID = p_FormID;
END //

-- Mencari semua peralatan dengan jumlahnya yang direserve sebuah form, 
-- dan gabung dengan nama dan lokasi peralatan tsb. 
CREATE PROCEDURE GetFormEquipment(
    IN p_FormID INT
)
BEGIN
    SELECT fe.EquipmentID, fe.Equipment_Quantity, e.Equipment_Name, e.Equipment_Location
    FROM Form_Equipment fe
    JOIN Equipment e ON fe.EquipmentID = e.EquipmentID
    WHERE fe.FormID = p_FormID;
END //

-- frmMyReserve------------------------------------------------------------------------------------------------

-- Menghitung berapa form aktif yang dimiliki seorang user. 
CREATE PROCEDURE CountDistinctFormsByUser( -- digunakan frmPendingform
    IN p_UserEmail VARCHAR(255),
    OUT p_FormCount INT
)
BEGIN
    SELECT COUNT(DISTINCT f.FormID) AS FormCount
    INTO p_FormCount
    FROM Form f
    JOIN Form_Time t ON f.FormID = t.FormID
    WHERE f.Form_Status = 'active'
        AND f.User_Email = p_UserEmail;
END //

-- Kurang tau untuk apa
CREATE PROCEDURE GetDistinctFormsByUser( -- digunakan frmPendingForm
    IN p_UserEmail VARCHAR(255),
    IN p_Offset INT,
    OUT p_FormID INT,
    OUT p_Ruangan_Name VARCHAR(255),
    OUT p_Form_Date DATE,
    OUT p_Room_Approval INT
)
BEGIN
    SELECT DISTINCT f.FormID, f.Ruangan_Name, f.Form_Date, f.Room_Approval
    INTO p_FormID, p_Ruangan_Name, p_Form_Date, p_Room_Approval
    FROM Form f
    WHERE f.Form_Status = 'active'
        AND f.User_Email = p_UserEmail
    ORDER BY f.Form_Date
    OFFSET p_Offset ROWS FETCH NEXT 1 ROWS ONLY;
END //

-- Mengubah Form_Status dari sebuah form. 
CREATE PROCEDURE UpdateFormStatus( -- digunakan PanelAll
    IN p_FormId INT,
    IN p_NewStatus VARCHAR(255)
)
BEGIN
    UPDATE Form
    SET Form_Status = p_NewStatus
    WHERE FormID = p_FormId;
END //

-- frmAllForm------------------------------------------------------------------------------------------------

-- frmReject & frmReject2------------------------------------------------------------------------------------------------

-- Mengupdate Room_Approval dari sebuah form (0 = pending/belum ditanggapi, 1 = diterima, 2 = ditolak)
CREATE PROCEDURE UpdateFormRoomApproval(
    IN p_FormID INT,
    IN p_RoomApproval INT
)
BEGIN
    UPDATE Form
    SET Room_Approval = p_RoomApproval
    WHERE FormID = p_FormID;
END //

-- Mengupdate Rejection_Reason dari sebuah form setelah Room_Approval ditolak.
CREATE PROCEDURE UpdateFormRejectionReason(
    IN p_FormID INT,
    IN p_RejectionReason VARCHAR(255)
)
BEGIN
    UPDATE Form
    SET Rejection_Reason = p_RejectionReason
    WHERE FormID = p_FormID;
END //

-- frmSecurity------------------------------------------------------------------------------------------------
-- Menggunakan GetFormTime from frmReservedDetail

