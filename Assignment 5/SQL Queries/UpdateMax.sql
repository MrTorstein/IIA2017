create procedure UpdateMax
@LogId int
as
begin
	set nocount on;

	declare
		@Max float

	select @Max = max(Value) from DATAPOINT where LogId = @LogId
	update STATS set Max = @Max where LogId = @LogId
end
go