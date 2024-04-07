create procedure AddLog
as
begin
	insert into LOG (NumberOfDatapoints) values (0)
end
go