Use DbPeminjaman;

-- Untuk melihat semua form be nama user yang mengajukan.
SELECT Form.*, User.User_Name
FROM Form
JOIN User ON Form.UserID = User.UserID;

-- Melihat semua form serta nama dan lokasi Room.
SELECT Form.*, Room.Room_Name, Room.Room_Location
FROM Form
JOIN Room ON Form.RoomID = Room.RoomID;

-- Melihat semua form serta time slot untuk setiap form. 
SELECT Form.*, Form_Time.TimeStart, Form_Time.TimeEnd
FROM Form
JOIN Form_Time ON Form.FormID = Form_Time.FormID;

-- Melihat semua peralatan yang sedang dipesan. 
SELECT 
    E.EquipmentID, E.Equipment_Name, E.Equipment_Location,
    SUM(FE.Equipment_Quantity) AS Total_Quantity
FROM Equipment AS E
JOIN Form_Equipment AS FE ON E.EquipmentID = FE.EquipmentID
GROUP BY E.EquipmentID;

-- Melihat semua form dengan nama Room, lokasi Room, dan nama user yang memesan.
SELECT F.FormID, F.RoomID, R.Room_Name, R.Room_Location, F.UserID, U.User_Name, 
       F.Form_Date, F.Form_Description, F.User_Associate, F.Room_Approval, F.Rejection_Reason, F.Form_Status
FROM Form F
JOIN `User` AS U ON F.UserID = U.UserID
JOIN Room AS R ON F.RoomID = R.RoomID;

-- Bagi security untuk mengecek peralatan dengan jumlah yang dibutuhkan pada tanggal, waktu, dan lokasi tertentu.
SELECT F.Form_Date,  FT.TimeStart, FT.TimeEnd, E.Equipment_Name, 
	   FE.Equipment_Quantity, R.Room_Name, R.Room_Location
FROM Equipment AS E
JOIN Form_Equipment AS FE ON E.EquipmentID = FE.EquipmentID
JOIN Form AS F ON FE.FormID = F.FormID
JOIN Room AS R ON F.RoomID = R.RoomID
JOIN Form_Time AS FT ON F.FormID = FT.FormID
ORDER BY F.Form_Date, FT.TimeStart
