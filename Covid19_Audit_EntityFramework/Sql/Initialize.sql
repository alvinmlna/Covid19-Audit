USE [AuditContext]
GO
SET IDENTITY_INSERT [dbo].[AuditCodes] ON 
GO
INSERT [dbo].[AuditCodes] ([AuditCodeId], [AuditCodeText]) VALUES (1, N'X1')
GO
INSERT [dbo].[AuditCodes] ([AuditCodeId], [AuditCodeText]) VALUES (2, N'X2')
GO
INSERT [dbo].[AuditCodes] ([AuditCodeId], [AuditCodeText]) VALUES (3, N'X3')
GO
INSERT [dbo].[AuditCodes] ([AuditCodeId], [AuditCodeText]) VALUES (4, N'X4')
GO
INSERT [dbo].[AuditCodes] ([AuditCodeId], [AuditCodeText]) VALUES (5, N'X5')
GO
INSERT [dbo].[AuditCodes] ([AuditCodeId], [AuditCodeText]) VALUES (6, N'X6')
GO
SET IDENTITY_INSERT [dbo].[AuditCodes] OFF
GO
SET IDENTITY_INSERT [dbo].[FocusAreas] ON 
GO
INSERT [dbo].[FocusAreas] ([FocusAreaId], [AreaName]) VALUES (1, N'Hand wash')
GO
INSERT [dbo].[FocusAreas] ([FocusAreaId], [AreaName]) VALUES (2, N'Locker')
GO
INSERT [dbo].[FocusAreas] ([FocusAreaId], [AreaName]) VALUES (3, N'Canteen')
GO
INSERT [dbo].[FocusAreas] ([FocusAreaId], [AreaName]) VALUES (4, N'Coffe corner')
GO
INSERT [dbo].[FocusAreas] ([FocusAreaId], [AreaName]) VALUES (5, N'Mushola')
GO
INSERT [dbo].[FocusAreas] ([FocusAreaId], [AreaName]) VALUES (6, N'Smoking area')
GO
INSERT [dbo].[FocusAreas] ([FocusAreaId], [AreaName]) VALUES (7, N'Rest area')
GO
INSERT [dbo].[FocusAreas] ([FocusAreaId], [AreaName]) VALUES (8, N'Changing room')
GO
INSERT [dbo].[FocusAreas] ([FocusAreaId], [AreaName]) VALUES (9, N'Office')
GO
INSERT [dbo].[FocusAreas] ([FocusAreaId], [AreaName]) VALUES (10, N'Window audit')
GO
INSERT [dbo].[FocusAreas] ([FocusAreaId], [AreaName]) VALUES (11, N'Security gate')
GO
SET IDENTITY_INSERT [dbo].[FocusAreas] OFF
GO
INSERT [dbo].[FocusAreaAuditCodes] ([FocusArea_FocusAreaId], [AuditCode_AuditCodeId]) VALUES (1, 1)
GO
INSERT [dbo].[FocusAreaAuditCodes] ([FocusArea_FocusAreaId], [AuditCode_AuditCodeId]) VALUES (2, 1)
GO
INSERT [dbo].[FocusAreaAuditCodes] ([FocusArea_FocusAreaId], [AuditCode_AuditCodeId]) VALUES (3, 1)
GO
INSERT [dbo].[FocusAreaAuditCodes] ([FocusArea_FocusAreaId], [AuditCode_AuditCodeId]) VALUES (3, 2)
GO
INSERT [dbo].[FocusAreaAuditCodes] ([FocusArea_FocusAreaId], [AuditCode_AuditCodeId]) VALUES (4, 2)
GO
INSERT [dbo].[FocusAreaAuditCodes] ([FocusArea_FocusAreaId], [AuditCode_AuditCodeId]) VALUES (5, 2)
GO
INSERT [dbo].[FocusAreaAuditCodes] ([FocusArea_FocusAreaId], [AuditCode_AuditCodeId]) VALUES (6, 2)
GO
INSERT [dbo].[FocusAreaAuditCodes] ([FocusArea_FocusAreaId], [AuditCode_AuditCodeId]) VALUES (7, 2)
GO
INSERT [dbo].[FocusAreaAuditCodes] ([FocusArea_FocusAreaId], [AuditCode_AuditCodeId]) VALUES (2, 3)
GO
INSERT [dbo].[FocusAreaAuditCodes] ([FocusArea_FocusAreaId], [AuditCode_AuditCodeId]) VALUES (3, 3)
GO
INSERT [dbo].[FocusAreaAuditCodes] ([FocusArea_FocusAreaId], [AuditCode_AuditCodeId]) VALUES (6, 3)
GO
INSERT [dbo].[FocusAreaAuditCodes] ([FocusArea_FocusAreaId], [AuditCode_AuditCodeId]) VALUES (8, 4)
GO
INSERT [dbo].[FocusAreaAuditCodes] ([FocusArea_FocusAreaId], [AuditCode_AuditCodeId]) VALUES (9, 4)
GO
INSERT [dbo].[FocusAreaAuditCodes] ([FocusArea_FocusAreaId], [AuditCode_AuditCodeId]) VALUES (10, 4)
GO
INSERT [dbo].[FocusAreaAuditCodes] ([FocusArea_FocusAreaId], [AuditCode_AuditCodeId]) VALUES (8, 5)
GO
INSERT [dbo].[FocusAreaAuditCodes] ([FocusArea_FocusAreaId], [AuditCode_AuditCodeId]) VALUES (9, 5)
GO
INSERT [dbo].[FocusAreaAuditCodes] ([FocusArea_FocusAreaId], [AuditCode_AuditCodeId]) VALUES (10, 5)
GO
INSERT [dbo].[FocusAreaAuditCodes] ([FocusArea_FocusAreaId], [AuditCode_AuditCodeId]) VALUES (2, 6)
GO
INSERT [dbo].[FocusAreaAuditCodes] ([FocusArea_FocusAreaId], [AuditCode_AuditCodeId]) VALUES (11, 6)
GO
SET IDENTITY_INSERT [dbo].[Questions] ON 
GO
INSERT [dbo].[Questions] ([QuestionId], [QuestionText]) VALUES (1, N'Wear face mask properly
')
GO
INSERT [dbo].[Questions] ([QuestionId], [QuestionText]) VALUES (2, N'Washing hand before enter locker room
')
GO
INSERT [dbo].[Questions] ([QuestionId], [QuestionText]) VALUES (3, N'Maintain physical distance at least 1 meter away
')
GO
INSERT [dbo].[Questions] ([QuestionId], [QuestionText]) VALUES (4, N'Follow team/color arragement
')
GO
INSERT [dbo].[Questions] ([QuestionId], [QuestionText]) VALUES (5, N'Follow seating arrangement in meeting room (Bali & Batam room)
')
GO
INSERT [dbo].[Questions] ([QuestionId], [QuestionText]) VALUES (6, N'Perform Temperature check before enter the gate
')
GO
SET IDENTITY_INSERT [dbo].[Questions] OFF
GO
INSERT [dbo].[QuestionFocusAreas] ([Question_QuestionId], [FocusArea_FocusAreaId]) VALUES (1, 1)
GO
INSERT [dbo].[QuestionFocusAreas] ([Question_QuestionId], [FocusArea_FocusAreaId]) VALUES (2, 1)
GO
INSERT [dbo].[QuestionFocusAreas] ([Question_QuestionId], [FocusArea_FocusAreaId]) VALUES (3, 1)
GO
INSERT [dbo].[QuestionFocusAreas] ([Question_QuestionId], [FocusArea_FocusAreaId]) VALUES (1, 2)
GO
INSERT [dbo].[QuestionFocusAreas] ([Question_QuestionId], [FocusArea_FocusAreaId]) VALUES (3, 2)
GO
INSERT [dbo].[QuestionFocusAreas] ([Question_QuestionId], [FocusArea_FocusAreaId]) VALUES (4, 2)
GO
INSERT [dbo].[QuestionFocusAreas] ([Question_QuestionId], [FocusArea_FocusAreaId]) VALUES (1, 3)
GO
INSERT [dbo].[QuestionFocusAreas] ([Question_QuestionId], [FocusArea_FocusAreaId]) VALUES (3, 3)
GO
INSERT [dbo].[QuestionFocusAreas] ([Question_QuestionId], [FocusArea_FocusAreaId]) VALUES (4, 3)
GO
INSERT [dbo].[QuestionFocusAreas] ([Question_QuestionId], [FocusArea_FocusAreaId]) VALUES (3, 4)
GO
INSERT [dbo].[QuestionFocusAreas] ([Question_QuestionId], [FocusArea_FocusAreaId]) VALUES (1, 5)
GO
INSERT [dbo].[QuestionFocusAreas] ([Question_QuestionId], [FocusArea_FocusAreaId]) VALUES (3, 5)
GO
INSERT [dbo].[QuestionFocusAreas] ([Question_QuestionId], [FocusArea_FocusAreaId]) VALUES (4, 5)
GO
INSERT [dbo].[QuestionFocusAreas] ([Question_QuestionId], [FocusArea_FocusAreaId]) VALUES (3, 6)
GO
INSERT [dbo].[QuestionFocusAreas] ([Question_QuestionId], [FocusArea_FocusAreaId]) VALUES (1, 7)
GO
INSERT [dbo].[QuestionFocusAreas] ([Question_QuestionId], [FocusArea_FocusAreaId]) VALUES (3, 7)
GO
INSERT [dbo].[QuestionFocusAreas] ([Question_QuestionId], [FocusArea_FocusAreaId]) VALUES (1, 8)
GO
INSERT [dbo].[QuestionFocusAreas] ([Question_QuestionId], [FocusArea_FocusAreaId]) VALUES (3, 8)
GO
INSERT [dbo].[QuestionFocusAreas] ([Question_QuestionId], [FocusArea_FocusAreaId]) VALUES (1, 9)
GO
INSERT [dbo].[QuestionFocusAreas] ([Question_QuestionId], [FocusArea_FocusAreaId]) VALUES (3, 9)
GO
INSERT [dbo].[QuestionFocusAreas] ([Question_QuestionId], [FocusArea_FocusAreaId]) VALUES (5, 9)
GO
INSERT [dbo].[QuestionFocusAreas] ([Question_QuestionId], [FocusArea_FocusAreaId]) VALUES (1, 10)
GO
INSERT [dbo].[QuestionFocusAreas] ([Question_QuestionId], [FocusArea_FocusAreaId]) VALUES (3, 10)
GO
INSERT [dbo].[QuestionFocusAreas] ([Question_QuestionId], [FocusArea_FocusAreaId]) VALUES (1, 11)
GO
INSERT [dbo].[QuestionFocusAreas] ([Question_QuestionId], [FocusArea_FocusAreaId]) VALUES (3, 11)
GO
INSERT [dbo].[QuestionFocusAreas] ([Question_QuestionId], [FocusArea_FocusAreaId]) VALUES (6, 11)
GO
