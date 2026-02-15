
--Erstellen Sie einen Löschbefehl, welcher alle Telefonnummern löscht, welche nicht mit '0' oder '+' beginnen.

DELETE FROM Telefonverbindung
WHERE Nummer NOT LIKE '0%'
AND Nummer NOT LIKE '+%';
