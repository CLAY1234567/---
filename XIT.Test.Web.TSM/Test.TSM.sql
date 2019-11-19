use master
go

create database ShopManagement
go

use ShopManagement
go

create table ShopInfo
(
	Shop_Id int primary key identity(1,1), --�̵�id
	Shop_Name varchar(50) not null, --�̵�����
	Shop_Address varchar(50) not null, --�̵��ַ
	Shop_DoorNo varchar(20) not null, --�̵����ƺ�
	Shop_Owner varchar(20) not null, --�̵�ӵ����
	Shop_Type Varchar(20) not null, --�̵�����
	Remark Varchar(500)
)

insert into ShopInfo values ('̹��ר����','·����ת','1231','����','�����ؾ�')
insert into ShopInfo values ('�ɻ�ר����','·����ת','1232','������','���Ϸɵ�')
insert into ShopInfo values ('�γ�ר����','����ֱ��','1233','������','�����ؾ�')
insert into ShopInfo values ('���ר����','���ſ�����','1234','���Ĵ�','��������')
insert into ShopInfo values ('��Ьר����','����ׯ��200��','1235','���崸','�����װ')