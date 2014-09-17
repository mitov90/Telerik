SELECT m.Name, COUNT(*) AS [Number Toys]
FROM dbo.Manufacturers m
INNER JOIN dbo.Toys t
ON t.manufacturerId=m.id
INNER JOIN dbo.AgeRanges a
ON a.id=t.ageRangeId
WHERE a.minAge>=5
AND a.maxAge <=10
GROUP BY m.Name