
Declare @name VARCHAR(128)
Declare @SQL VarChar(254)

SElect @name = (Select TOP 1 [name] from sysobjects where [type]='P' and category=0 order by [name])

While @name is not null
Begin
Select @SQL= 'DROP PROCEDURE [dbo].[' + RTRIM(@name) +']'
Exec (@SQL)
Print 'Dropped Procedure' + @name
Select @name = (Select TOP 1 [name] from sysobjects  where [type] = 'P' and category =0 and [name] > @name order by [name]) 	
End 
GO

Declare @name VARCHAR(128)
Declare @SQL VarChar(254)

SElect @name = (Select TOP 1 [name] from sysobjects where [type]='V' and category=0 order by [name])

While @name is not null
Begin
Select @SQL= 'DROP PROCEDURE [dbo].[' + RTRIM(@name) +']'
Exec (@SQL)
Print 'Dropped View' + @name
Select @name = (Select TOP 1 [name] from sysobjects  where [type] = 'V' and category =0 and [name] > @name order by [name]) 	
End 
GO

Declare @name VARCHAR(128)
Declare @SQL VarChar(254)

SElect @name = (Select TOP 1 [name] from sysobjects where [type] IN (N'FN',N'IF',N'TF','FS','FT') and category=0 order by [name])

While @name is not null
Begin
Select @SQL= 'DROP function [dbo].[' + RTRIM(@name) +']'
Exec (@SQL)
Print 'Dropped Function' + @name
Select @name = (Select TOP 1 [name] from sysobjects  where [type] in (N'FN',N'IF',N'TF','FS','FT') and category =0 and [name] > @name order by [name]) 	
End 
GO

Declare @SQL VarChar(500)
Declare @cursor Cursor

Set @cursor= CURSOR FAST_Forward For
Select DISTINCT sql = 'ALTER TABLE ['+ tc2.TABLE_SCHEMA +'].[' + tc2.TABLE_NAME + '] DROP [' + rc1.CONSTRAINT_NAME + ']'
From INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc1
LEFT JOIN INFORmation_SCHEMA.TABLE_CONSTRAINTS tc2 on tc2.CONSTRAINT_NAME = rc1.CONSTRAINT_NAME 
open @cursor FETCH NEXT from @Cursor INTO @SQL
While (@@FETCH_STATUS = 0)
BEGIN
EXEC SP_EXECUTESQL @SQL
FETCH NEXT FROM @cursor INTO @SQL
END
CLOSE @cursor DEALLOCATE @cursor
GO
EXEC sp_MSforeachtable 'DROP TABLE ?'