USE [master]
GO
/****** Object:  Database [CSoDnDP]    Script Date: 09.03.2020 22:30:53 ******/
CREATE DATABASE [CSoDnDP] ON  PRIMARY 
( NAME = N'CSoDnDP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\CSoDnDP.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CSoDnDP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\CSoDnDP_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CSoDnDP] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CSoDnDP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CSoDnDP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CSoDnDP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CSoDnDP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CSoDnDP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CSoDnDP] SET ARITHABORT OFF 
GO
ALTER DATABASE [CSoDnDP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CSoDnDP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CSoDnDP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CSoDnDP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CSoDnDP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CSoDnDP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CSoDnDP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CSoDnDP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CSoDnDP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CSoDnDP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CSoDnDP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CSoDnDP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CSoDnDP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CSoDnDP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CSoDnDP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CSoDnDP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CSoDnDP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CSoDnDP] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CSoDnDP] SET  MULTI_USER 
GO
ALTER DATABASE [CSoDnDP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CSoDnDP] SET DB_CHAINING OFF 
GO
USE [CSoDnDP]
GO
/****** Object:  Table [dbo].[Characters]    Script Date: 09.03.2020 22:30:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Characters](
	[CharacterID] [int] IDENTITY(1,1) NOT NULL,
	[PlayerID] [int] NOT NULL,
	[CharName] [nvarchar](50) NOT NULL,
	[InfoXML] [xml] NOT NULL,
	[StatesXML] [xml] NOT NULL,
	[MagicXML] [xml] NOT NULL,
	[InventoryXML] [xml] NOT NULL,
 CONSTRAINT [PK_Characters] PRIMARY KEY CLUSTERED 
(
	[CharacterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Parties]    Script Date: 09.03.2020 22:30:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parties](
	[PartyID] [int] IDENTITY(1,1) NOT NULL,
	[PartyName] [nvarchar](50) NOT NULL,
	[MasterID] [int] NOT NULL,
	[PartyState] [int] NOT NULL,
 CONSTRAINT [PK_Parties] PRIMARY KEY CLUSTERED 
(
	[PartyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PartyPlayers]    Script Date: 09.03.2020 22:30:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartyPlayers](
	[PartyID] [int] NOT NULL,
	[PlayerID] [int] NOT NULL,
	[CharacterID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PartyStates]    Script Date: 09.03.2020 22:30:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartyStates](
	[PartyStateID] [int] NOT NULL,
	[PartyStateName] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_PartyStates_1] PRIMARY KEY CLUSTERED 
(
	[PartyStateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 09.03.2020 22:30:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserRoleID] [int] NOT NULL,
	[UserRoleName] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_UserRoles_1] PRIMARY KEY CLUSTERED 
(
	[UserRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 09.03.2020 22:30:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserLogin] [nvarchar](50) NOT NULL,
	[UserPassword] [nvarchar](50) NOT NULL,
	[UserRoleID] [int] NOT NULL,
 CONSTRAINT [PK_Users_1] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Characters] ON 

INSERT [dbo].[Characters] ([CharacterID], [PlayerID], [CharName], [InfoXML], [StatesXML], [MagicXML], [InventoryXML]) VALUES (1, 1, N'NoobSlayer', N'<Info><Race>Pony</Race><Classes><Class><Name>
                                God
                            </Name><Level>
                                2
                            </Level></Class><Class><Name>
                                Devil
                            </Name><Level>
                                5
                            </Level></Class></Classes><Alignment>Chaotic Good</Alignment><Background>Murderhobo</Background><Exp>666</Exp><Hp>123</Hp><MaxHP>321</MaxHP><Speed>30</Speed><Traits>Швец, Жнец, На дуде игрец</Traits><Ideals>Возмездие</Ideals><Bonds>Я в неоплатном долгу перед человеком, что сжалился и помог мне</Bonds><Flaws>Начав пить, я не могу остановиться</Flaws><Features><Feature><Name>
                                Обычный
                            </Name><Description>
                                Самый обычный
                            </Description></Feature><Feature><Name>
                                НеОбычный
                            </Name><Description>
                                Самый необычный
                            </Description></Feature><Feature><Name>
                                Шиза
                            </Name><Description>
                                Раздвоение личности
                            </Description></Feature></Features></Info>', N'<CharacterStates><States><Strength><Value>10</Value><Bonus>0</Bonus><Skills><SavingThrow><Mastery>false</Mastery><Bonus>0</Bonus></SavingThrow><Athletic><Mastery>true</Mastery><Bonus>0</Bonus></Athletic></Skills></Strength><Dexterity><Value>10</Value><Bonus>0</Bonus><Skills><SavingThrow><Mastery>false</Mastery><Bonus>0</Bonus></SavingThrow><Acrobatic><Mastery>false</Mastery><Bonus>0</Bonus></Acrobatic><Sleight_of_Hand><Mastery>false</Mastery><Bonus>0</Bonus></Sleight_of_Hand><Stealth><Mastery>false</Mastery><Bonus>0</Bonus></Stealth></Skills></Dexterity><Constitution><Value>10</Value><Bonus>0</Bonus><Skills><SavingThrow><Mastery>false</Mastery><Bonus>0</Bonus></SavingThrow></Skills></Constitution><Intelligence><Value>10</Value><Bonus>2</Bonus><Skills><SavingThrow><Mastery>false</Mastery><Bonus>0</Bonus></SavingThrow><Investigation><Mastery>false</Mastery><Bonus>0</Bonus></Investigation><History><Mastery>true</Mastery><Bonus>0</Bonus></History><Arcana><Mastery>false</Mastery><Bonus>1</Bonus></Arcana><Nature><Mastery>true</Mastery><Bonus>1</Bonus></Nature><Religion><Mastery>false</Mastery><Bonus>0</Bonus></Religion></Skills></Intelligence><Wisdom><Value>12</Value><Bonus>0</Bonus><Skills><SavingThrow><Mastery>false</Mastery><Bonus>0</Bonus></SavingThrow><Perception><Mastery>true</Mastery><Bonus>1</Bonus></Perception><Survival><Mastery>false</Mastery><Bonus>0</Bonus></Survival><Medicine><Mastery>false</Mastery><Bonus>0</Bonus></Medicine><Insight><Mastery>false</Mastery><Bonus>0</Bonus></Insight><Animal_Handling><Mastery>false</Mastery><Bonus>0</Bonus></Animal_Handling></Skills></Wisdom><Charisma><Value>10</Value><Bonus>0</Bonus><Skills><SavingThrow><Mastery>false</Mastery><Bonus>0</Bonus></SavingThrow><Performance><Mastery>false</Mastery><Bonus>0</Bonus></Performance><Intimidation><Mastery>false</Mastery><Bonus>0</Bonus></Intimidation><Deception><Mastery>false</Mastery><Bonus>0</Bonus></Deception><Persuasion><Mastery>false</Mastery><Bonus>0</Bonus></Persuasion></Skills></Charisma></States><Languages><Language>Russian</Language><Language>Binary</Language></Languages><Proficiencies><Proficiency>Swords</Proficiency><Proficiency>Daggers</Proficiency></Proficiencies></CharacterStates>', N'<Magick><Сantrips><Spell>Плящущие огоньки</Spell></Сantrips><Spells><Spells_1><SpellCells>1</SpellCells><Spell>s1</Spell></Spells_1><Spells_2><SpellCells>0</SpellCells></Spells_2><Spells_3><SpellCells>0</SpellCells></Spells_3><Spells_4><SpellCells>0</SpellCells></Spells_4><Spells_5><SpellCells>5</SpellCells><Spell>test_1</Spell><Spell>test_2</Spell><Spell>test_3</Spell></Spells_5><Spells_6><SpellCells>0</SpellCells></Spells_6><Spells_7><SpellCells>0</SpellCells></Spells_7><Spells_8><SpellCells>0</SpellCells></Spells_8><Spells_9><SpellCells>1</SpellCells><Spell>Уничтожение всего живого</Spell></Spells_9></Spells></Magick>', N'<Inventory><Equipment><Weapon><Name>Двуручный меч</Name><Type>Two-handed sword</Type><Mod>2</Mod><Damage>2d6 рубящий</Damage><Properties>Two-handed, heavy</Properties></Weapon><Weapon><Name>test1</Name><Type>111</Type><Mod>5</Mod><Damage>2d666 дизинтегрирующий</Damage><Properties>аоао</Properties></Weapon><Armor><Name>Кожанный доспех</Name><Type>Light</Type><AC>11</AC><Properties /></Armor><Armor><Name>Доспешная кожа</Name><Type>фывфыв</Type><AC>999</AC><Properties>HindranceStealth</Properties></Armor><Item><Name>Камушек</Name><Description>каменный</Description></Item><Item><Name>Камушек 2</Name><Description>very каменный</Description></Item></Equipment><Money><Copper>5</Copper><Silver>4</Silver><Electrum>3</Electrum><Gold>2</Gold><Platinum>1</Platinum></Money></Inventory>')
INSERT [dbo].[Characters] ([CharacterID], [PlayerID], [CharName], [InfoXML], [StatesXML], [MagicXML], [InventoryXML]) VALUES (3, 1, N'test_char_4', N'<Info><Race>Human</Race><Classes><Class><Name>Warrior</Name><Level> 1</Level></Class></Classes><Alignment>Lawfull Evil</Alignment><Background>CharBackground</Background><Exp>0</Exp><Hp>0</Hp><MaxHP>0</MaxHP><Speed>0</Speed><Traits>Traits</Traits><Ideals>Ideals</Ideals><Bonds>Bonds</Bonds><Flaws>Flaws</Flaws><Features><Feature><Name>FeatureName2</Name><Description> FeatureDesc</Description></Feature></Features></Info>', N'<CharacterStates><States><Strength><Value>10</Value><Bonus>0</Bonus><Skills><SavingThrow><Mastery>false</Mastery><Bonus>0</Bonus></SavingThrow><Athletic><Mastery>false</Mastery><Bonus>0</Bonus></Athletic></Skills></Strength><Dexterity><Value>10</Value><Bonus>0</Bonus><Skills><SavingThrow><Mastery>false</Mastery><Bonus>0</Bonus></SavingThrow><Acrobatic><Mastery>false</Mastery><Bonus>0</Bonus></Acrobatic><Sleight_of_Hand><Mastery>false</Mastery><Bonus>0</Bonus></Sleight_of_Hand><Stealth><Mastery>false</Mastery><Bonus>0</Bonus></Stealth></Skills></Dexterity><Constitution><Value>10</Value><Bonus>0</Bonus><Skills><SavingThrow><Mastery>false</Mastery><Bonus>0</Bonus></SavingThrow></Skills></Constitution><Intelligence><Value>10</Value><Bonus>0</Bonus><Skills><SavingThrow><Mastery>false</Mastery><Bonus>0</Bonus></SavingThrow><Investigation><Mastery>false</Mastery><Bonus>0</Bonus></Investigation><History><Mastery>false</Mastery><Bonus>0</Bonus></History><Arcana><Mastery>false</Mastery><Bonus>0</Bonus></Arcana><Nature><Mastery>false</Mastery><Bonus>0</Bonus></Nature><Religion><Mastery>false</Mastery><Bonus>0</Bonus></Religion></Skills></Intelligence><Wisdom><Value>10</Value><Bonus>0</Bonus><Skills><SavingThrow><Mastery>false</Mastery><Bonus>0</Bonus></SavingThrow><Perception><Mastery>false</Mastery><Bonus>0</Bonus></Perception><Survival><Mastery>false</Mastery><Bonus>0</Bonus></Survival><Medicine><Mastery>false</Mastery><Bonus>0</Bonus></Medicine><Insight><Mastery>false</Mastery><Bonus>0</Bonus></Insight><Animal_Handling><Mastery>false</Mastery><Bonus>0</Bonus></Animal_Handling></Skills></Wisdom><Charisma><Value>10</Value><Bonus>0</Bonus><Skills><SavingThrow><Mastery>false</Mastery><Bonus>0</Bonus></SavingThrow><Performance><Mastery>false</Mastery><Bonus>0</Bonus></Performance><Intimidation><Mastery>false</Mastery><Bonus>0</Bonus></Intimidation><Deception><Mastery>false</Mastery><Bonus>0</Bonus></Deception><Persuasion><Mastery>false</Mastery><Bonus>0</Bonus></Persuasion></Skills></Charisma></States><Languages><Language>1</Language></Languages><Proficiencies><Proficiency>2</Proficiency></Proficiencies></CharacterStates>', N'<Magick><Сantrips><Spell>1</Spell></Сantrips><Spells><Spells_1><SpellCells>0</SpellCells></Spells_1><Spells_2><SpellCells>0</SpellCells></Spells_2><Spells_3><SpellCells>0</SpellCells></Spells_3><Spells_4><SpellCells>0</SpellCells></Spells_4><Spells_5><SpellCells>0</SpellCells></Spells_5><Spells_6><SpellCells>0</SpellCells></Spells_6><Spells_7><SpellCells>0</SpellCells></Spells_7><Spells_8><SpellCells>0</SpellCells></Spells_8><Spells_9><SpellCells>0</SpellCells></Spells_9></Spells></Magick>', N'<Inventory><Equipment><Weapon><Name>1</Name><Type>1</Type><Mod>1</Mod><Damage>1</Damage><Properties>1</Properties></Weapon><Armor><Name>2</Name><Type>2</Type><AC>2</AC><Properties>2</Properties></Armor><Item><Name>3</Name><Description>3</Description></Item></Equipment><Money><Copper>2</Copper><Silver>0</Silver><Electrum>1</Electrum><Gold>0</Gold><Platinum>2</Platinum></Money></Inventory>')
INSERT [dbo].[Characters] ([CharacterID], [PlayerID], [CharName], [InfoXML], [StatesXML], [MagicXML], [InventoryXML]) VALUES (17, 1, N'CharNameUpd3', N'<Info><Race>Human</Race><Classes><Class><Name>
                                
                                
                                
                                Warrior
                            
                            
                            
                            </Name><Level>
                                1
                            </Level></Class></Classes><Alignment>Chaotic Good</Alignment><Background>CharBackground</Background><Exp>1</Exp><Hp>2</Hp><MaxHP>3</MaxHP><Speed>4</Speed><Traits>Traits</Traits><Ideals>Ideals</Ideals><Bonds>Bonds</Bonds><Flaws>Flaws</Flaws><Features><Feature><Name>
                                
                                
                                
                                FeatureName1
                            
                            
                            
                            </Name><Description>
                                
                                
                                
                                 FeatureDesc
                            
                            
                            
                            </Description></Feature><Feature><Name>
                                
                                
                                
                                FeatureName2
                            
                            
                            
                            </Name><Description>
                                
                                
                                
                                 FeatureDesc
                            
                            
                            
                            </Description></Feature></Features></Info>', N'<CharacterStates><States><Strength><Value>11</Value><Bonus>0</Bonus><Skills><SavingThrow><Mastery>true</Mastery><Bonus>1</Bonus></SavingThrow><Athletic><Mastery>false</Mastery><Bonus>1</Bonus></Athletic></Skills></Strength><Dexterity><Value>12</Value><Bonus>0</Bonus><Skills><SavingThrow><Mastery>true</Mastery><Bonus>0</Bonus></SavingThrow><Acrobatic><Mastery>false</Mastery><Bonus>0</Bonus></Acrobatic><Sleight_of_Hand><Mastery>true</Mastery><Bonus>-1</Bonus></Sleight_of_Hand><Stealth><Mastery>false</Mastery><Bonus>-1</Bonus></Stealth></Skills></Dexterity><Constitution><Value>13</Value><Bonus>0</Bonus><Skills><SavingThrow><Mastery>false</Mastery><Bonus>1</Bonus></SavingThrow></Skills></Constitution><Intelligence><Value>14</Value><Bonus>1</Bonus><Skills><SavingThrow><Mastery>true</Mastery><Bonus>1</Bonus></SavingThrow><Investigation><Mastery>false</Mastery><Bonus>1</Bonus></Investigation><History><Mastery>true</Mastery><Bonus>0</Bonus></History><Arcana><Mastery>false</Mastery><Bonus>0</Bonus></Arcana><Nature><Mastery>true</Mastery><Bonus>-1</Bonus></Nature><Religion><Mastery>true</Mastery><Bonus>-1</Bonus></Religion></Skills></Intelligence><Wisdom><Value>15</Value><Bonus>-1</Bonus><Skills><SavingThrow><Mastery>true</Mastery><Bonus>1</Bonus></SavingThrow><Perception><Mastery>false</Mastery><Bonus>1</Bonus></Perception><Survival><Mastery>true</Mastery><Bonus>0</Bonus></Survival><Medicine><Mastery>false</Mastery><Bonus>0</Bonus></Medicine><Insight><Mastery>true</Mastery><Bonus>-1</Bonus></Insight><Animal_Handling><Mastery>false</Mastery><Bonus>-1</Bonus></Animal_Handling></Skills></Wisdom><Charisma><Value>16</Value><Bonus>-1</Bonus><Skills><SavingThrow><Mastery>false</Mastery><Bonus>0</Bonus></SavingThrow><Performance><Mastery>false</Mastery><Bonus>0</Bonus></Performance><Intimidation><Mastery>false</Mastery><Bonus>0</Bonus></Intimidation><Deception><Mastery>false</Mastery><Bonus>0</Bonus></Deception><Persuasion><Mastery>false</Mastery><Bonus>0</Bonus></Persuasion></Skills></Charisma></States><Languages><Language>l1</Language><Language>l2</Language></Languages><Proficiencies><Proficiency>p1</Proficiency><Proficiency>p2</Proficiency></Proficiencies></CharacterStates>', N'<Magick><Сantrips><Spell>c1</Spell><Spell>c2</Spell></Сantrips><Spells><Spells_1><SpellCells>3</SpellCells><Spell>s11</Spell><Spell>s12</Spell></Spells_1><Spells_2><SpellCells>1</SpellCells></Spells_2><Spells_3><SpellCells>0</SpellCells></Spells_3><Spells_4><SpellCells>0</SpellCells></Spells_4><Spells_5><SpellCells>0</SpellCells></Spells_5><Spells_6><SpellCells>0</SpellCells></Spells_6><Spells_7><SpellCells>0</SpellCells></Spells_7><Spells_8><SpellCells>0</SpellCells></Spells_8><Spells_9><SpellCells>0</SpellCells></Spells_9></Spells></Magick>', N'<Inventory><Equipment><Weapon><Name>w1</Name><Type>1</Type><Mod>1</Mod><Damage>1</Damage><Properties>1</Properties></Weapon><Armor><Name>a2</Name><Type>2</Type><AC>2</AC><Properties>2</Properties></Armor><Item><Name>i3</Name><Description>3</Description></Item></Equipment><Money><Copper>4</Copper><Silver>5</Silver><Electrum>6</Electrum><Gold>7</Gold><Platinum>8</Platinum></Money></Inventory>')
SET IDENTITY_INSERT [dbo].[Characters] OFF
SET IDENTITY_INSERT [dbo].[Parties] ON 

INSERT [dbo].[Parties] ([PartyID], [PartyName], [MasterID], [PartyState]) VALUES (2, N'Test_party', 1, 0)
SET IDENTITY_INSERT [dbo].[Parties] OFF
INSERT [dbo].[PartyPlayers] ([PartyID], [PlayerID], [CharacterID]) VALUES (2, 1, 1)
INSERT [dbo].[PartyStates] ([PartyStateID], [PartyStateName]) VALUES (0, N'Recruitment')
INSERT [dbo].[PartyStates] ([PartyStateID], [PartyStateName]) VALUES (1, N'Preparation')
INSERT [dbo].[PartyStates] ([PartyStateID], [PartyStateName]) VALUES (2, N'In the process')
INSERT [dbo].[PartyStates] ([PartyStateID], [PartyStateName]) VALUES (3, N'Completed')
INSERT [dbo].[UserRoles] ([UserRoleID], [UserRoleName]) VALUES (0, N'User')
INSERT [dbo].[UserRoles] ([UserRoleID], [UserRoleName]) VALUES (1, N'Admin')
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [UserLogin], [UserPassword], [UserRoleID]) VALUES (1, N'FlamingEye', N'password', 1)
INSERT [dbo].[Users] ([UserID], [UserLogin], [UserPassword], [UserRoleID]) VALUES (2, N'test_user', N'123456', 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_PartyStates]    Script Date: 09.03.2020 22:30:53 ******/
ALTER TABLE [dbo].[PartyStates] ADD  CONSTRAINT [IX_PartyStates] UNIQUE NONCLUSTERED 
(
	[PartyStateName] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserRoles]    Script Date: 09.03.2020 22:30:53 ******/
ALTER TABLE [dbo].[UserRoles] ADD  CONSTRAINT [IX_UserRoles] UNIQUE NONCLUSTERED 
(
	[UserRoleName] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Users]    Script Date: 09.03.2020 22:30:53 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [IX_Users] UNIQUE NONCLUSTERED 
(
	[UserLogin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Characters]  WITH CHECK ADD  CONSTRAINT [FK_Characters_Users] FOREIGN KEY([PlayerID])
REFERENCES [dbo].[Users] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Characters] CHECK CONSTRAINT [FK_Characters_Users]
GO
ALTER TABLE [dbo].[Parties]  WITH CHECK ADD  CONSTRAINT [FK_Parties_PartyStates] FOREIGN KEY([PartyState])
REFERENCES [dbo].[PartyStates] ([PartyStateID])
GO
ALTER TABLE [dbo].[Parties] CHECK CONSTRAINT [FK_Parties_PartyStates]
GO
ALTER TABLE [dbo].[Parties]  WITH CHECK ADD  CONSTRAINT [FK_Parties_Users_Master] FOREIGN KEY([MasterID])
REFERENCES [dbo].[Users] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parties] CHECK CONSTRAINT [FK_Parties_Users_Master]
GO
ALTER TABLE [dbo].[PartyPlayers]  WITH CHECK ADD  CONSTRAINT [FK_PartyPlayers_Characters] FOREIGN KEY([CharacterID])
REFERENCES [dbo].[Characters] ([CharacterID])
GO
ALTER TABLE [dbo].[PartyPlayers] CHECK CONSTRAINT [FK_PartyPlayers_Characters]
GO
ALTER TABLE [dbo].[PartyPlayers]  WITH CHECK ADD  CONSTRAINT [FK_PartyPlayers_Parties] FOREIGN KEY([PartyID])
REFERENCES [dbo].[Parties] ([PartyID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PartyPlayers] CHECK CONSTRAINT [FK_PartyPlayers_Parties]
GO
ALTER TABLE [dbo].[PartyPlayers]  WITH CHECK ADD  CONSTRAINT [FK_PartyPlayers_Users] FOREIGN KEY([PlayerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[PartyPlayers] CHECK CONSTRAINT [FK_PartyPlayers_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_UserRoles] FOREIGN KEY([UserRoleID])
REFERENCES [dbo].[UserRoles] ([UserRoleID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_UserRoles]
GO
/****** Object:  StoredProcedure [dbo].[AddChar]    Script Date: 09.03.2020 22:30:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddChar] 
	@player_id int,
	@char_name nvarchar(50),
	@info_xml xml,
	@states_xml xml,
	@magic_xml xml,
	@inventory_xml xml
AS
BEGIN
	INSERT INTO Characters(PlayerID, CharName, InfoXML, StatesXML, MagicXML, InventoryXML)
	VALUES (@player_id,	@char_name,	@info_xml,	@states_xml, @magic_xml, @inventory_xml)
END

GO
/****** Object:  StoredProcedure [dbo].[AddPlayerAtParty]    Script Date: 09.03.2020 22:30:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddPlayerAtParty] 
	@party_id int,
	@player_id int,
	@char_id int
AS
BEGIN
	INSERT PartyPlayers(PartyID, PlayerID, CharacterID)
	VALUES(@party_id, @player_id, @char_id)
END

GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 09.03.2020 22:30:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUser] 
	@user_login nvarchar(50),
	@user_password nvarchar(50)
AS
BEGIN
	INSERT INTO Users(UserLogin, UserPassword, UserRoleID)
	VALUES (@user_login, @user_password, 0)
END

GO
/****** Object:  StoredProcedure [dbo].[CreateParty]    Script Date: 09.03.2020 22:30:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateParty] 
	@party_name nvarchar(50),
	@master_id int
AS
BEGIN
	INSERT Parties(PartyName, MasterID, PartyState)
	VALUES(@party_name, @master_id, 0)
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllChar]    Script Date: 09.03.2020 22:30:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllChar] 
AS
BEGIN
	SELECT CharacterID, UserLogin, CharName, InfoXML, StatesXML, MagicXML, InventoryXML FROM Characters, Users
	WHERE Characters.PlayerID = Users.UserID
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllParties]    Script Date: 09.03.2020 22:30:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllParties] 
	
AS
BEGIN
	SELECT PartyID, PartyName, UserLogin, PartyState FROM Parties, Users
	WHERE Parties.MasterID = Users.UserID
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllPlayerFromParty]    Script Date: 09.03.2020 22:30:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllPlayerFromParty] 
	@party_id int
AS
BEGIN
	SELECT PartyPlayers.PlayerID, UserLogin, PartyPlayers.CharacterID, CharName
	FROM PartyPlayers, Users, Characters
	WHERE PartyPlayers.PartyID = @party_id 
	AND PartyPlayers.PlayerID = Users.UserID 
	AND PartyPlayers.CharacterID = Characters.CharacterID
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 09.03.2020 22:30:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllUsers]

AS
BEGIN
	SELECT UserID, UserLogin, UserPassword, UserRoleName
	FROM Users, UserRoles
	WHERE Users.UserRoleID = UserRoles.UserRoleID
END

GO
/****** Object:  StoredProcedure [dbo].[GetCharByID]    Script Date: 09.03.2020 22:30:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetCharByID] 
	@char_id int
AS
BEGIN
	SELECT CharacterID, UserLogin, CharName, InfoXML, StatesXML, MagicXML, InventoryXML FROM Characters, Users
	WHERE CharacterID = @char_id AND Characters.PlayerID = Users.UserID
END

GO
/****** Object:  StoredProcedure [dbo].[GetPartyById]    Script Date: 09.03.2020 22:30:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPartyById] 
	@party_id int
AS
BEGIN
	SELECT PartyID, PartyName, UserLogin, PartyState FROM Parties, Users
	WHERE Parties.PartyID = @party_id AND Parties.MasterID = Users.UserID
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserInfoByLogin]    Script Date: 09.03.2020 22:30:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserInfoByLogin] 
	@user_login nvarchar(50)
AS
BEGIN
	SELECT UserID, UserLogin, UserPassword, UserRoleName
	FROM Users, UserRoles
	WHERE UserLogin = @user_login AND Users.UserRoleID = UserRoles.UserRoleID
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserRoles]    Script Date: 09.03.2020 22:30:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserRoles]
	@user_id int
AS
BEGIN
	SELECT UserRoleName
	FROM Users, UserRoles
	WHERE UserID = @user_id AND Users.UserRoleID >= UserRoles.UserRoleID
END

GO
/****** Object:  StoredProcedure [dbo].[RemoveChar]    Script Date: 09.03.2020 22:30:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RemoveChar] 
	@char_id int
AS
BEGIN
	DELETE FROM PartyPlayers
	WHERE PartyPlayers.CharacterID = @char_id

	DELETE FROM Characters
	WHERE CharacterID = @char_id
END

GO
/****** Object:  StoredProcedure [dbo].[RemoveParty]    Script Date: 09.03.2020 22:30:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RemoveParty] 
	@party_id int
AS
BEGIN
	DELETE FROM PartyPlayers
	WHERE PartyID = @party_id

	DELETE FROM Parties
	WHERE PartyID = @party_id
END

GO
/****** Object:  StoredProcedure [dbo].[RemovePlayerFromParty]    Script Date: 09.03.2020 22:30:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RemovePlayerFromParty] 
	@party_id int,
	@char_id int
AS
BEGIN
	DELETE FROM PartyPlayers
	WHERE PartyID = @party_id AND CharacterID = @char_id
END

GO
/****** Object:  StoredProcedure [dbo].[RemoveUser]    Script Date: 09.03.2020 22:30:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RemoveUser]
	@user_id int
AS
BEGIN
	DELETE FROM PartyPlayers
	WHERE PlayerID = @user_id

	DELETE FROM Characters
	WHERE Characters.PlayerID = @user_id

	DELETE FROM Parties
	WHERE Parties.MasterID = @user_id

	DELETE FROM Users
	WHERE UserID = @user_id
END

GO
/****** Object:  StoredProcedure [dbo].[SetPartyState]    Script Date: 09.03.2020 22:30:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SetPartyState] 
	@party_id int,
	@state_id int
AS
BEGIN
	UPDATE Parties
	SET PartyState = @state_id
	WHERE PartyID = @party_id
END

GO
/****** Object:  StoredProcedure [dbo].[SetUserRole]    Script Date: 09.03.2020 22:30:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SetUserRole] 
	@user_id int,
	@role int
AS
BEGIN
	UPDATE Users
	SET UserRoleID = @role
	WHERE UserID = @user_id
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateChar]    Script Date: 09.03.2020 22:30:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateChar] 
	@char_id int,
	@char_name nvarchar(50),
	@info_xml xml,
	@states_xml xml,
	@magic_xml xml,
	@inventory_xml xml
AS
BEGIN
	UPDATE Characters
	SET CharName = @char_name, InfoXML = @info_xml, StatesXML = @states_xml, 
		MagicXML = @magic_xml, InventoryXML = @inventory_xml
	WHERE CharacterID = @char_id
END

GO
USE [master]
GO
ALTER DATABASE [CSoDnDP] SET  READ_WRITE 
GO
