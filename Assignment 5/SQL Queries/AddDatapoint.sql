create procedure AddDatapoint
@Value float,
@SensorId int
as

	declare
		@Unit varchar(20),
		@LogId int

	select @Unit = Unit from SENSOR where SensorId = @SensorId
	select @LogId = LogId from SENSOR where SensorId = @SensorId

	insert into DATAPOINT (Value, LogTime, SensorId, Unit, LogId)
		values (@Value, GETDATE(), @SensorId, @Unit, @LogId)

go