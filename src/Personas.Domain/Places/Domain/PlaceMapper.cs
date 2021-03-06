﻿using Personas.Shared;

namespace Personas.Domain
{
    public class PlaceMapper
    {
        private readonly Place lugar;

        public PlaceMapper(Place lugar)
        {
            this.lugar = lugar;
        }

        public PlaceViewModel Map()
        {
            return new PlaceViewModel()
            {
                City = lugar.City,
                Province = lugar.Province,
                Region = new RegionMapper(lugar.Region).Map(),
                Country = lugar.Country,
                CityType = lugar.CityType(),
                MaleDemonym = lugar.Demonym(Gender.Male),
                FemaleDemonym = lugar.Demonym(Gender.Female)
        };
        }
    }
}
