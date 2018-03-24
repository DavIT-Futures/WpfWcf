CREATE TABLE [dbo].[Product]
(
	ProductId			int NOT NULL, 
	Name				nvarchar(100) NOT NULL,
	Description			nvarchar(100) NOT NULL,
	Number				int NOT NULL,
	ProductType			nvarchar(100) NOT NULL,
	ReleaseDate			Datetime NOT NULL
)
