**Personas**

API para obtención de datos de personas aleatorios.

.NET Framework 4.5

*De momento, solo hay soporte para nombres españoles*

---

## Como utilizar la librería

Agregar las siguientes referencias en el proyecto:

1. Personas.Core.dll
2. Personas.Data.dll
3. Util.Core.dll

Copiar el fichero *PersonasDB.mdf* en el proyecto, y hacer que se copie directamente en la carpeta raiz *(/debug o /release)*

Adicionalmente, es conveniente instalar el paquete Nuget para compatibilidad con ValueTuple *System.ValueTuple*

---

## Ejemplo de funcionamiento

---

```csharp

//Año que se considera la actualidad
int referenceYear = 2018; 

//Para marcar los límites inferior y superior en las fechas obtenidas
Data.Repositories.FechasRepository.EdadMinima = 18;
Data.Repositories.FechasRepository.EdadMaxima = 65;

//Instancia objeto de acceso a datos
Dal d = new Dal(referenceYear);

//Obtiene 100 personas de Bizkaia
d.GetPersonas(100, 48);

//Obtiene 100 personas de Aragón
d.GetPersonas(100, null, Comunidad.Aragon);

//Obtiene 100 nombres femeninos
d.Uow.Nombres.GetNombres(100, Genero.Femenino)

//Obtiene 100 apellidos
d.Uow.Nombres.GetApellidos(100)

//Obtiene 100 lugares en Asturias
d.Uow.Lugares.GetLugares(100, Comunidad.Asturias);

```
