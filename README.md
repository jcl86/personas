# Personas

API Rest para obtención de datos de personas aleatorios.

````
- Dni

- Nombre

- Apellidos

- Sexo

- Municipio

- Fecha de nacimiento
````


*De momento, solo hay soporte para nombres españoles*


# Migraciones de Base de Datos

````
dotnet ef migrations add NombreMigracion --project .\src\Personas.Data\Personas.Data.csproj --startup-project .\src\Personas.Host\Personas.Host.csproj -v
dotnet ef database update --project .\src\Personas.Data\Personas.Data.csproj --startup-project .\src\Personas.Host\Personas.Host.csproj -v
dotnet ef database update --project .\src\Personas.Data\Personas.Data.csproj --startup-project .\test\Personas.FunctionalTests\Personas.FunctionalTests.csproj -v
````


Datos obtenidos del [INE](https://www.ine.es/dyngs/INEbase/es/operacion.htm?c=Estadistica_C&cid=1254736177009&menu=resultados&idp=1254734710990#!tabs-1254736195454) y leídos a través de una base de datos Sqlite