using Personas.Domain;
using Microsoft.Extensions.Configuration;
using System;

namespace Personas.Domain
{
    public class DateProvider : IDateProvider
    {
        private readonly int yearsMin;
        private readonly int yearsMax;

        public DateProvider(IConfiguration configuration)
        {
            yearsMin = configuration.GetValue<int>("DateSettings:YearsMin");
            yearsMax = configuration.GetValue<int>("DateSettings:YearsMax");
        }

        public int AvaliableMinimunYear => CurrentDate.Year - yearsMax;
        public int AvaliableMaximunYear => CurrentDate.Year - yearsMin;
        public DateTime CurrentDate => DateTime.Today;

        public DateTime GetRandomBirthDate(RandomProvider randomProvider)
        {
            int year = randomProvider.GetNumber(AvaliableMinimunYear, AvaliableMaximunYear);
            int mes = randomProvider.GetNumber(1, 12);
            int dia;
            if (mes == 4 || mes == 6 || mes == 9 || mes == 11) dia = randomProvider.GetNumber(1, 30);
            else if (mes == 2) dia = randomProvider.GetNumber(1, 28);
            else dia = randomProvider.GetNumber(1, 31);
            return new DateTime(year, mes, dia);
        }
    }
}
