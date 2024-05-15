
CREATE TABLE Datapoint
( 
	DataId               int  IDENTITY ( 0,1 )  NOT NULL ,
	Value                float  NOT NULL ,
	Unit                 varchar(20)  NOT NULL ,
	Time                 datetime  NULL ,
	LocationId           int  NOT NULL 
)
go

CREATE TABLE Location
( 
	LocationId           int  IDENTITY ( 0,1 )  NOT NULL ,
	Description          varchar(20)  NOT NULL ,
	NumberOfDatapoints	 int NULL
)
go

CREATE TABLE Statistic
( 
	Mean                 float  NULL ,
	Max                  float  NULL ,
	Min                  float  NULL ,
	StandardDiviation    float  NULL ,
	LocationId           int  NOT NULL 
)
go

create procedure UpdateMin
@LocationId int
as
begin
	set nocount on;

	declare
		@Min float

	select @Min = min(Value) from Datapoint where LocationId = @LocationId
	update Statistic set Min = @Min where LocationId = @LocationId
end
go

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

create procedure UpdateMean
@LocationId int
as
begin
	set nocount on;

	declare
		@Value float,
		@NrDatas int,
		@Mean float

	select @Value = sum(Value) from Datapoint where LocationId = @LocationId
	select @NrDatas = NumberOfDatapoints from Location where LocationId = @LocationId
	set @Mean = @Value / cast(@NrDatas as float)
	update Statistic set Mean = @Mean where LocationId = @LocationId
end
go

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

create trigger CalculateStats
on Datapoint
after insert, delete
as
begin
	set nocount on;

	declare
		@LocationId int

	select @LocationId = LocationId from inserted
	exec UpdateMean @LocationId
	exec UpdateMin @LocationId
	exec UpdateMax @LocationId
	exec UpdateSD @LocationId

	select @LocationId = LocationId from deleted
	exec UpdateMean @LocationId
	exec UpdateMin @LocationId
	exec UpdateMax @LocationId
	exec UpdateSD @LocationId
	
end
go

create trigger AddStats
on Location
after insert, delete
as
begin
	set nocount on;

	declare
		@InsertId int,
		@DeletedId int

		select @InsertId = LocationId from inserted
		select @DeletedId = LocationId from deleted

	insert into Statistic (LocationId) values (@InsertId)
	delete from Statistic where LocationId = @DeletedId
end
go

create procedure AddLocation
@Location varchar(20)
as
begin
	insert into Location (Description) values (@Location)
end
go

create procedure AddDatapoint
@Value float,
@Unit varchar(20),
@Location varchar(20)
as
	declare
		@LocationId int

	if @Location not in (select Description from Location)
		exec AddLocation @Location;
	
	select @LocationId = LocationId from Location where Description = @Location

	insert into Datapoint (Value, Unit, Time, LocationId)
		values (@Value, @Unit, GETDATE(), @LocationId)

go

create procedure GetLocations
as

	select Description from Location

go