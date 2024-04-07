create procedure AddSensor
@SensorType varchar(20),
@Unit varchar(20),
@LogId int
as

insert into SENSOR (SensorType, Unit, LogId)
values (@SensorType, @Unit, @LogId)

go