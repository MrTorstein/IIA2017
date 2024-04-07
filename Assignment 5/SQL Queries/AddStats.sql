create trigger AddStats
on LOG
after insert, delete
as
begin
	set nocount on;

	declare
		@insertIds int,
		@deletedIds int

		select @insertIds = LogId from inserted
		select @deletedIds = LogId from deleted

	insert into STATS (LogId) values (@insertIds)
	delete from STATS where LogId = @deletedIds
end
go