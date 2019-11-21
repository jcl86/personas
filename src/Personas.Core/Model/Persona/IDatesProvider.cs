using System;

namespace Personas.Core
{
    public interface IDatesProvider
    {
        int AvaliableMinimunYear { get; }
        int AvaliableMaximunYear { get; }
        DateTime CurrentDate { get; }
        DateTime GetRandomBirthDate(IRandomProvider randomProvider);
    }
}
