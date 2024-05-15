create procedure UpdateMean
@LocationId int
as
begin
	set nocount on;

	declare
		@Value float,
		@NrDatas int,
		@Mean float

	select @Value = sum(Value) from Datapoint where LocationId = @LocationId
	select @NrDatas = NumberOfDatapoints from Location where LocationId = @LocationId
	set @Mean = @Value / cast(@NrDatas as float)
	update Statistic set Mean = @Mean where LocationId = @LocationId
end
go