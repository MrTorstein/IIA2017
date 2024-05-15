create trigger CalculateStats
on Location
after insert, update, delete
as
begin
	set nocount on;

	declare
		@LocationId int

	select @LocationId = isnull(LocationId, 0) from inserted
	exec UpdateMean @LocationId
	exec UpdateMin @LocationId
	exec UpdateMax @LocationId
	exec UpdateSD @LocationId
	exec UpdateMedian @LocationId

	select @LocationId = isnull(LocationId, 0) from deleted
	exec UpdateMean @LocationId
	exec UpdateMin @LocationId
	exec UpdateMax @LocationId
	exec UpdateSD @LocationId
	exec UpdateMedian @LocationId

	
end
go