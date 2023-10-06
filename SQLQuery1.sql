create database Final
Go
use Final
Go
Create table Formats
(
FormatId int primary key identity,
FormatName nvarchar(100)
)
Go
insert into Formats values ('Test Match')
insert into Formats values ('ODI Match')
insert into Formats values ('T20 Match')

Create table Players
(
PlayerId int primary key identity,
PlayerName nvarchar(100),
DateOfBirth datetime,
Phone nvarchar(100),
Picture nvarchar(max),
MaritalStatus bit
)
Go
Create table SeriesEntry
(
SeriesEntryId int primary key identity,
PlayerId  int references Players(PlayerId),
FormatId  int references Formats(FormatId)
)
Go