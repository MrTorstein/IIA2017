create procedure UpdateMedian
@LocationId int
as
begin
	declare
		@Median float,
		@NrDatas int
	
	select @NrDatas = NumberOfDatapoints from Location where LocationId = @LocationId

	select @Median = avg(1.0 * Value) from (
		select Value from Datapoint where LocationId = @LocationId
		order by Value
		offset (@NrDatas - 1) / 2 rows
		fetch next 1 + (1 - @NrDatas % 2) rows only
	) as temp;

	update Statistic set Median = @Median where LocationId = @LocationId

end
go