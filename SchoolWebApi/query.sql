
create database marks

use marks

create table Student
(StudentId int primary key identity (1,1),
Name nvarchar(50) not null,
Class int not null)


create table Marks
(MId int primary key,
StudentId int foreign key references Student(StudentId),
English int,
SocialScience int,
Science int,
Mathematics int)

insert into Student values 
('Akash',6),
('Ashwin',5),
('Trisha',7),
('Maya',5),
('Abdullah',9),
('Alisha',6),
('Arman',5),
('Krish',6),
('Rajesh',7),
('Sanjay',7),
('Rohan',8),
('Dev',8),
('Ibrahim',9),
('Tara',9),
('Deepak',7)

select * from Marks


