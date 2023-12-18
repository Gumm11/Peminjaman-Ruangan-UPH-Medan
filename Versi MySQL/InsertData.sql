USE DbPeminjaman;
INSERT INTO `User` (User_Name, User_Email, User_Password, User_Role)
VALUES
  ('Richardo Johan Tanujaya', '03082220020@student.uph.edu', 'pw1', 'Security'),
  ('Jovan Torio', '03082220026@student.uph.edu', 'pw2', 'Staff'),
  ('Miguel Ferdinand Binsar Siahaan', '03082220029@student.uph.edu', 'pw3', 'User'),
  ('Vovella', '03082220006@student.uph.edu', 'pw4', 'User'),
  ('Joshua Austin Widjaja', '03082220023@student.uph.edu', 'pw5', 'Staff');
  
INSERT INTO Room (Room_Name, Room_Location, Room_Capacity, Room_Type)
VALUES
  (101, 'AryaDuta', 50, 'Computer Lab'),
  (102, 'AryaDuta', 45, 'Discussion Class'),
  (103, 'AryaDuta', 45, 'Discussion Class'),
  (104, 'AryaDuta', 45, 'Discussion Class'),
  (105, 'AryaDuta', 40, 'Discussion Class'),
  (106, 'AryaDuta', 75, 'Computer Lab'),
  (107, 'AryaDuta', 40, 'Standard Class/Dance Room'),
  (108, 'AryaDuta', 40, 'Standard Class/Dance Room'),
  (109, 'AryaDuta', 40, 'Standard Class'),
  (110, 'AryaDuta', 35, 'Standard Class'),
  (111, 'AryaDuta', 35, 'Standard Class'),
  (501, 'Lippo', 70, 'Harvard Style Class (Round Table)'),
  (502, 'Lippo', 65, 'Harvard Style Class (Round Table)'),
  (503, 'Lippo', 35, 'Computer Lab'),
  (504, 'Lippo', 40, 'Mockup Courtroom'),
  (601, 'Lippo', 90, 'Harvard Style Class (Straight Table)'),
  (602, 'Lippo', 90, 'Harvard Style Class (Straight Table)'),
  (603, 'Lippo', 40, 'Discussion Class'),
  (604, 'Lippo', 40, 'Discussion Class'),
  (605, 'Lippo', 40, 'Discussion Class'),
  (606, 'Lippo', 40, 'Discussion Class'),
  (607, 'Lippo', 40, 'Discussion Class'),
  (608, 'Lippo', 40, 'Discussion Class'),
  (609, 'Lippo', 40, 'Discussion Class'),
  (610, 'Lippo', 40, 'Discussion Class'),
  (701, 'Lippo', 60, 'Harvard Style Class (Straight Table)'),
  (702, 'Lippo', 70, 'Harvard Style Class (Straight Table)'),
  (703, 'Lippo', 60, 'Harvard Style Class (Straight Table)'),
  (704, 'Lippo', 60, 'Harvard Style Class (Straight Table)');
  
INSERT INTO Equipment (Equipment_Name, Equipment_Quantity, Equipment_Location)
VALUES
  ('Laptop', 20, 'AryaDuta'),
  ('Projector', 5, 'AryaDuta'),
  ('Whiteboard', 10, 'AryaDuta'),
  ('Desktop Computer', 15, 'Lippo'),
  ('Printer', 8, 'Lippo'),
  ('Scanner', 5, 'Lippo');
  
INSERT INTO Form (UserID, RoomID, Form_Date, Form_Description, User_Associate)
VALUES
(1, 1, '2023-12-17', 'Meeting with professors', 'BEM'),
(2, 5, '2023-12-18', 'Group study session', 'Math Club'),
(3, 17, '2023-12-19', 'Presentation rehearsal', 'Computer Science Department'),
(4, 15, '2023-12-20', 'Staff meeting', 'Admin Office'),
(5, 7, '2023-12-21', 'Workshop on literature', 'English Department'),
(2, 12, '2023-12-22', 'Project discussion', 'IT Club'),
(3, 6, '2023-12-23', 'Research presentation', 'Science Department'),
(4, 11, '2023-12-24', 'Team building event', 'Human Resources'),
(5, 15, '2023-12-25', 'Book club meeting', 'Library');

INSERT INTO Form_Time (FormID, TimeStart, TimeEnd)
VALUES
(1, '09:00:00', '10:00:00'),
(1, '10:00:00', '11:00:00'),
(2, '14:00:00', '15:00:00'),
(2, '15:00:00', '16:00:00'),
(3, '13:00:00', '14:00:00'),
(4, '14:00:00', '15:00:00'),
(5, '16:30:00', '17:30:00'),
(6, '11:00:00', '12:00:00'),
(7, '09:30:00', '11:00:00'),
(8, '13:30:00', '16:00:00'),
(9, '10:00:00', '12:30:00');

INSERT INTO Form_Equipment (FormID, EquipmentID, Equipment_Quantity)
VALUES
(1, 1, 5),
(1, 2, 1),
(2, 3, 2),
(3, 4, 3),
(3, 5, 1),
(4, 6, 2),
(5, 1, 3),
(5, 2, 1),
(5, 3, 2),
(6, 4, 2),
(6, 5, 1),
(7, 1, 4),
(8, 2, 2),
(8, 3, 1),
(9, 6, 3);