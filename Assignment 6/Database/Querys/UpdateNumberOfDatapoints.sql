create trigger UpdateNumberOfDatapoints
on Datapoint
after insert, delete
as
begin
	set nocount on;

	declare
		@InsertId int,
		@DeletedId int,
		@NrDatas int

		select @InsertId = LocationId from inserted
		select @DeletedId = LocationId from deleted

		select @NrDatas = count(*) from Datapoint where LocationId = @InsertId
		update Location set NumberOfDatapoints = @NrDatas where LocationId = @InsertId
		select @NrDatas = count(*) from Datapoint where LocationId = @DeletedId
		update Location set NumberOfDatapoints = @NrDatas where LocationId = @DeletedId
end
go