using Personas.Core.Model;
using Personas.Data.Enums;
using Personas.Data.Model;
using Personas.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Core
{
    public class Dal : IDisposable
    {
        public UnitOfWork Uow { get; private set; }

        public Dal(int year)
        {
            Uow = new UnitOfWork("PersonasDB.mdf", year);
        }

        public Persona GetPersona(int? idProvincia = null, Comunidad? region = null, int idPais = 1)
        {
            Genero genero = Uow.Generos.GetGenero();
            Nombres nombre = Uow.Nombres.GetNombre(genero);
            Apellidos apellido = Uow.Apellidos.GetApellido();
            Apellidos apellido2 = Uow.Apellidos.GetApellido();
            Lugar lugar = new Lugar(Uow.Lugares.GetLugar(idProvincia, region, idPais));
            DateTime fecha = Uow.Fechas.GetFecha();

            return new Persona(1, nombre.ToString(), apellido.ToString(), apellido2.ToString(), genero, lugar, fecha);
        }

        public List<Persona> GetPersonas(int numero, int? idProvincia = null, Comunidad? region = null, int idPais = 1)
        {
            var list = new List<Persona>();
            var nombres = Uow.Nombres.GetNombres(numero);
            var apellidos = Uow.Apellidos.GetApellidos(numero);
            var lugares = Uow.Lugares.GetLugares(numero, idProvincia, region, idPais);
            for (int i = 0; i < numero; i++)
            {
                var nombre = nombres.ElementoAleatorio();
                var a1 = apellidos.ElementoAleatorio();
                var a2 = apellidos.ElementoAleatorio();
                var lugar = new Lugar(lugares.ElementoAleatorio());
                list.Add(new Persona(i + 1, nombre.ToString(), a1.ToString(), a2.ToString(), nombre.GetGenero(), lugar, Uow.Fechas.GetFecha()));
            }
            return list;
        }

        public void Dispose() => Uow.Dispose();
    }
}
