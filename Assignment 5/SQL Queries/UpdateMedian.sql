create procedure UpdateMedian
@LogId int
as
begin
	declare
		@Median float,
		@NrDatapoint int
	
	select @NrDatapoint = NumberOfDatapoints from LOG where LogId = @LogId

	select @Median = avg(1.0 * value) from (
		select value FROM DATAPOINT where LogId = @LogId
		order by value
		offset (@NrDatapoint - 1) / 2 rows
		fetch next 1 + (1 - @NrDatapoint % 2) rows only
	) as temp;

	update STATS set Median = @Median where LogId = @LogId

end
go