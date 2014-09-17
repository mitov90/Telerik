SELECT t.name, t.price
FROM dbo.Toys t
WHERE t.type='puzzle'
AND t.price>=10
ORDER BY t.price