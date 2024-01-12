create Database Ayubo_DB;
use Ayubo_DB;

/*customer*/
create table Customer(Cus_ID int primary key not null,Cus_name varchar(50) not null,NIC_No varchar(20) not null,Date_of_Birth Date,Address varchar(255),Passport_No varchar(50),Licence_No varchar(20),Contact_No int);


/*driver*/
create table Driver(Driv_ID int primary key not null,Driv_name varchar(50) not null,NIC_No varchar(20) not null,Date_of_Birth date,Driv_Licence_No Varchar(50),address varchar(255),Contact_No int);


/*vehicle*/
create table Vehicle(veh_ID int primary key not null,Veh_No varchar(10) not null,Brand varchar(50),seat varchar(50),colour varchar(50),category varchar(50),Fuel_Type varchar(50));

/*vehicle type*/
create table Vehicle_type(Veh_ID int primary key not null,Name varchar(50) not null,category varchar(50),Daily_char int,Weekly_char int,Monthly_char int);

/*Rent*/
create table Rent (Rent_ID int,Cus_ID int,Driv_ID int,StartDate Date,EndDate Date,Driv_Amount int,Day_Amount int,Week_Amount int,Month_Amount int,Tota_amount int,Paid int,Balance int);


/* Hire_Day */
create table hire_daytour(hire_ID varchar(20) not null, Cus_ID int,Cus_name varchar(50) not null,Veh_ID int,Driv_ID int,Pack_amount int,Ex_Km_charge int,Wai_charge int,Start_Km int,End_Km int,Tota_amount int,Paid int,Balance int);


/* Hire_Long */

create table hire_longtour(hire_ID varchar(20) not null, Cus_ID int ,Veh_ID int,Driv_ID int,Pack_charge int,Ex_Km_charge int,Ove_charge int,Night_rate int,Start_Km int,End_Km int,Tota_amount int,Paid int,Balance int);


/*hire package*/
create table Hire_package(Pac_ID int,Pac_Type varchar(50),Veh_ID int ,Max_Km int,Ex_Km_Rate int,Max_Hou int,Pac_char int,Night_Park_Rate int,Wai_char int,Driv_Overnight_char int);



select * from hire_daytour;

insert into Hire_package values ('001','Airpot Drop','100','13500','200','12','500','150','100','1000');
insert into Hire_package values ('002','200Km','101','10000','200','12','600','150','100','1000');


insert into Vehicle_type values ('100','Jeep','Susuki','2000','5000','8000');
insert into Vehicle_type values ('101','Van','Mazda','4000','6000','9000');


insert into Vehicle values ('100','XB-2503','Susuki','5','Black','Small Car','Petrol');
insert into Vehicle values ('101','KD-2145','Mazda','7','Black','Car','Petrol');


insert into Driver values ('100','Raju','9012453678V','1990-01-01','A1457896','Jaffna','0774589632');
insert into Driver values ('101','Kamal','9512853347V','1995-06-11','B4578626','Manipay','0745689235');
insert into Driver values ('103','Vimal','9012357852V','1990-07-11','A2457899','Manipay','0764578965');


insert into Customer values ('100','Raju','954582538V','1990-01-01','Jaffna','147852N','B5745896','0771459632');
insert into Customer values ('101','Lavan','20014578962513','2001-03-05','Chunnakam','12582N','B1145866','0758926353');
insert into Customer values ('102','Isaac','9725368212V','1997-04-10','Vavuniya','32589N','B0231458','0771977456');
insert into Customer values ('103','Inthu','1995124568978','1995-12-03','Jaffna','0032145A','B125896','0758235898');


delete from hire_daytour where hire_ID='';