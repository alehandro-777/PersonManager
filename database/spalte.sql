
-- Erstellen Sie einen Befehl, um die Tabelle der Entität Person um eine Spalte zu erweitern, welche später den Namen in Großschreibung beinhaltet.

ALTER TABLE Persons
ADD NameGross NVARCHAR(100);

-- Erstellen Sie einen Befehl, um die neu angelegte Spalte mit dem Namen der Person komplett in Großbuchstaben zu befüllen
UPDATE Persons
SET NameGross = UPPER(Name);