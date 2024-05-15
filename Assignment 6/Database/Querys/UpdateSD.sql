create procedure UpdateSD
@LocationId int
as
begin
	set nocount on;

	declare
		@Mean float,
		@Top float,
		@NrDatas int,
		@SD float

	select @Mean = Mean from Statistic where LocationId = @LocationId
	select @Top = sum(power(Value - @Mean, 2)) from Datapoint where LocationId = @LocationId
	select @NrDatas = NumberOfDatapoints from Location where LocationId = @LocationId
	set @SD = sqrt(@Top / cast(@NrDatas as float))

	update Statistic set StandardDiviation = @SD where LocationId = @LocationId
end
go