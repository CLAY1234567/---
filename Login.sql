use master
go
if exists(select * from sys.databases where name='Login')
drop database Login
go
create database Login
go
use Login
go
--�û���Ϣ��
create table UserInfo
(
	UserID int identity primary key, --�û����
	LoginNames varchar(50) not null,  --�û���¼��
	Passwords varchar(50) not null,  --��¼���� 
)


insert into UserInfo values('����','123456')
insert into UserInfo values('����','123789')
insert into UserInfo values('�ŷ�','456789')

select * from UserInfo

