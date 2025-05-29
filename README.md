--- Visual Studio 2022 ---
project template: ASP.NET Core Web API
[x] place solutioon and project in the same directory
framework: .NET 8.0
[x] configurate for https
[x] enable Open API Support (swagger)
[x] use controllers (for MVC...)

--- view ->  SQL Server Object Explorer --- 
localdb\MSSQLLocalDb -> new Querry
<magic>make the database</magic>
(sorról sorra - kivéve a create table és insert into, azok mehetnek egybe) 

--- to package manager console ---
(Tools -> NuGet Package Manager -> Package Manager Console)
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Microsoft.EntityFrameworkCore.Tools

Scaffold-DbContext "_MyConnectionString_" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context _MyDbContext_ -DataAnnotations
(a myconnectionstring az adatbázis lenyitása után, a properties-nél jelenik meg)
(a "_MyDbContext_" helyett lehet bármi, csak meg kell jegyezni!)

--- to appsettings.json: ---
"ConnectionStrings": {
    "DefaultConnection": "_MyConnectionString_"
  },

--- to program.cs ---
(builder elé)
var connectionString = builder.Configuration
	.GetConnectionString("DefaultConnection");
builder.Services
	.AddDbContext<_MyDbContext_>
	(opt => opt.UseSqlServer(connectionString));

builder.Services.AddCors(
    options => options.AddDefaultPolicy(
        builder => builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()));

// add this BEFORE app.UseHttpsRedirection();
app.UseCors();
	
--- Controllers forlder -> Add -> new scaffolded item... ---

-> API Controller with actions using EF ->
model class::: _MyModel_
dbcontext class::: _MyDbContext_
controller name::: _MyModel_s (default)
