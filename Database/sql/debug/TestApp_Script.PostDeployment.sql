/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
SET NOCOUNT ON

insert into Product values (1, 101, 'P 1', 'Product 1', 'Product Type 1')
insert into Product values (2, 102, 'P 2', 'Product 2', 'Product Type 2')
insert into Product values (3, 103, 'P 3', 'Product 3', 'Product Type 3')
insert into Product values (4, 104, 'P 4', 'Product 4', 'Product Type 4')
insert into Product values (5, 105, 'P 5', 'Product 5', 'Product Type 5')





SET NOCOUNT OFF
