﻿using Microsoft.EntityFrameworkCore;
using Personas.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Data.Repositories
{
    public class LugaresRepository : Repository, ILugaresRepository
    {
        private readonly IRandomProvider randomProvider;

        public LugaresRepository(DataContext context, IRandomProvider randomProvider) : base(context)
        {
            this.randomProvider = randomProvider;
        }

        private Lugar CreateLugar(Localidades localidad)
        {
            var regionBD = localidad.Provincias.Regiones;
            var idiomaOficial = new Idioma(regionBD.IdiomaOficial.Id, regionBD.IdiomaOficial.Nombre);
            Idioma idiomaCooficial = null;
            if (regionBD.IdIdiomaCooficial.HasValue)
            { 
                idiomaCooficial = new Idioma(regionBD.IdiomaCooficial.Id, regionBD.IdiomaCooficial.Nombre);
            }
            var region = new Region(regionBD.Id, regionBD.Nombre, regionBD.NumeroHabitantes,
                regionBD.Densidad, regionBD.GentilicioMasculino, regionBD.GentilicioFemenino,
                idiomaOficial, idiomaCooficial);
            return new Lugar(localidad.Id, localidad.Nombre,
                localidad.Provincias.NombreProvincia, region, regionBD.Pais.Nombre,
                localidad.Tipo, localidad.Provincias.GentilicioMasculino,
                localidad.Provincias.GentilicioFemenino);
        }

        public async Task<IEnumerable<Lugar>> GetAllLugares()
        {
            var localidades = await context.Localidades.IncludeLugares().ToListAsync();

            var result = new List<Lugar>();
            foreach (var localidad in localidades)
            {
                result.Add(CreateLugar(localidad));
            }
            return result;
        }

        private async Task<IEnumerable<Lugar>> GetLugares(int numero, Provincia? provincia = null,
            Comunidad? region = null, int idPais = 1)
        {
            var localidades = context.Localidades.Where(x => x.Provincias.Regiones.IdPais == idPais);

            if (region.HasValue)
                localidades = localidades.Where(x => x.Provincias.IdRegion == (int)region);

            if (provincia.HasValue)
                localidades = localidades.Where(x => x.IdProvincia == (int)provincia);

            var listaDeListas = new List<IEnumerable<Localidades>>()
            {
                await localidades.Metropolies().ToListAsync(),
                await localidades.BigCities().ToListAsync(),
                await localidades.BigTowns().ToListAsync(),
                await localidades.Towns().ToListAsync(),
                await localidades.Villages().ToListAsync()
            };

            var removedLists = listaDeListas.RemoveAll(x => !x.Any());

            List<double> distribucion = new List<double>() { 0.45, 0.20, 0.20, 0.10, 0.05 };
            foreach(int i in Enumerable.Range(0, removedLists))
            {
                distribucion.RemoveAt(distribucion.Count - 1);
            }

            var result = new List<Lugar>();
            for (int i = 0; i < distribucion.Count; i++)
            {
                for (int j = 0; j < numero * distribucion[i]; j++)
                {
                    if (listaDeListas[i].Any())
                    {
                        var localidad = listaDeListas[i].RandomElement(randomProvider);
                        result.Add(CreateLugar(localidad));
                    }
                }
            }
            return result;
        }

        public async Task<IEnumerable<Lugar>> GetLugares(int numero)
            => await GetLugares(numero, null, null);
        public async Task<IEnumerable<Lugar>> GetLugares(int numero, Comunidad region)
            => await GetLugares(numero, null, region);
        public async Task<IEnumerable<Lugar>> GetLugares(int numero, Provincia provincia)
            => await GetLugares(numero, provincia, null);

    }
}
