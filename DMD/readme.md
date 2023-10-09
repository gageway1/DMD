## Add Migration/Update DB
Add:

	dotnet ef migrations add migrationname --project dmd.data --startup-project dmd.web

Update:

	dotnet ef database update --project dmd.data --startup-project dmd.web