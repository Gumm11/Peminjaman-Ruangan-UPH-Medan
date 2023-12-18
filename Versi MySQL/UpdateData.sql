USE DbPeminjaman;

-- User ingin ganti password.
UPDATE `User`
SET User_Password = 'new_password'
WHERE User_Email = '03082220020@student.uph.edu';

-- Tipe kelas diganti. 
UPDATE Room
SET Room_Type = 'Discussion Class'
WHERE RoomID = 5;

-- Room ditolak oleh admin.
UPDATE Form
SET Room_Approval = 2,
	Rejection_Reason = 'Room tidak tersedia karena renovasi.'
WHERE FormID = 1;

-- Suatu peralatan rusak, sehingga jumlah yang tersedia kurang 1. 
UPDATE Equipment
SET Equipment_Quantity = Equipment_Quantity - 1
WHERE EquipmentID = 5;

-- Suatu pemesanan Room diganti time slot yang dipesan. 
UPDATE Form_Time
SET TimeStart = '12:00:00', TimeEnd = '13:00:00'
WHERE FormID = 2 AND TimeStart = '14:00:00' AND TimeEnd = '15:00:00';

-- Suatu pemesanan Room mengganti jumlah dari suatu peralatan yang dibutuhkan.
UPDATE Form_Equipment
SET Equipment_Quantity = 2
WHERE FormID = 3 AND EquipmentID = 4;