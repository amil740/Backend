CREATE DATABASE Hospital;
GO
USE Hospital
CREATE TABLE Patients
(
    PatientID INT IDENTITY PRIMARY KEY,
    FirstName NVARCHAR(20),
    LastName NVARCHAR(25),
    BirthDate DATE NOT NULL CHECK (BirthDate <= GETDATE()),
    Email NVARCHAR(50) UNIQUE
);
CREATE TABLE Departments
(
DepartmentID INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR (40) UNIQUE
)
CREATE TABLE Doctors
(
DoctorID INT IDENTITY PRIMARY KEY,
FirstName NVARCHAR(20),
LastName NVARCHAR(25),
Experience INT CHECK (Experience>=0)
)
ALTER TABLE Doctors
ADD DepartmentID INT


ALTER TABLE Doctors
ADD FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID);

CREATE TABLE Appointments
(
AppointmentID INT IDENTITY PRIMARY KEY,
PatientID INT FOREIGN KEY REFERENCES Patients(PatientID),
DoctorID INT FOREIGN KEY REFERENCES Doctors(DoctorID),
AppointmentDate DATE CHECK (AppointmentDate <= GETDATE())
)

SELECT * FROM Doctors d
JOIN Departments dp
ON d.DepartmentID = dp.DepartmentID

SELECT * FROM Patients p
JOIN Appointments a
ON p.PatientID=a.PatientID

CREATE PROCEDURE GetPatientsAppointment
@PatientID INT
AS
BEGIN
    SELECT 
        a.AppointmentID,
        a.AppointmentDate,
        d.FirstName AS DoctorName,
        FROM Appointments a
    JOIN Doctors d
        ON d.DoctorID = a.DoctorID
    WHERE a.PatientID = @PatientID;
END
CREATE PROCEDURE GetDoctorsAppointmentes
    @DoctorID INT
AS
BEGIN
    SELECT a.AppointmentID, a.PatientID, a.AppointmentDate, d.FirstName
    FROM Doctors d
    JOIN Appointments a
        ON a.DoctorID = d.DoctorID
    WHERE d.DoctorID = @DoctorID 
      AND CAST(a.AppointmentDate AS DATE) = CAST(GETDATE() AS DATE);
END


EXEC GetDoctorsAppointmentes @DoctorID = 2;

CREATE TABLE Medicine
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(100)
)

ALTER TABLE Appointments
ADD MedicineName NVARCHAR(100)

ALTER TABLE Appointments
ADD CONSTRAINT FK_Appointments_Medicine
FOREIGN KEY (MedicineName) REFERENCES Medicine([Name]);

SELECT p.FirstName,p.LastName,a.MedicineName FROM Patients p
JOIN Appointments a
ON p.PatientID=a.PatientID

SELECT * FROM Doctors d
JOIN Appointments a
ON d.DoctorID=a.DoctorID
