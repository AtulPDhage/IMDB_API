use Assignment;

Create table Actors(
 Id INT IDENTITY(1,1) PRIMARY KEY,
 Name VARCHAR(255),
 Bio VARCHAR(255),
 DOB DATETIME,
 Gender VARCHAR(255)
 );

 
Create table Producers(
 Id INT IDENTITY(1,1) PRIMARY KEY,
 Name VARCHAR(255),
 Bio VARCHAR(255),
 DOB DATETIME,
 Gender VARCHAR(255)
 );

Create table Genres(
 Id INT IDENTITY(1,1) PRIMARY KEY,
 Name VARCHAR(255)
 );

 Create table Movies(
 Id INT IDENTITY(1,1) PRIMARY KEY,
 Name VARCHAR(255),
 YearOfRelease INT NULL,
 Plot VARCHAR(255),
 ProducerId INT NULL,
 Poster VARCHAR(255)
 );

 CREATE TABLE Reviews(
 Id INT IDENTITY(1,1) PRIMARY KEY,
 Message VARCHAR(255),
 MovieId INT NULL
 );

CREATE TABLE Actors_Movies
  (
	 Id INT IDENTITY(1,1) PRIMARY KEY ,
	 MovieId INT ,
	 ActorId INT ,
  );

CREATE TABLE Genres_Movies
  (
	 Id INT IDENTITY(1,1) PRIMARY KEY ,
	 MovieId INT ,
	 GenreId INT ,
  );

ALTER TABLE Actors_Movies
ADD CONSTRAINT FK_Actors_Movies_Actors FOREIGN KEY (ActorId)
REFERENCES Actors(Id) ON DELETE CASCADE;

ALTER TABLE Actors_Movies
ADD CONSTRAINT FK_Actors_Movies_Movies FOREIGN KEY (MovieId)
REFERENCES Movies(Id) ON DELETE CASCADE;

ALTER TABLE Genres_Movies
ADD CONSTRAINT FK_Genres_Movies_Genres FOREIGN KEY (GenreId)
REFERENCES Genres(Id) ON DELETE CASCADE;

ALTER TABLE Genres_Movies
ADD CONSTRAINT FK_Genres_Movies_Movies FOREIGN KEY (MovieId)
REFERENCES Movies(Id) ON DELETE CASCADE;

CREATE PROCEDURE usp_AddMovie
    @Name VARCHAR(255),
    @YearOfRelease INT,
    @Plot VARCHAR(255),
	@ProducerId INT,
	@Poster VARCHAR(255),
    @ActorIds VARCHAR(255),
    @GenreIds VARCHAR(255)
AS
BEGIN
    INSERT INTO Movies (Name, YearOfRelease, Plot,ProducerId,Poster)
    VALUES (@Name, @YearOfRelease, @Plot,@ProducerId,@Poster);

    DECLARE @MovieId INT = SCOPE_IDENTITY();

    INSERT INTO Actors_Movies(MovieId, ActorId)
    SELECT @MovieId, CAST([value] AS INT)
    FROM STRING_SPLIT(@ActorIds, ',');

    INSERT INTO Genres_Movies(MovieId, GenreId)
    SELECT @MovieId, CAST([value] AS INT)
    FROM STRING_SPLIT(@GenreIds, ',');
END

CREATE PROCEDURE usp_UpdateMovie
	@MovieId INT,
    @Name VARCHAR(255),
    @YearOfRelease INT,
    @Plot VARCHAR(255),
	@ProducerId INT,
	@Poster VARCHAR(255),
    @ActorIds VARCHAR(255),
    @GenreIds VARCHAR(255)
AS
BEGIN
    UPDATE Movies
    SET Name = @Name,
        YearOfRelease = @YearOfRelease,
        Plot = @Plot,
        ProducerId = @ProducerId,
        Poster = @Poster
    WHERE Id = @MovieId;

    DELETE FROM Actors_Movies WHERE  MovieId = @MovieId;
    DELETE FROM Genres_Movies WHERE MovieId = @MovieId;

    INSERT INTO Actors_Movies (MovieId, ActorId)
    SELECT @MovieId, value FROM STRING_SPLIT(@ActorIds, ',');

    INSERT INTO Genres_Movies (MovieId, GenreId)
    SELECT @MovieId, value FROM STRING_SPLIT(@GenreIds, ',');
END


 Select * from Actors
 Select * from Movies
 Select * from Genres
 


