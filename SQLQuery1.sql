use date_Clube;

--create table AllPlayer(
--ID int not null IDENTITY (1, 1) primary key,
--Name nvarchar(300) not null,
--phone nvarchar(100) not null,
--Email nvarchar(100) not null,
--sex varchar(50) not null,
--dateStart date not null,
--dateFin date not null,
--typeSport nvarchar(300) not null,
--Insurance bit not null,
--monye float,
--rest float not null,
--picture image, 
--)

--DELETE FROM AllPlayer

--insert into AllPlayer values('rachid','0625021314','test@test.com','F','01-02-2020','03-03-2020','GYM','1','150.00','50','47245325635635');
--insert into AllPlayer values('rachid','0625021314','test@test.com','F','01-02-2020','03-03-2020','aerobic','1','150.00','50','47245325635635');
--insert into AllPlayer values('rachid','0625021314','test@test.com','F','01-02-2020','01-01-2020','kik','1','150.00','50','47245325635635');



--create table Sports(
--ID int not null primary key identity(1,1),
--NameSport nvarchar(100)
--)

--insert into Sports values('1','GYM')

--create table Admin(ID int not null primary key identity(1,1), UserName nvarchar(150), pass varchar(150),access varchar(100))

--select * from Sports

--insert into Sports values('GYM'),('Aerobic'),('taekwondo'),('fokontak')


--insert into admin values ('Admin','Admin123')

--create table email(Email_S varchar(100),Email_A varchar(100),Passwordmail_A varchar(100),Port int,Smtp varchar(100),subjecte varchar(150),messag varchar(800));

--insert into email values('win1997.2020@gmail.com','win1997.2020@gmail.com','win19972020','587','smtp.gmail.com','Gym AbdAlie',
--'<style type="text/css">body {margin: 0; padding: 0; min-width: 100%!important;}.content {width: 100%; max-width: 600px;} </style>
--</head><body yahoo bgcolor="#33cccc"><table width="100%" bgcolor="#33cccc" border="0" cellpadding="0" cellspacing="0">
--<tr><td><table class="content" align="center" cellpadding="0" cellspacing="0" border="0"><tr><td><h1>Hello!</h1></td></tr></table>
--</td></tr></table></body></html>')

--select * from AllPlayer where Name like '%%'

--insert into AllPlayer values('ahmad bn hamid','0512254648','ahmad@test.com','F','02-02-2020','02-03-2020','aerobic','0','150.00','654684549846+54');


--select * from sports where not NameSport='GYM' and not NameSport='Aerobic' 

--insert into sports values ('3','taekwondo'),('4','fokontak')


--select count(*) from AllPlayer where dateFin<getdate()

--select count(*) from AllPlayer where dateFin>getdate()



--select * from AllPlayer

--select typeSport from AllPlayer where not typeSport='GYM' and not typeSport='Aerobic' Group by typeSport

--select typeSport,count(typeSport) as sum from AllPlayer Group by typeSport order by typeSport asc


--select * from AllPlayer where typeSport='GYM'

--select * from AllPlayer where typeSport='Aerobic'

--select * from AllPlayer where not typeSport='GYM' and not typeSport='Aerobic'


--update email set Email_S='',Email_A='',Passwordmail_A='',Port='',Smtp='',subjecte='',messag=''


--update Admin set UserName='',pass=''



--select * from AllPlayer

--select sum(monye) from AllPlayer where typeSport='GYM' and DATEPART(month,getdate()) < DATEPART(month,datefin)

--select sum(monye) from AllPlayer where typeSport='Aerobic' and DATEPART(month,getdate()) < DATEPART(month,datefin)

--select sum(monye) from AllPlayer where not typeSport='GYM' and not typeSport='Aerobic' and DATEPART(month,getdate()) < DATEPART(month,datefin)



select sum(monye) from AllPlayer where typeSport='GYM' and  getdate() < datefin

	

