USE [NationalCrime]
GO
/****** Object:  Table [dbo].[user]    Script Date: 01/03/2016 15:12:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userName] [varchar](200) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[password] [varchar](200) NOT NULL,
	[usercode] [varchar](200) NOT NULL,
	[activestatus] [bit] NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[user] ON
INSERT [dbo].[user] ([id], [userName], [email], [password], [usercode], [activestatus]) VALUES (1, N'tpriyesh', N'awayi188@gmail.com', N'1a140f9f1b05a4e64fb2beb574fb22a0', N't9omW0fdUSZDmD9e93691sKsRL4rYKaBRzx3TkZorpUJI9PwgNt5lA==', 1)
INSERT [dbo].[user] ([id], [userName], [email], [password], [usercode], [activestatus]) VALUES (2, N'fsdf', N'tpriyesh188@gmail.com', N'13f62eaeb3bc4c82dfc765295566b901', N'joocV2+xrvu5ZEypMEFGUP39UpIABTec7JGKoDef/5AJI9PwgNt5lA==', 1)
INSERT [dbo].[user] ([id], [userName], [email], [password], [usercode], [activestatus]) VALUES (3, N'raman', N'gmchkr@gmail.com', N'f937f5583ee9f82ba88e9fa7f8a28582', N'jXuFzc/1DlpeMYhTLi2kzGK2xHeZRqHygL3jMpneeX4JI9PwgNt5lA==', 1)
INSERT [dbo].[user] ([id], [userName], [email], [password], [usercode], [activestatus]) VALUES (4, N'awayis', N'romani@gmail.com', N'85694f4f419b7266b0dca73bd8e4f64c', N'qwQUPxjfb7NLIglSz78zA7OBfFLV4gyam2wAsu7IJooJI9PwgNt5lA==', 1)
SET IDENTITY_INSERT [dbo].[user] OFF
/****** Object:  Table [dbo].[criminal]    Script Date: 01/03/2016 15:12:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[criminal](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[age] [int] NOT NULL,
	[height] [int] NOT NULL,
	[weight] [float] NOT NULL,
	[sex] [nchar](1) NOT NULL,
	[nationality] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_criminal] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[criminal] ON
INSERT [dbo].[criminal] ([id], [age], [height], [weight], [sex], [nationality], [name]) VALUES (1, 20, 160, 75, N'M', N'indian', N'priyesh tiwari')
INSERT [dbo].[criminal] ([id], [age], [height], [weight], [sex], [nationality], [name]) VALUES (2, 22, 174, 82, N'M', N'australian', N'evan')
INSERT [dbo].[criminal] ([id], [age], [height], [weight], [sex], [nationality], [name]) VALUES (3, 34, 157, 65, N'M', N'indian', N'roshele')
INSERT [dbo].[criminal] ([id], [age], [height], [weight], [sex], [nationality], [name]) VALUES (4, 38, 190, 78, N'F', N'us', N'kim')
INSERT [dbo].[criminal] ([id], [age], [height], [weight], [sex], [nationality], [name]) VALUES (5, 23, 210, 87, N'F', N'indian', N'amit')
INSERT [dbo].[criminal] ([id], [age], [height], [weight], [sex], [nationality], [name]) VALUES (6, 34, 123, 33, N'M', N'indan', N'amit')
INSERT [dbo].[criminal] ([id], [age], [height], [weight], [sex], [nationality], [name]) VALUES (7, 33, 121, 33, N'M', N'indian', N'amit')
INSERT [dbo].[criminal] ([id], [age], [height], [weight], [sex], [nationality], [name]) VALUES (8, 43, 134, 76, N'M', N'indian', N'amit')
INSERT [dbo].[criminal] ([id], [age], [height], [weight], [sex], [nationality], [name]) VALUES (9, 56, 124, 65, N'M', N'australian', N'ravi')
INSERT [dbo].[criminal] ([id], [age], [height], [weight], [sex], [nationality], [name]) VALUES (10, 45, 132, 56, N'M', N'austarali', N'hori')
INSERT [dbo].[criminal] ([id], [age], [height], [weight], [sex], [nationality], [name]) VALUES (11, 34, 123, 34, N'M', N'indian', N'kham')
INSERT [dbo].[criminal] ([id], [age], [height], [weight], [sex], [nationality], [name]) VALUES (12, 56, 232, 22, N'M', N'indan', N'ravi')
INSERT [dbo].[criminal] ([id], [age], [height], [weight], [sex], [nationality], [name]) VALUES (21, 23, 121, 22, N'M', N'indian', N'ravi')
INSERT [dbo].[criminal] ([id], [age], [height], [weight], [sex], [nationality], [name]) VALUES (22, 23, 232, 22, N'M', N'indian', N'avinsah')
INSERT [dbo].[criminal] ([id], [age], [height], [weight], [sex], [nationality], [name]) VALUES (23, 24, 121, 76, N'M', N'indian', N'ramesh')
INSERT [dbo].[criminal] ([id], [age], [height], [weight], [sex], [nationality], [name]) VALUES (24, 25, 121, 34, N'M', N'indian', N'ramesh')
INSERT [dbo].[criminal] ([id], [age], [height], [weight], [sex], [nationality], [name]) VALUES (25, 24, 121, 34, N'F', N'indian', N'kavi')
INSERT [dbo].[criminal] ([id], [age], [height], [weight], [sex], [nationality], [name]) VALUES (26, 23, 121, 65, N'F', N'indian', N'havi')
INSERT [dbo].[criminal] ([id], [age], [height], [weight], [sex], [nationality], [name]) VALUES (27, 44, 121, 67, N'F', N'us', N'av')
INSERT [dbo].[criminal] ([id], [age], [height], [weight], [sex], [nationality], [name]) VALUES (28, 67, 221, 45, N'F', N'us', N'kv')
INSERT [dbo].[criminal] ([id], [age], [height], [weight], [sex], [nationality], [name]) VALUES (29, 65, 121, 65, N'M', N'u', N'india')
INSERT [dbo].[criminal] ([id], [age], [height], [weight], [sex], [nationality], [name]) VALUES (30, 64, 121, 76, N'M', N'indian', N'karat')
INSERT [dbo].[criminal] ([id], [age], [height], [weight], [sex], [nationality], [name]) VALUES (31, 65, 211, 43, N'M', N'us', N'af')
INSERT [dbo].[criminal] ([id], [age], [height], [weight], [sex], [nationality], [name]) VALUES (32, 54, 211, 67, N'F', N'us', N'ind')
SET IDENTITY_INSERT [dbo].[criminal] OFF
