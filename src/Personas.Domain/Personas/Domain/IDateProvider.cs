using System;

namespace Personas.Domain
{
    public interface IDateProvider
    {
        int AvaliableMinimunYear { get; }
        int AvaliableMaximunYear { get; }
        DateTime CurrentDate { get; }
        DateTime GetRandomBirthDate(RandomProvider randomProvider);
    }
}
