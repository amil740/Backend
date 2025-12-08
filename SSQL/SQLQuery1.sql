
CREATE DATABASE imdb;
GO

USE imdb;
GO
CREATE TABLE Directors (
    DirectorID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    BirthDate DATE,
    Nationality NVARCHAR(50)
);
CREATE TABLE Actors (
    ActorID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    BirthDate DATE
);
CREATE TABLE Genres (
    GenreID INT IDENTITY(1,1) PRIMARY KEY,
    GenreName NVARCHAR(100) NOT NULL UNIQUE
);
CREATE TABLE Movies (
    MovieID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    ReleaseYear INT,
    Duration INT,
    DirectorID INT FOREIGN KEY REFERENCES Directors(DirectorID),
    GenreID INT FOREIGN KEY REFERENCES Genres(GenreID),
    Rating DECIMAL(3,1) CHECK (Rating BETWEEN 0 AND 10)
);
CREATE TABLE MovieActors (
    MovieID INT FOREIGN KEY REFERENCES Movies(MovieID),
    ActorID INT FOREIGN KEY REFERENCES Actors(ActorID),
    PRIMARY KEY (MovieID, ActorID)
);
INSERT INTO Directors (FullName, BirthDate, Nationality)
VALUES ('Christopher Nolan', '1970-07-30', 'British-American');
INSERT INTO Genres (GenreName)
VALUES ('Action');
INSERT INTO Movies (Title, ReleaseYear, Duration, DirectorID, GenreID, Rating)
VALUES ('The Dark Knight', 2008, 152, 1, 1, 9.0);
INSERT INTO Actors (FullName, BirthDate)
VALUES ('Christian Bale', '1974-01-30'),
       ('Heath Ledger', '1979-04-04'),
       ('Aaron Eckhart', '1968-03-12'),
       ('Michael Caine', '1933-03-14'),
       ('Gary Oldman', '1958-03-21');
INSERT INTO MovieActors (MovieID, ActorID)
SELECT 
    m.Title,
    m.Rating,
    g.GenreName,
    d.FullName AS DirectorName,
    a.FullName AS ActorName
FROM Movies m
JOIN Genres g ON m.GenreID = g.GenreID
JOIN Directors d ON m.DirectorID = d.DirectorID
JOIN MovieActors ma ON m.MovieID = ma.MovieID
JOIN Actors a ON ma.ActorID = a.ActorID
WHERE m.Rating > 6;
SELECT 
    m.Title,
    m.Rating,
    m.Duration,
    g.GenreName
FROM Movies m
JOIN Genres g ON m.GenreID = g.GenreID
WHERE LEN(m.Title) > 10
  AND RIGHT(m.Title, 1) = 't';
