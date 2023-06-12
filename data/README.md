To run EF migration where "InitialCreate" is the name to be added to the migration file:

`dotnet ef migrations add InitialCreate --startup-project ../webapi`

To deploy database:

`dotnet ef database update --startup-project ../webapi`