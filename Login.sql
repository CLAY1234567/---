use master
go
if exists(select * from sys.databases where name='Login')
drop database Login
go
create database Login
go
use Login
go
--用户信息表
create table UserInfo
(
	UserID int identity primary key, --用户编号
	LoginNames varchar(50) not null,  --用户登录名
	Passwords varchar(50) not null,  --登录密码 
)


insert into UserInfo values('刘备','123456')
insert into UserInfo values('关羽','123789')
insert into UserInfo values('张飞','456789')

select * from UserInfo

