
### NuGet
Microsoft.EntityFrameworkCore by Microsoft
Microsoft.EntityFrameworkCore.Design 
Microsoft.EntityFrameworkCore.Tools
Npgsql.EntityFrameworkCore.PostgreSQL

# CRIA AS MIGRATIONS
$ dotnet ef migrations add InitialCreate
# ATUALIZA DATABASE
$ dotnet ef database update
# AJUSTANDO TABELA
$ dotnet ef migrations add Atualizacaousuario