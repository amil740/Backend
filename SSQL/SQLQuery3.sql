CREATE DATABASE Task
USE Task
CREATE TABLE Artists
(
ID INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL,
Age INT
)

CREATE TABLE Albums
(
ID INT PRIMARY KEY IDENTITY,
AlbumName NVARCHAR(50),
ArtistID INT FOREIGN KEY REFERENCES Artists(ID)
)

CREATE TABLE Musics (
    ID INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(50),
    AlbumID INT,
    ArtistID INT,
    FOREIGN KEY (AlbumID) REFERENCES Albums(ID),
    FOREIGN KEY (ArtistID) REFERENCES Artists(ID),
    TotalSecond INT 
);


INSERT INTO Artists ([Name], Age)
VALUES
('The Weeknd', 34),
('Ed Sheeran', 33),
('Taylor Swift', 35);


INSERT INTO Albums (AlbumName, ArtistID)
VALUES
('After Hours', 1),       -- The Weeknd
('Divide', 2),            -- Ed Sheeran
('1989 (Taylor’s Version)', 3); -- Taylor Swift


INSERT INTO Musics ([Name], AlbumID, ArtistID, TotalSecond)
VALUES
('Blinding Lights', 1, 1, 200),
('Save Your Tears', 1, 1, 215),
('Shape of You', 2, 2, 234),
('Perfect', 2, 2, 263),
('Blank Space', 3, 3, 231),
('Style', 3, 3, 240);


CREATE VIEW vw_MusicInfo AS
SELECT 
    m.Name AS MusicName,
    m.TotalSecond,
    ar.Name AS ArtistName,
    al.AlbumName
FROM Musics m
JOIN Artists ar ON m.ArtistID = ar.ID
JOIN Albums al ON m.AlbumID = al.ID;

CREATE VIEW vw_AlbumMusicCount AS
SELECT 
    a.AlbumName,
    COUNT(m.ID) AS MusicCount
FROM Albums a
LEFT JOIN Musics m ON a.ID = m.AlbumID
GROUP BY a.AlbumName;

INSERT INTO Musics ([Name], AlbumID, ArtistID, TotalSecond, ListenerCount)
VALUES
('Blinding Lights', 1, 1, 200, 1200000),
('Save Your Tears', 1, 1, 215, 9500000),
('Shape of You', 2, 2, 234, 32000000),
('Perfect', 2, 2, 263, 28000000),
('Blank Space', 3, 3, 231, 27000000),
('Style', 3, 3, 240, 19000000);

CREATE PROCEDURE GetMusicsByListenerCount
    @ListenerCount BIGINT
AS
BEGIN
    SELECT 
        m.Name AS MusicName,
        a.AlbumName,
        ar.Name AS ArtistName,
        m.ListenerCount
    FROM Musics m
    JOIN Albums a ON m.AlbumID = a.ID
    JOIN Artists ar ON m.ArtistID = ar.ID
    WHERE m.ListenerCount > @ListenerCount
    ORDER BY m.ListenerCount DESC;
END;

SELECT 
m.ListenerCount
al.AlbumName

EXEC GetMusicsByListenerCount 10000000

SELECT * FROM vw_AlbumMusicCount;

SELECT * FROM vw_MusicInfo
