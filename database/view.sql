
--eine View, welche alle Personen mit deren Anschriften und Telefonnummer als eine Ergebnistabelle ausgibt

CREATE VIEW View_PersonDetails AS
SELECT
    p.Name,
    p.Vorname,
    a.Ort,
    a.Strasse,
    a.Hausnummer,
    t.Nummer
FROM Persons p
LEFT JOIN Anschriften a ON p.PersonID = a.PersonID
LEFT JOIN Telefonverbindungen t ON p.PersonID = t.PersonID;
