CREATE TABLE LOG
( 
	LogId                int  IDENTITY ( 0,1 )  NOT NULL ,
	NumberOfDatapoints   int  NULL ,
	PRIMARY KEY  CLUSTERED (LogId ASC),
	UNIQUE (LogId  ASC)
)
go

CREATE TABLE SENSOR
( 
	SensorId             int  IDENTITY ( 0,1 )  NOT NULL ,
	SensorType           varchar(20)  NULL ,
	Unit                 varchar(20)  NOT NULL ,
	LogId                int  NULL ,
	PRIMARY KEY  CLUSTERED (SensorId ASC),
	UNIQUE (SensorId  ASC),
	 FOREIGN KEY (LogId) REFERENCES LOG(LogId)
)
go

CREATE TABLE DATAPOINT
( 
	DatapointId          int  IDENTITY ( 0,1 )  NOT NULL ,
	Value                float  NOT NULL ,
	LogTime              datetime  NOT NULL ,
	SensorId             int  NULL ,
	Unit                 varchar(20)  NOT NULL ,
	LogId                int  NULL ,
	PRIMARY KEY  CLUSTERED (DatapointId ASC),
	UNIQUE (DatapointId  ASC),
	 FOREIGN KEY (SensorId) REFERENCES SENSOR(SensorId),
	 FOREIGN KEY (LogId) REFERENCES LOG(LogId)
)
go

CREATE TABLE STATS
( 
	StatisticsId         int  IDENTITY ( 0,1 )  NOT NULL ,
	Mean                 float  NULL ,
	Min                  float  NULL ,
	Max                  float  NULL ,
	StandardDiviation    float  NULL ,
	Median               float  NULL ,
	LogId                int  NULL ,
	PRIMARY KEY  CLUSTERED (StatisticsId ASC),
	UNIQUE (StatisticsId  ASC),
	 FOREIGN KEY (LogId) REFERENCES LOG(LogId)
)
go

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

create procedure GetNrOfData
@LogId int
as

select NumberOfDatapoints from LOG where LogId = @LogId

go

create procedure AddDatapoint
@Value float,
@SensorId int
as

	declare
		@Unit varchar(20),
		@LogId int

	select @Unit = Unit from SENSOR where SensorId = @SensorId
	select @LogId = LogId from SENSOR where SensorId = @SensorId

	insert into DATAPOINT (Value, LogTime, SensorId, Unit, LogId)
		values (@Value, GETDATE(), @SensorId, @Unit, @LogId)

go

create procedure GetSensors
as

	select * from SENSOR

go

create procedure AddSensor
@SensorType varchar(20),
@Unit varchar(20),
@LogId int
as

insert into SENSOR (SensorType, Unit, LogId)
values (@SensorType, @Unit, @LogId)

go

create procedure AddLog
as
begin
	insert into LOG (NumberOfDatapoints) values (0)
end
go

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

create procedure UpdateMean
@LogId int
as
begin
	set nocount on;

	declare
		@Value float,
		@NrDatapoints int,
		@Mean float

	select @Value = sum(Value) from DATAPOINT where LogId = @LogId
	select @NrDatapoints = NumberOfDatapoints from LOG where LogId = @LogId
	set @Mean = @Value / cast(@NrDatapoints as float)
	update STATS set Mean = @Mean where LogId = @LogId
end
go

create procedure UpdateMedian
@LogId int
as
begin
	declare
		@Median float,
		@NrDatapoint int
	
	select @NrDatapoint = NumberOfDatapoints from LOG where LogId = @LogId

	select @Median = avg(1.0 * value) from (
		select value FROM DATAPOINT where LogId = @LogId
		order by value
		offset (@NrDatapoint - 1) / 2 rows
		fetch next 1 + (1 - @NrDatapoint % 2) rows only
	) as temp;

	update STATS set Median = @Median where LogId = @LogId

end
go

create procedure UpdateMin
@LogId int
as
begin
	set nocount on;

	declare
		@Min float

	select @Min = min(Value) from DATAPOINT where LogId = @LogId
	update STATS set Min = @Min where LogId = @LogId
end
go

create procedure UpdateSD
@LogId int
as
begin
	set nocount on;

	declare
		@Mean float,
		@Top float,
		@NrDatapoints int,
		@SD float

	select @Mean = Mean from STATS where LogId = @LogId
	select @Top = sum(power(Value - @Mean, 2)) from DATAPOINT where LogId = @LogId
	select @NrDatapoints = NumberOfDatapoints from LOG where LogId = @LogId
	set @SD = sqrt(@Top / cast(@NrDatapoints as float))

	update STATS set StandardDiviation = @SD where LogId = @LogId
end
go

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