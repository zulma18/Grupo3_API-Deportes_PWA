-- database
CREATE DATABASE SportsTeamManagementDB
GO
USE SportsTeamManagementDB
GO

-- tabla Sport_Discipline
CREATE TABLE Sport_Discipline (
    Id INT PRIMARY KEY IDENTITY(1,1),
    DisciplineName VARCHAR(50) NOT NULL,
    Description VARCHAR(255) NOT NULL
);
GO

-- tabla Team
CREATE TABLE Team (
    Id INT PRIMARY KEY IDENTITY(1,1),
    TeamName VARCHAR(75) NOT NULL,
    City VARCHAR(100) NOT NULL,
    Coach VARCHAR(100) NOT NULL,
    DisciplineID INT NOT NULL,
    CONSTRAINT FK_Team_Discipline FOREIGN KEY (DisciplineID) REFERENCES Sport_Discipline(Id)
);
GO

-- tabla Player
CREATE TABLE Player (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(75) NOT NULL,
    LastName VARCHAR(75) NOT NULL,
    Age INT NOT NULL,
    TeamID INT NOT NULL,
    CONSTRAINT FK_Player_Team FOREIGN KEY (TeamID) REFERENCES Team(Id)
);
GO




-- PROCEDIMIENTOS ALMACENADOS

-- ========= Player ==============--
-- procedimiento para insertar
CREATE PROCEDURE spPlayer_Insert
    @FirstName VARCHAR(75),
    @LastName VARCHAR(75),
    @Age INT,
    @TeamID INT
AS
BEGIN
    INSERT INTO Player (FirstName,LastName, Age, TeamID)
    VALUES (@FirstName,@LastName, @Age, @TeamID);
END
GO

-- procedimiento para actualizar
CREATE PROCEDURE spPlayer_Update
    @Id INT,
    @FirstName VARCHAR(75),
    @LastName VARCHAR(75),
    @Age INT,
    @TeamID INT
AS
BEGIN
    UPDATE Player
    SET FirstName = @FirstName, LastName =@LastName, Age = @Age, TeamID = @TeamID
    WHERE Id = @Id;
END
GO

-- procedimiento para obtener por Id
CREATE PROCEDURE spPlayer_GetById
    @Id INT
AS
BEGIN
    SELECT A.Id, FirstName,LastName,Age,TeamID, TeamName
    FROM Player AS A
	INNER JOIN Team AS B
	ON A.TeamID=B.Id
    WHERE A.Id = @Id;
END
GO

-- proceso para obtener todos los jugadores
CREATE PROCEDURE spPlayer_GetAll
AS
BEGIN
    SELECT A.Id, FirstName,LastName,Age,TeamID,TeamName
    FROM Player AS A
	INNER JOIN Team AS B
	ON A.TeamID = B.Id
END
GO

-- procedimeinto para eliminar
CREATE PROCEDURE spPlayer_Delete
    @Id INT
AS
BEGIN
    DELETE FROM Player
    WHERE Id = @Id;
END
GO


-- =========== Team ============--
-- procedimeiento para insetar
CREATE PROCEDURE spTeam_Insert
    @TeamName VARCHAR(75),
    @City VARCHAR(100),
    @Coach VARCHAR(100),
    @DisciplineID INT
AS
BEGIN
    INSERT INTO Team (TeamName, City, Coach, DisciplineID)
    VALUES (@TeamName, @City, @Coach, @DisciplineID);
END;
GO

-- procedimiento para actualizar
CREATE PROCEDURE spTeam_Update
    @Id INT,
    @TeamName VARCHAR(75),
    @City VARCHAR(100),
    @Coach VARCHAR(100),
    @DisciplineID INT
AS
BEGIN
    UPDATE Team
    SET TeamName = @TeamName, City = @City, Coach = @Coach, DisciplineID = @DisciplineID
    WHERE Id = @Id;
END;
GO

-- procediemiento para obetener por Id
CREATE PROCEDURE spTeam_GetById
    @Id INT
AS
BEGIN
    SELECT A.Id,TeamName,City,Coach,DisciplineName
    FROM Team AS A
	INNER JOIN Sport_Discipline AS B
	ON A.DisciplineID = B.Id
    WHERE A.Id = @Id;
END;
GO

-- procedimiento para obtener todos los equipos
CREATE PROCEDURE spTeam_GetAll
AS
BEGIN
    SELECT A.Id, TeamName, City, Coach, DisciplineID, DisciplineName
    FROM Team AS A
	INNER JOIN Sport_Discipline AS B
	ON A.DisciplineID = B.Id
END
GO

-- procedimiento para eliminar
CREATE PROCEDURE spTeam_Delete
    @Id INT
AS
BEGIN
    DELETE FROM Team
    WHERE Id = @Id;
END;
GO

-- ========= Sport Dicipline ==========--
-- proceso para insertar
CREATE PROCEDURE spSportDiscipline_Insert
    @DisciplineName NVARCHAR(50),
    @Description NVARCHAR(255)
AS
BEGIN
    INSERT INTO Sport_Discipline (DisciplineName, Description)
    VALUES (@DisciplineName, @Description);
END;
GO

-- procedimiento para actualizar
CREATE PROCEDURE spSportDiscipline_Update
    @Id INT,
    @DisciplineName NVARCHAR(50),
    @Description NVARCHAR(255)
AS
BEGIN
    UPDATE Sport_Discipline
    SET DisciplineName = @DisciplineName, Description = @Description
    WHERE Id = @Id;
END
GO

-- procedimiento para obtener por Id
CREATE PROCEDURE spSportDiscipline_GetById
    @Id INT
AS
BEGIN
    SELECT Id,DisciplineName,Description
    FROM Sport_Discipline
    WHERE Id = @Id;
END
GO

-- procedimiento para obtener todas las diciplinas
CREATE PROCEDURE spSportDiscipline_GetAll
AS
BEGIN
    SELECT Id,DisciplineName,Description
    FROM Sport_Discipline;
END
GO

-- procedimiento para eliminar
CREATE PROCEDURE spSportDiscipline_Delete
    @Id INT
AS
BEGIN
    DELETE FROM Sport_Discipline
    WHERE Id = @Id;
END
GO