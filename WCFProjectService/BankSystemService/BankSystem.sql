create table Cards
(
Id int not null identity(1,1),
CardNumber bigint not null ,
Available varchar(250),
Balance varchar(250),
Name varchar(250),
UserId nvarchar(128),
primary key(Id)
)

create table Transactions
(
Id int not null identity(1,1),
UserId nvarchar(128),
Date date,
Title ntext,
Amount varchar(250),
Balance varchar(250),
primary key(Id)
)

insert into Cards values(8888888888888888,10000.00,10000.00, '',null)

create view UserCardsView
as
select 
u.Id as 'UserId',
u.UserName as 'UserName',
c.Id as 'CardId',
c.CardNumber as 'CardNumber',
c.Available as 'Available',
c.Balance as 'Balance',
c.Name as 'CardName' 
from AspNetUsers u inner join Cards c on u.Id=c.UserId

create view UsersView
as
select 
Id, 
UserName 
from AspNetUsers

create view CardsNotAssignedToUsersView
as
select 
c.Id 
,c.CardNumber
,c.Available
,c.Balance
,c.Name
,c.UserId 
from Cards c full outer join AspNetUsers u on u.Id=c.UserId

create view TransactionsView
as
select * from Transactions

create view CardsView
as
select * from Cards

