-- ===== PERSONS =====
CREATE TABLE dbo.Persons (
    PersonId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    Vorname NVARCHAR(200) NOT NULL,
    Geburtsdatum DATETIME2 NOT NULL
    --NameGross NVARCHAR(200) NULL
);


-- ===== ANSCHRIFTEN =====
CREATE TABLE dbo.Anschriften (
    AnschriftId INT IDENTITY(1,1) PRIMARY KEY,
    Ort NVARCHAR(200) NOT NULL,
    Strasse NVARCHAR(200) NOT NULL,
    Hausnummer NVARCHAR(20) NOT NULL,
    Postleitzahl NVARCHAR(20) NOT NULL,
    PersonId INT NOT NULL,

    CONSTRAINT FK_Anschrift_Person
        FOREIGN KEY (PersonId)
        REFERENCES dbo.Persons(PersonId)
        ON DELETE NO ACTION	-- default setting
);


-- ===== TELEFONVERBINDUNGEN =====
CREATE TABLE dbo.Telefonverbindungen (
    TelefonverbindungId INT IDENTITY(1,1) PRIMARY KEY,
    Nummer NVARCHAR(50) NOT NULL,
    PersonId INT NOT NULL,

    CONSTRAINT FK_Telefon_Person
        FOREIGN KEY (PersonId)
        REFERENCES dbo.Persons(PersonId)
        ON DELETE NO ACTION	-- default setting
);


CREATE INDEX IX_Anschriften_PersonId 
ON dbo.Anschriften(PersonId);

CREATE INDEX IX_Telefonverbindungen_PersonId 
ON dbo.Telefonverbindungen(PersonId);


/*
CREATE INDEX IX_Anschriften_Ort_PersonId
ON Anschriften(Ort, PersonID);


ALTER TABLE dbo.Telefonverbindungen
ADD CONSTRAINT CK_Telefon_Format
CHECK (Nummer LIKE '0%' OR Nummer LIKE '+%');

ALTER TABLE dbo.Telefonverbindungen
ADD CONSTRAINT UQ_Telefon_Nummer UNIQUE (Nummer);

Nummer NVARCHAR(30) NOT NULL

*/