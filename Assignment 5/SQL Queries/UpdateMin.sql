create procedure UpdateMin
@LogId int
as
begin
	set nocount on;

	declare
		@Min float

	select @Min = min(Value) from DATAPOINT where LogId = @LogId
	update STATS set Min = @Min where LogId = @LogId
end
go