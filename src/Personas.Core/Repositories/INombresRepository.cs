﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Personas.Core
{
    public interface INombresRepository
    {
        Task<IEnumerable<Nombre>> GetNombres(int numero, Genero genero = null, Cultura cultura = Cultura.Spanish);
    }
}
