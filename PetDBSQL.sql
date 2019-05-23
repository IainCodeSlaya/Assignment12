CREATE DATABASE PetDB
GO

USE PetDB
GO

CREATE TABLE [Pet_Type] (
  [Pet_Type_ID] int IDENTITY(1,1) PRIMARY KEY,
  [Pet_Type] varchar(32),
);

INSERT INTO [dbo].[Pet_Type] VALUES ('Dog')
INSERT INTO [dbo].[Pet_Type] VALUES ('Cat')
INSERT INTO [dbo].[Pet_Type] VALUES ('Bird')
INSERT INTO [dbo].[Pet_Type] VALUES ('Snake')
INSERT INTO [dbo].[Pet_Type] VALUES ('Iguana')

CREATE TABLE [Pet] (
  [Pet_ID] int IDENTITY(1,1) PRIMARY KEY,
  [Pet_Type_ID] int FOREIGN KEY REFERENCES [Pet_Type]([Pet_Type_ID]),
  [Pet_Price] float,
  [Pet_Quantitiy] int
);

INSERT INTO [dbo].[Pet] VALUES (1,3000.00,12)
INSERT INTO [dbo].[Pet] VALUES (2,2200.00,15)
INSERT INTO [dbo].[Pet] VALUES (3,800.00,13)
INSERT INTO [dbo].[Pet] VALUES (4,200.00,9)
INSERT INTO [dbo].[Pet] VALUES (5,2800.00,5)

CREATE TABLE [Sale_Pet] (
  [Sale_ID] int IDENTITY(1,1) PRIMARY KEY,
  [Sale_Amount] float 
);

INSERT INTO [dbo].[Sale_Pet] VALUES (6200.00)
INSERT INTO [dbo].[Sale_Pet] VALUES (9000.00)
INSERT INTO [dbo].[Sale_Pet] VALUES (2800.00)


CREATE TABLE [Sale_Line_Pet] (
	[Pet_ID] int FOREIGN KEY REFERENCES [Pet]([Pet_ID]),
	[Sale_ID] int FOREIGN KEY REFERENCES [Sale_Pet]([Sale_ID]),
	[Pet_Sale_Q] int,
	CONSTRAINT [Sale_Line_Pet_ID] PRIMARY KEY ([Pet_ID],[Sale_ID])
);

INSERT INTO [dbo].[Sale_Line_Pet] VALUES (1,1,1)
INSERT INTO [dbo].[Sale_Line_Pet] VALUES (2,1,1)
INSERT INTO [dbo].[Sale_Line_Pet] VALUES (3,1,1)
INSERT INTO [dbo].[Sale_Line_Pet] VALUES (4,1,1)
INSERT INTO [dbo].[Sale_Line_Pet] VALUES (1,2,1)
INSERT INTO [dbo].[Sale_Line_Pet] VALUES (2,2,1)
INSERT INTO [dbo].[Sale_Line_Pet] VALUES (3,2,1)
INSERT INTO [dbo].[Sale_Line_Pet] VALUES (4,2,1)
INSERT INTO [dbo].[Sale_Line_Pet] VALUES (5,2,1)
INSERT INTO [dbo].[Sale_Line_Pet] VALUES (5,3,1)