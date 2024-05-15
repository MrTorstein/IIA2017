create trigger AddStats
on Location
after insert, delete
as
begin
	set nocount on;

	declare
		@InsertIds int,
		@DeletedIds int

		select @InsertIds = LocationId from inserted
		select @DeletedIds = LocationId from deleted

	insert into Statistic (LocationId) values (@InsertIds)
	delete from Statistic where LocationId = @DeletedIds
end
go