using System;
using Util.Core.Data;

namespace Personas.Data.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private readonly Conexion c;

        public NombresRepository Nombres { get; private set; }
        public ApellidosRepository Apellidos { get; private set; }
        public FechasRepository Fechas { get; private set; }
        public GenerosRepository Generos { get; private set; }
        public LugaresRepository Lugares { get; private set; }

        public UnitOfWork(string path, int year)
        {
            c = new Conexion(path);
            Nombres = new NombresRepository(c);
            Apellidos = new ApellidosRepository(c);
            Fechas = new FechasRepository(c, year);
            Generos = new GenerosRepository(c);
            Lugares = new LugaresRepository(c);
        }

        public void Dispose() => c.Dispose();
        
    }
}
