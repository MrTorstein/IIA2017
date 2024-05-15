create procedure AddDatapoint
@Value float,
@Unit varchar(20),
@Location varchar(20)
as

	declare
		@LocationId int

	if @Location not in (select Description from Location)
		exec AddLocation @Location;
	
	select @LocationId = LocationId from Location where Description = @Location

	insert into Datapoint (Value, Unit, Time, LocationId)
		values (@Value, @Unit, GETDATE(), @LocationId)

go