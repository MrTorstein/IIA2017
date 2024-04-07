create procedure GetNrOfData
@LogId int
as

select NumberOfDatapoints from LOG where LogId = @LogId

go