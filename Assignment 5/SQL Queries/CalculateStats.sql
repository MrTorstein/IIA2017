create trigger CalculateStats
on DATAPOINT
after insert, delete
as
begin
	set nocount on;

	declare
		@LogId int,
		@Value float,
		@NrDatapoints int

	select @LogId = LogId from inserted
	exec UpdateMean @LogId
	exec UpdateMin @LogId
	exec UpdateMax @LogId
	exec UpdateSD @LogId
	exec UpdateMedian @LogId

	select @LogId = LogId from deleted
	exec UpdateMean @LogId
	exec UpdateMin @LogId
	exec UpdateMax @LogId
	exec UpdateSD @LogId
	exec UpdateMedian @LogId

	
end
go