create trigger ChangeLog
on DATAPOINT
after insert, delete
as
begin
	set nocount on;

	declare
		@LogId int,
		@NrDatapoints int

	select @LogId = LogId from inserted
	select @NrDatapoints = count(*) from DATAPOINT where LogId = @LogId
	update LOG set NumberOfDatapoints = @NrDatapoints where LogId = @LogId

	select @LogId = LogId from deleted
	select @NrDatapoints = count(*) from DATAPOINT where LogId = @LogId
	update LOG set NumberOfDatapoints = @NrDatapoints where LogId = @LogId
	
end
go