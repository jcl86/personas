using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Personas.Core;
using Personas.Core.Model;
using Personas.Data.Enums;

namespace Personas.Test
{
    [TestClass]
    public class PersonasTest
    {
        [TestMethod]
        public void ObtenerUnNombre(int num)
        {
            Dal d = new Dal(2018);
            var n1 = d.Uow.Nombres.GetNombre(Genero.Male);
            var n2 = d.Uow.Nombres.GetNombre(Genero.Female);
        }

        [TestMethod]
        public void ObtenerUnApellido(int num)
        {
            Dal d = new Dal(2018);  
            var n = d.Uow.Apellidos.GetApellido();
        }

        [TestMethod]
        public void Obtener100Nombres(int num)
        {
            Dal d = new Dal(2018);
            var n = d.Uow.Nombres.GetNombres(100, Genero.Male);
        }

        [TestMethod]
        public void Obtener2000Nombres(int num)
        {
            Dal d = new Dal(2018);
            var n1 = d.Uow.Nombres.GetNombres(1000, Genero.Male);
            var n2 = d.Uow.Nombres.GetNombres(1000, Genero.Female);
        }

        [TestMethod]
        public void Obtener10000Nombres(int num)
        {
            Data.Repositories.FechasRepository.EdadMinima = 18;
              Dal d = new Dal(1960);
            var n1 = d.Uow.Nombres.GetNombres(5000, Genero.Male);
            var n2 = d.Uow.Nombres.GetNombres(5000, Genero.Female);
        }

        [TestMethod]
        public void Obtener100Apellidos()
        {
            Dal d = new Dal(2018);
            var n = d.Uow.Apellidos.GetApellidos(100);
        }

        [TestMethod]
        public void Obtener2000Apellidos(int num)
        {
            Dal d = new Dal(2018);
            var n1 = d.Uow.Apellidos.GetApellidos(1000);
            var n2 = d.Uow.Apellidos.GetApellidos(1000);
        }

        [TestMethod]
        public void ObtenerUnaFecha()
        {
            Dal d = new Dal(2018);
            var fecha = d.Uow.Fechas.GetFecha();
        }

        [TestMethod]
        public void Obtener100Fechas()
        {
            Dal d = new Dal(2018);
            var fecha = d.Uow.Fechas.GetFechas(100);
        }

        [TestMethod]
        public void Obtener5000Fechas()
        {
            Dal d = new Dal(2018);
            var fecha = d.Uow.Fechas.GetFechas(5000);
        }

        [TestMethod]
        public void Obtener100LugaresEnAsturias()
        {
            Dal d = new Dal(2018);
            var lista = d.Uow.Lugares.GetLugares(100, Comunidad.Asturias);
        }

        [TestMethod]
        public void ObtenerPersonasUna()
        {
            Dal d = new Dal(2018);
            var persona = d.GetPersona();
        }

        [TestMethod]
        public void ObtenerPersonaMurciana()
        {
            Dal d = new Dal(2018);
            var persona = d.GetPersona(null, Comunidad.Murcia);
        }

        [TestMethod]
        public void ObtenerPersonas100()
        {
            Dal d = new Dal(2018);
            var personas = d.GetPersonas(100);
        }

        [TestMethod]
        public void ObtenerPersonasBizkainos100()
        {
            Dal d = new Dal(2018);
            var personas = d.GetPersonas(100, 48);
            var p = personas.ToList();
        }

        [TestMethod]
        public void ObtenerPersonas1000()
        {
            Dal d = new Dal(2018);
            var personas = d.GetPersonas(1000);
        }
        [TestMethod]
        public void ObtenerPersonas10000()
        {
            Dal d = new Dal(2018);
            var personas = d.GetPersonas(10000);
            var str = personas.First().NombreCompleto;
        }
    }
}
