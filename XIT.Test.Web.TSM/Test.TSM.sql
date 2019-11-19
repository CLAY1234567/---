use master
go

create database ShopManagement
go

use ShopManagement
go

create table ShopInfo
(
	Shop_Id int primary key identity(1,1), --商店id
	Shop_Name varchar(50) not null, --商店名称
	Shop_Address varchar(50) not null, --商店地址
	Shop_DoorNo varchar(20) not null, --商店门牌号
	Shop_Owner varchar(20) not null, --商店拥有人
	Shop_Type Varchar(20) not null, --商店类型
	Remark Varchar(500)
)

insert into ShopInfo values ('坦克专卖店','路口左转','1231','王大锤','重型载具')
insert into ShopInfo values ('飞机专卖店','路口右转','1232','王二锤','天上飞的')
insert into ShopInfo values ('轿车专卖店','出门直走','1233','王三锤','轻型载具')
insert into ShopInfo values ('火箭专卖店','出门看上面','1234','王四锤','大型炮仗')
insert into ShopInfo values ('拖鞋专卖店','大孙庄东200米','1235','王五锤','网红服装')