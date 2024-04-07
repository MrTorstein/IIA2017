create procedure UpdateSD
@LogId int
as
begin
	set nocount on;

	declare
		@Mean float,
		@Top float,
		@NrDatapoints int,
		@SD float

	select @Mean = Mean from STATS where LogId = @LogId
	select @Top = sum(power(Value - @Mean, 2)) from DATAPOINT where LogId = @LogId
	select @NrDatapoints = NumberOfDatapoints from LOG where LogId = @LogId
	set @SD = sqrt(@Top / cast(@NrDatapoints as float))

	update STATS set StandardDiviation = @SD where LogId = @LogId
end
go