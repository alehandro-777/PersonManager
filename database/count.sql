
--Wie viele Personendatensätze sind vorhanden?
SELECT COUNT(*) AS AnzahlPersonen
FROM Persons;

--Wie viele Personen wohnen in Dresden?
SELECT COUNT(DISTINCT Persons.PersonID) AS PersonenInDresden
FROM Persons
JOIN Anschriften ON Persons.PersonID = Anschriften.PersonID
WHERE Ort = 'Dresden';

--Wie viele Personen haben mehr als eine Telefonnummer?
SELECT PersonID, COUNT(*) AS TelefonAnzahl
FROM Telefonverbindungen
GROUP BY PersonID
HAVING COUNT(*) > 1;

--welche die Anzahl der Personen pro Ort ausgibt
SELECT Ort, COUNT(DISTINCT PersonID) AS AnzahlPersonen
FROM Anschriften
GROUP BY Ort;