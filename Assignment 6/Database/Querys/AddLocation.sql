create procedure AddLocation
@Location varchar(20)
as
begin
	insert into Location (Description) values (@Location)
end
go