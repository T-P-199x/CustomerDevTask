# Customer App
Developer Task for technical test

To use [RoundhousE](https://github.com/chucknorris/roundhouse) to deploy the database, edit the `LOCAL.DBDeployment.bat` file in the root of the `Database` project, to point at your local instance of SQL Server:

```
SET server.database="[SqlServer\Instance]"
```

The database it will create is named `CustomerDevTask`, ensure that there is no database with the same name before running for the first time, or it will amend that database.

You can change the name of the database in the `.bat` file:

```
SET database.name="CustomerDevTask"
```

If the database name is chamged, then the `appsettings.json` file must be updated to reflect the database name change.

When ready to deploy run `LOCAL.DBDeployment.bat`.

# Improvements

- Redirect to the edit screen when a customer is saved rather than disabling the button. 
- A more friendly telephone validator, rather than just allowing numeric only phone numbers.
- Pagination for customer list
