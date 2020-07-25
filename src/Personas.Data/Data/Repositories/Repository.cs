using System;

namespace Personas.Data.Repositories
{
    public class Repository : IDisposable
    {
        protected DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public void Dispose() => context.Dispose();
    }
}
