## To destroy Azure Database

        /* Azure friendly */
        /* Drop all Foreign Key constraints */
        DECLARE @name VARCHAR(128)
        DECLARE @constraint VARCHAR(254)
        DECLARE @SQL VARCHAR(254)

        SELECT @name = (SELECT TOP 1 TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'FOREIGN KEY' ORDER BY TABLE_NAME)

        WHILE @name is not null
        BEGIN
            SELECT @constraint = (SELECT TOP 1 CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'FOREIGN KEY' AND TABLE_NAME = @name ORDER BY CONSTRAINT_NAME)
            WHILE @constraint IS NOT NULL
            BEGIN
                SELECT @SQL = 'ALTER TABLE [dbo].[' + RTRIM(@name) +'] DROP CONSTRAINT [' + RTRIM(@constraint) +']'
                EXEC (@SQL)
                PRINT 'Dropped FK Constraint: ' + @constraint + ' on ' + @name
                SELECT @constraint = (SELECT TOP 1 CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'FOREIGN KEY' AND CONSTRAINT_NAME <> @constraint AND TABLE_NAME = @name ORDER BY CONSTRAINT_NAME)
            END
        SELECT @name = (SELECT TOP 1 TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'FOREIGN KEY' ORDER BY TABLE_NAME)
        END
        GO

        /* Drop all Primary Key constraints */
        DECLARE @name VARCHAR(128)
        DECLARE @constraint VARCHAR(254)
        DECLARE @SQL VARCHAR(254)

        SELECT @name = (SELECT TOP 1 TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'PRIMARY KEY' ORDER BY TABLE_NAME)

        WHILE @name IS NOT NULL
        BEGIN
            SELECT @constraint = (SELECT TOP 1 CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'PRIMARY KEY' AND TABLE_NAME = @name ORDER BY CONSTRAINT_NAME)
            WHILE @constraint is not null
            BEGIN
                SELECT @SQL = 'ALTER TABLE [dbo].[' + RTRIM(@name) +'] DROP CONSTRAINT [' + RTRIM(@constraint)+']'
                EXEC (@SQL)
                PRINT 'Dropped PK Constraint: ' + @constraint + ' on ' + @name
                SELECT @constraint = (SELECT TOP 1 CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'PRIMARY KEY' AND CONSTRAINT_NAME <> @constraint AND TABLE_NAME = @name ORDER BY CONSTRAINT_NAME)
            END
        SELECT @name = (SELECT TOP 1 TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'PRIMARY KEY' ORDER BY TABLE_NAME)
        END
        GO

        /* Drop all tables */
        DECLARE @name VARCHAR(128)
        DECLARE @SQL VARCHAR(254)

        SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'U' AND category = 0 ORDER BY [name])

        WHILE @name IS NOT NULL
        BEGIN
            SELECT @SQL = 'DROP TABLE [dbo].[' + RTRIM(@name) +']'
            EXEC (@SQL)
            PRINT 'Dropped Table: ' + @name
            SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'U' AND category = 0 AND [name] > @name ORDER BY [name])
        END
        GO

## To Add New Entity Migration
        
        dotnet ef migrations add <MigrationName>

## To Update Azure Database

        dotnet ef database update

## To Clean Application

        dotnet ef clean

## To Build Application

        dotnet ef build

## To Run Application

## To push and commit to Branch

## To pull from current branch