using System;

namespace Personas.Domain
{
    public interface IDatesProvider
    {
        int AvaliableMinimunYear { get; }
        int AvaliableMaximunYear { get; }
        DateTime CurrentDate { get; }
        DateTime GetRandomBirthDate(RandomProvider randomProvider);
    }
}
