How to configure and launch the application.


Requirements:
- .NET Core 5,
- nodeJS,
- Microsoft SQL Server
- IIS


To launch the project follow these steps:

1. Open the soultion in Visual Studio and install all the packages for backend.
2. Configure database in appsettings.json.
2. Launch the project using IIS and call the 'seedDatabase' endpoint. This will fill up the database with mocked data from the file 'warehouses.json'.
3. Open terminal in the folder 'frontend' and run 'npm i' to install all the packages for the frontend.
4. Run 'npm start'.
5. Project is running