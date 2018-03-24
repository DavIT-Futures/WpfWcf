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

insert into Product values (1, 'P 1', 'Product 1', 101, 'Product Type 1', '2014-01-09')
insert into Product values (2, 'P 2', 'Product 2', 102, 'Product Type 2', '2014-02-22')
insert into Product values (3, 'P 3', 'Product 3', 103, 'Product Type 1', '2014-03-17')
insert into Product values (4, 'P 4', 'Product 4', 104, 'Product Type 2', '2014-04-16')
insert into Product values (5, 'P 5', 'Product 5', 105, 'Product Type 1', '2014-05-25')

insert into Employee values	(1, 'ddomagala', 'admin', 'Dawid', 'Domagala')
insert into Employee values	(2, 'gbush', 'user', 'George', 'Bush')
insert into Employee values	(3, 'bobama', 'operator', 'Barack', 'Obama')



SET NOCOUNT OFF