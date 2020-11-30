create database if not exists `keshe` CHARACTER set 'utf8mb4';
use `keshe`;

-- table TB_ReaderType
create table `TB_ReaderType` (
	`rdType` SmallInt PRIMARY KEY, /* 读者类别【主键】 */
	`rdTypeName` Nvarchar(20) unique not null, /* 读者类别名称【唯一、非空】 */
	`CanLendQty` int, /* 可借书数量 */
	`CanLendDay` int, /* 可借书天数 */
	`CanContinueTimes` int, /* 可续借的次数 */
	`PunishRate` float, /* 罚款率（元/天） */
	`DateValid` SmallInt not null default 0 /* 证书有效期（年）【非空，0表示永久有效】 */
);

-- table TB_Reader
create table `TB_Reader` (
	`rdID` int PRIMARY KEY, /* 读者编号/借书证号【主键】 */
	`rdName` nvarchar(20), /* 读者姓名 */
	`rdSex` nchar(2), /* 性别：男/女 */
	`rdType` SmallInt not null, /* 读者类别【外键TB_ReaderType】 */
	`rdDept` nvarchar(20), /* 单位代码/单位名称 */
	`rdPhone` nvarchar(25), /* 电话号码 */
	`rdEmail` nvarchar(25), /* 电子邮箱 */
	`rdDateReg` datetime, /* 读者登记日期/办证日期 */
	`rdPhoto` MediumBlob, /* 读者照片 */
	`rdStatus` nchar(2), /* 证件状态，3个：有效、挂失、注销 */
	`rdBorrowQty` Int default 0, /* 已借书数量（缺省值0） */
	`rdPwd` nchar(32) default '202CB962AC59075B964B07152D234B70', /* 读者密码（初值123），32bit MD5加密存储 */
	`rdAdminRoles` SmallInt, /* 管理角色：(第一位)借书证管理、(第二位)图书管理、(第三位)借阅管理、(第四位)系统管理，可组合 */
	FOREIGN KEY(`rdType`) REFERENCES `TB_ReaderType`(`rdType`) /* 表级约束 */
);

-- table TB_Book
CREATE TABLE `TB_Book` (
	`bkID` int PRIMARY KEY, /* 图书序号【标识列，主键】 */
	`bkCode` Nvarchar(20), /* 图书编号或条码号（前文中的书号） */
	`bkName` Nvarchar(50), /* 书名 */
	`bkAuthor` Nvarchar(30), /* 作者 */
	`bkPress` Nvarchar(50), /* 出版社 */
	`bkDatePress` datetime, /* 出版日期 */
	`bkISBN` Nvarchar(15), /* ISBN书号 */
	`bkCatalog` Nvarchar(30), /* 分类号（如：TP316-21/123） */
	`bkLanguage` SmallInt, /* 语言：0-中文，1-英文，2-日文，3-俄文，4-德文，5-法文 */
	`bkPages` Int, /* 页数 */
	`bkPrice` DECIMAL(5,2), /* 价格 */
	`bkDateIn` DateTime, /* 入馆日期 */
	`bkBrief` Text, /* 内容简介 */
	`bkCover` MediumBlob, /* 图书封面照片 */
	`bkStatus` NChar(2) /* 图书状态：在馆、借出、遗失、变卖、销毁 */
);

-- table TB_Borrow
CREATE TABLE `TB_Borrow` (
	`BorrowID` Numeric(12,0) PRIMARY KEY, /* 借书顺序号【主键】 */
	`rdID` int, /* 读者序号【外键TB_Reader】 */
	`bkID` int, /* 图书序号【外键TB_Book】 */
	`ldContinueTimes` int default 0, /* 续借次数（第一次借时，记为0） */
	`ldDateOut` DateTime, /* 借书日期 */
	`ldDateRetPlan` DateTime, /* 应还日期 */
	`ldDateRetAct` DateTime, /* 实际还书日期 */
	`ldOverDay` Int, /* 超期天数 */
	`ldOverMoney` DECIMAL(5,2), /* 超期金额（应罚款金额） */
	`ldPunishMoney` DECIMAL(5,2), /* 罚款金额 */
	`lsHasReturn` Bit default 0, /* 是否已经还书，缺省为0-未还 */
	`OperatorLend` Nvarchar(20), /* 借书操作员 */
	`OperatorRet` Nvarchar(20), /* 还书操作员 */
	FOREIGN KEY(`rdID`) REFERENCES `TB_Reader`(`rdID`), /* 表级约束 */
	FOREIGN KEY(`bkID`) REFERENCES `TB_Book`(`bkID`) /* 表级约束 */
);

-- default table TB_ReaderType
insert into `TB_ReaderType` values(0,'未指定',1,1,1,0.50,1);
insert into `TB_ReaderType` values(1,'专科生',8,30,1,0.05,3);
insert into `TB_ReaderType` values(2,'本科生',8,30,1,0.05,4);
insert into `TB_ReaderType` values(3,'硕士研究生',8,30,1,0.05,3);
insert into `TB_ReaderType` values(4,'博士研究生',8,30,1,0.05,4);
insert into `TB_ReaderType` values(5,'教师',12,60,2,0.05,0);

-- default table TB_Reader
insert into `TB_Reader` values
(0, '用户已被移除', '男', 0, '', '', '', '2000-01-01', null, '注销', 0, '202CB962AC59075B964B07152D234B70', 0),
(2020001, 'whalechoi', '男', 2, 'Yangtze University', '12345678901', 'cj1369636717@gmail.com', '2018-09-01', null, '有效', 0, '202CB962AC59075B964B07152D234B70', 1);

-- default table TB_Book
insert into `TB_Book` values
(0, '', '图书已被移除', '', '', '2000-01-01', '', '', 0, 0, 0.00, '2000-01-01', '', null, '销毁');

-- trigger TB_ReaderType
delimiter //
create trigger `TB_ReaderType` before delete on `TB_ReaderType`
for each row
begin
	update `TB_Reader` set `rdType` = 0 where `rdType` = old.rdType;
end //
delimiter ;

-- trigger TB_Reader
delimiter //
create trigger `TB_Reader` before delete on `TB_Reader`
for each row
begin
	update `TB_Borrow` set `rdID` = 0 where rdID = old.rdID;
end //
delimiter ;

-- trigger TB_Book
delimiter //
create trigger `TB_Book` before delete on `TB_Book`
for each row
begin
	update `TB_Borrow` set `bkID` = 0 where bkID = old.bkID;
end //
delimiter ;
