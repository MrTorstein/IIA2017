create procedure UpdateMean
@LogId int
as
begin
	set nocount on;

	declare
		@Value float,
		@NrDatapoints int,
		@Mean float

	select @Value = sum(Value) from DATAPOINT where LogId = @LogId
	select @NrDatapoints = NumberOfDatapoints from LOG where LogId = @LogId
	set @Mean = @Value / cast(@NrDatapoints as float)
	update STATS set Mean = @Mean where LogId = @LogId
end
go