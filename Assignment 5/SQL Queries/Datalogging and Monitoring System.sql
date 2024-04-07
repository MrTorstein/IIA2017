
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
