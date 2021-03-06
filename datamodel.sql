USE [TrainingDataModel]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 25/09/2017 13:29:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](60) NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NULL,
	[ChangedOn] [datetime2](7) NOT NULL,
	[ChangedBy] [int] NULL,
 CONSTRAINT [PK_COUNTRY] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 25/09/2017 13:29:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Alias] [nvarchar](10) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[City] [nvarchar](30) NULL,
	[CountryId] [int] NULL,
	[DateOfBirth] [date] NULL,
	[Gender] [nvarchar](10) NULL,
 CONSTRAINT [PK_STUDENT] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Country] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Country] ADD  DEFAULT (getdate()) FOR [ChangedOn]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_STUDENT_REFERENCE_COUNTRY] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_STUDENT_REFERENCE_COUNTRY]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [CKC_GENDER_STUDENT] CHECK  (([Gender] IS NULL OR ([Gender]='Femenino' OR [Gender]='Masculino')))
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [CKC_GENDER_STUDENT]
GO
