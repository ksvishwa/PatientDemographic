
--Step 1 : 
	create database PatientDemographics
	GO

--Step 2 : 
	USE [PatientDemographics]
	GO

	/****** Object:  Table [dbo].[Patient]    Script Date: 8/27/2018 12:07:17 PM ******/
	SET ANSI_NULLS ON
	GO

	SET QUOTED_IDENTIFIER ON
	GO

	CREATE TABLE [dbo].[Patient](
		[PatientId] [int] IDENTITY(1,1) NOT NULL,
		[PatientDetail] [xml] NOT NULL,
	 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
	(
		[PatientId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
	GO
