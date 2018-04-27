CREATE TABLE [dbo].[FileLine]
(
	[Id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Date] DATE NULL, 
    [EngSymb] NCHAR(10) NULL, 
    [RusSymb] NCHAR(10) NULL, 
    [IntNum] INT NULL, 
    [DoubleNum] FLOAT NULL,

)
