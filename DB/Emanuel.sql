CREATE DATABASE Emanuel;
go
USE Emanuel;
go
CREATE TABLE Zone
(
	[ZoneId] [INT] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ZoneNumber] [int] NOT NULL,
);
go

CREATE TABLE MaritalStatus

(
	[MaritalStatusId] [INT] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Status] [VARCHAR](100) NOT NULL

);
go
CREATE TABLE MinisteralLevel

(
	[MinisteralLevelId] [INT] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[MinisteralLevel] [VARCHAR](100) NOT NULL,

);
go
CREATE TABLE Pastor

(
	[PastorId] [INT] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] [VARCHAR](100) NOT NULL,
	[LastName] [VARCHAR](100) NOT NULL,
	[BirthDay] [DATETIME] NOT NULL,
	[Code] [INT] NOT NULL,
	[CellNumber] [VARCHAR](60),
	[PresentationDate] [DATETIME] NOT NULL,
	[MaritalStatusId] int NOT NULL CONSTRAINT fk_Pastor_MaritalStatus FOREIGN KEY REFERENCES [dbo].[MaritalStatus]([MaritalStatusId]),
	[MinisteralLevelId] int NOT NULL CONSTRAINT fk_Pastor_MinisteralLevel FOREIGN KEY REFERENCES [dbo].[MinisteralLevel]([MinisteralLevelId]),
	
);
go
CREATE TABLE Church
(
	[ChurchId] [INT] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] [VARCHAR](60) NOT NULL,
	[Adress] [VARCHAR](400) NOT NULL,
    [ZoneId] int NOT NULL CONSTRAINT fk_Church_zone FOREIGN KEY REFERENCES [dbo].[Zone]([ZoneId]),
    [PastorId] int NOT NULL CONSTRAINT fk_Church_pastor FOREIGN KEY REFERENCES [dbo].[Pastor]([PastorId]),
);

go
CREATE TABLE MeetingType

(
	[MeetingTypeId] [INT] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[MeetingType] [VARCHAR](100) NOT NULL,

);	
go
CREATE TABLE Meeting

(
	[MeetingId] [INT] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Title] [VARCHAR](100) NOT NULL,
	[Description] [VARCHAR](100) NOT NULL,
	[StarMeetingDate] [DATETIME] NOT NULL,
	[EndMeetingDate] [DATETIME] NOT NULL,
	[MeetingTypeId] int NOT NULL CONSTRAINT fk_meeting_MeetingType FOREIGN KEY REFERENCES [dbo].[MeetingType]([MeetingTypeId]),

);	
go
CREATE TABLE Observation

(
	[ObservationId] [INT] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Observation] [VARCHAR](100) NOT NULL,

);
go
CREATE TABLE Meeting_Pastor

(
	[ID] [INT] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ChecInTime] [DATETIME] NULL,
	[DepartTime] [DATETIME] NULL,
	[Comment][VARCHAR](400)null,
	[ObservationId] int NOT NULL CONSTRAINT fk_meetingPastor_Observation FOREIGN KEY REFERENCES [dbo].[Observation]([ObservationId]),
	[PastorId] int NOT NULL CONSTRAINT fk_meetingPastor_Pastor FOREIGN KEY REFERENCES [dbo].[Pastor]([PastorId]),
	[MeetingId] int NOT NULL CONSTRAINT fk_meetingPastor_Meeting FOREIGN KEY REFERENCES [dbo].[Meeting]([MeetingId]),

);	

		