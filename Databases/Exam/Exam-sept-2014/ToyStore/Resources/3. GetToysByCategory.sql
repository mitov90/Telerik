--3.	Get all toys’ name, price and color from category “boys” 
SELECT t.name, t.price, t.color
FROM dbo.Toys t
INNER JOIN dbo.Categories c
ON t.categoryId = c.id
WHERE c.name = 'boys'