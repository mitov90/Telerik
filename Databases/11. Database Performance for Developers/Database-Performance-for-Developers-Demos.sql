
SELECT LogDate FROM Logs
WHERE LogDate BETWEEN '1963-01-01' AND '2063-01-01'


CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

/*Task 3
Add a full text index for the text column. 
Try to search with and without the full-text index and compare the speed.
*/
CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT COUNT(*) FROM Logs
WHERE LogText LIKE 'Text 9993%'

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT COUNT(*) FROM Logs
WHERE LogText LIKE '%123%'

CREATE FULLTEXT CATALOG LogsFullTextCatalog
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON Logs(LogText)
KEY INDEX PK_Logs
ON LogsFullTextCatalog
WITH CHANGE_TRACKING AUTO

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT LogText FROM Logs
WHERE CONTAINS(LogText, 'Text')