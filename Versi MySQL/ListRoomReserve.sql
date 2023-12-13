Use DBPeminjaman;

DELIMITER //
-- Dapatkan semua ruangan yang digunakan waktu, tanggal, dan status tertentu.
CREATE PROCEDURE ListRoom(IN p_TimeStart TIME, IN p_TimeEnd TIME, IN p_UseDate DATE, IN p_Status VARCHAR(10))
BEGIN
    SELECT DISTINCT F.Ruangan_Name
    FROM Form F
    JOIN Form_Time FT ON F.FormID = FT.FormID
    WHERE F.Form_Date = p_UseDate
    AND FT.TimeStart >= p_TimeStart
    AND FT.TimeEnd <= p_TimeEnd
    AND F.Form_Status = p_Status;
END //

DELIMITER ;