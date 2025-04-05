go
use SistemaLoginDB;
go

create table Usuario
(
	Id int primary key identity(1,1),
	Nome nvarchar (50) not null,
	Email nvarchar (50) not null,
	Senha nvarchar (20)not null
);

