using Personas.Domain;
using System;
using Xunit;

namespace Personas.Test
{
    public class EnumConverterTests
    {
        [Theory]
        [InlineData("Alacant", Province.Alicante)]
        [InlineData("La Coruña", Province.Acoruna)]
        [InlineData("A Coruña", Province.Coruna) ]
        [InlineData("Coruña", Province.Acoruna)]
        [InlineData("Lacoruna", Province.Acoruna)]
        [InlineData("Álava", Province.Araba)]
        [InlineData("Araba", Province.Araba)]
        [InlineData("Albacete", Province.Albacete)]
        [InlineData("Alicante", Province.Alicante)]
        [InlineData("Almería", Province.Almeria)]
        [InlineData("Asturias", Province.Asturias )]
        [InlineData("Asturies", Province.Asturias)]
        [InlineData("Ávila", Province.Avila )]
        [InlineData("Badajoz", Province.Badajoz )]
        [InlineData("Baleares", Province.Baleares )]
        [InlineData("Islas Baleares", Province.Islasbaleares )]
        [InlineData("Barcelona", Province.Barcelona )]
        [InlineData("Barna", Province.Barcelona )]
        [InlineData("Bcn", Province.Barcelona )]
        [InlineData("Burgos", Province.Burgos)]
        [InlineData("Cáceres", Province.Caceres )]
        [InlineData("Cadiz", Province.Cadiz)]
        [InlineData("Cantabria", Province.Cantabria)]
        [InlineData("Castellón", Province.Castello)]
        [InlineData("Castello", Province.Castello)]
        [InlineData("Ciudad Real", Province.Ciudadreal)]
        [InlineData("Córdoba", Province.Cordoba)]
        [InlineData("Cuenca", Province.Cuenca)]
        [InlineData("Girona", Province.Girona)]
        [InlineData("Gerona", Province.Girona)]
        [InlineData("Granada", Province.Granada)]
        [InlineData("Guadalajara", Province.Guadalajara )]
        [InlineData("Gipuzkoa", Province.Gipuzkoa )]
        [InlineData("Guipuzcoa", Province.Gipuzkoa )]
        [InlineData("Huelva", Province.Huelva )]
        [InlineData("Huesca", Province.Huesca )]
        [InlineData("Jaén", Province.Jaen )]
        [InlineData("La Rioja", Province.Larioja )]
        [InlineData("Rioja", Province.Larioja )]
        [InlineData("Las Palmas", Province.Laspalmas )]
        [InlineData("Gran Canaria", Province.Laspalmas)]
        [InlineData("Las Palmas de Gran canaria", Province.Laspalmas)]
        [InlineData("León", Province.Leon)]
        [InlineData("Lleida  ", Province.Lleida )]
        [InlineData("Lérida", Province.Lleida )]
        [InlineData("  Lugo", Province.Lugo )]
        [InlineData("Madrid", Province.Madrid )]
        [InlineData("Mad", Province.Madrid )]
        [InlineData("Málaga", Province.Malaga )]
        [InlineData("Murcia", Province.Murcia )]
        [InlineData("Navarra", Province.Navarra )]
        [InlineData("Ourense", Province.Ourense )]
        [InlineData("orense", Province.Orense )]
        [InlineData("palencia", Province.Palencia )]
        [InlineData("Pontevedra ", Province.Pontevedra )]
        [InlineData("Salamanca ", Province.Salamanca )]
        [InlineData("Segoviá", Province.Segovia )]
        [InlineData("Sevilla", Province.Sevilla )]
        [InlineData("Soria", Province.Soria )]
        [InlineData("Tarragona", Province.Tarragona )]
        [InlineData("Santacruzdetenerife", Province.Santacruz )]
        [InlineData("Santacruz", Province.Santacruzdetenerife )]
        [InlineData("Tenerife", Province.Santacruz)]
        [InlineData("Teruel", Province.Teruel )]
        [InlineData("Toledo", Province.Toledo )]
        [InlineData("Valencia ", Province.Valencia )]
        [InlineData("Valladolid ", Province.Valladolid )]
        [InlineData("Bizkaia ", Province.Bizkaia )]
        [InlineData("Vizcaya ", Province.Bizkaia )]
        [InlineData("Zamora ", Province.Zamora )]
        [InlineData("Zaragoza ", Province.Zaragoza )]
        [InlineData("Ceuta ", Province.Ceuta )]
        [InlineData("Melilla ", Province.Melilla )]
        public void Should_convert_to_Province(string inputText, Province Province)
        {
            var converter = new EnumConverter<Province>(inputText);

            var result = converter.Convert();

            int id = (int)result;
            Assert.Equal((int)Province, id);
        }

        [Theory]
        [InlineData("Comunidad valenciana", AutonomousCommunity.Valencia)]
        [InlineData("Galicia", AutonomousCommunity.Galicia)]
        [InlineData("País Vasco", AutonomousCommunity.Euskadi)]
        [InlineData("Euskadi", AutonomousCommunity.Euskadi)]
        [InlineData("Castilla la mancha", AutonomousCommunity.Castillalamancha)]
        [InlineData("andalucía", AutonomousCommunity.Andalucia)]
        [InlineData("Asturias", AutonomousCommunity.Asturias)]
        [InlineData("Castilla león", AutonomousCommunity.Castillayleon)]
        [InlineData("Extremadura", AutonomousCommunity.Extremadura)]
        [InlineData("Baleares", AutonomousCommunity.Islasbaleares)]
        [InlineData("Canarias", AutonomousCommunity.Islascanarias)]
        [InlineData("Cataluña", AutonomousCommunity.Cataluna)]
        [InlineData("Cantabria", AutonomousCommunity.Cantabria)]
        [InlineData("Aragón", AutonomousCommunity.Aragon)]
        [InlineData("La Rioja", AutonomousCommunity.Larioja)]
        [InlineData("Madrid", AutonomousCommunity.Comunidaddemadrid)]
        [InlineData("Murcia", AutonomousCommunity.Regiondemurcia)]
        [InlineData("Navarra", AutonomousCommunity.Navarra)]
        [InlineData("Ceuta ", AutonomousCommunity.Ceuta)]
        [InlineData("Melilla ", AutonomousCommunity.Melilla)]
        public void Should_convert_to_AutonomousCommunity(string inputText, AutonomousCommunity AutonomousCommunity)
        {
            var converter = new EnumConverter<AutonomousCommunity>(inputText);

            var result = converter.Convert();

            int id = (int)result;
            Assert.Equal((int)AutonomousCommunity, id);
        }

        [Theory]
        [InlineData("alacante")]
        [InlineData("Leone")]
        [InlineData("cualquier texto")]
        public void Should_not_convert_to_Province(string inputText)
        {
            var converter = new EnumConverter<Province>(inputText);

            Assert.Throws<ConversionException>(() => converter.Convert());
        }

        [Fact]
        public void Should_throw_error_when_incorrect_input()
        {
            Assert.Throws<ArgumentNullException>(() => new EnumConverter<Province>(null));
            Assert.Throws<ArgumentNullException>(() => new EnumConverter<AutonomousCommunity>(null));
            Assert.Throws<ArgumentException>(() => new EnumConverter<Province>(""));
            Assert.Throws<ArgumentException>(() => new EnumConverter<AutonomousCommunity>("    "));
            Assert.Throws<ArgumentException>(() => new EnumConverter<Province>("x"));
            Assert.Throws<ArgumentException>(() => new EnumConverter<AutonomousCommunity>("  y"));
        }
    }
}
