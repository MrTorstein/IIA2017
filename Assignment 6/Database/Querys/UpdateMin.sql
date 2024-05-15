create procedure UpdateMin
@LocationId int
as
begin
	set nocount on;

	declare
		@Min float

	select @Min = min(Value) from Datapoint where LocationId = @LocationId
	update Statistic set Min = @Min where LocationId = @LocationId
end
go