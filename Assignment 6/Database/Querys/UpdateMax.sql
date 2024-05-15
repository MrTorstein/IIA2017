create procedure UpdateMax
@LocationId int
as
begin
	set nocount on;

	declare
		@Max float

	select @Max = max(Value) from Datapoint where LocationId = @LocationId
	update Statistic set Max = @Max where LocationId = @LocationId
end
go