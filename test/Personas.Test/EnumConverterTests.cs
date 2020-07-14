using Personas.Domain;
using System;
using Xunit;

namespace Personas.Test
{
    public class EnumConverterTests
    {
        [Theory]
        [InlineData("Alacant", Provincia.Alicante)]
        [InlineData("La Coruña", Provincia.Acoruna)]
        [InlineData("A Coruña", Provincia.Coruna) ]
        [InlineData("Coruña", Provincia.Acoruna)]
        [InlineData("Lacoruna", Provincia.Acoruna)]
        [InlineData("Álava", Provincia.Araba)]
        [InlineData("Araba", Provincia.Araba)]
        [InlineData("Albacete", Provincia.Albacete)]
        [InlineData("Alicante", Provincia.Alicante)]
        [InlineData("Almería", Provincia.Almeria)]
        [InlineData("Asturias", Provincia.Asturias )]
        [InlineData("Asturies", Provincia.Asturias)]
        [InlineData("Ávila", Provincia.Avila )]
        [InlineData("Badajoz", Provincia.Badajoz )]
        [InlineData("Baleares", Provincia.Baleares )]
        [InlineData("Islas Baleares", Provincia.Islasbaleares )]
        [InlineData("Barcelona", Provincia.Barcelona )]
        [InlineData("Barna", Provincia.Barcelona )]
        [InlineData("Bcn", Provincia.Barcelona )]
        [InlineData("Burgos", Provincia.Burgos)]
        [InlineData("Cáceres", Provincia.Caceres )]
        [InlineData("Cadiz", Provincia.Cadiz)]
        [InlineData("Cantabria", Provincia.Cantabria)]
        [InlineData("Castellón", Provincia.Castello)]
        [InlineData("Castello", Provincia.Castello)]
        [InlineData("Ciudad Real", Provincia.Ciudadreal)]
        [InlineData("Córdoba", Provincia.Cordoba)]
        [InlineData("Cuenca", Provincia.Cuenca)]
        [InlineData("Girona", Provincia.Girona)]
        [InlineData("Gerona", Provincia.Girona)]
        [InlineData("Granada", Provincia.Granada)]
        [InlineData("Guadalajara", Provincia.Guadalajara )]
        [InlineData("Gipuzkoa", Provincia.Gipuzkoa )]
        [InlineData("Guipuzcoa", Provincia.Gipuzkoa )]
        [InlineData("Huelva", Provincia.Huelva )]
        [InlineData("Huesca", Provincia.Huesca )]
        [InlineData("Jaén", Provincia.Jaen )]
        [InlineData("La Rioja", Provincia.Larioja )]
        [InlineData("Rioja", Provincia.Larioja )]
        [InlineData("Las Palmas", Provincia.Laspalmas )]
        [InlineData("Gran Canaria", Provincia.Laspalmas)]
        [InlineData("Las Palmas de Gran canaria", Provincia.Laspalmas)]
        [InlineData("León", Provincia.Leon)]
        [InlineData("Lleida  ", Provincia.Lleida )]
        [InlineData("Lérida", Provincia.Lleida )]
        [InlineData("  Lugo", Provincia.Lugo )]
        [InlineData("Madrid", Provincia.Madrid )]
        [InlineData("Mad", Provincia.Madrid )]
        [InlineData("Málaga", Provincia.Malaga )]
        [InlineData("Murcia", Provincia.Murcia )]
        [InlineData("Navarra", Provincia.Navarra )]
        [InlineData("Ourense", Provincia.Ourense )]
        [InlineData("orense", Provincia.Orense )]
        [InlineData("palencia", Provincia.Palencia )]
        [InlineData("Pontevedra ", Provincia.Pontevedra )]
        [InlineData("Salamanca ", Provincia.Salamanca )]
        [InlineData("Segoviá", Provincia.Segovia )]
        [InlineData("Sevilla", Provincia.Sevilla )]
        [InlineData("Soria", Provincia.Soria )]
        [InlineData("Tarragona", Provincia.Tarragona )]
        [InlineData("Santacruzdetenerife", Provincia.Santacruz )]
        [InlineData("Santacruz", Provincia.Santacruzdetenerife )]
        [InlineData("Tenerife", Provincia.Santacruz)]
        [InlineData("Teruel", Provincia.Teruel )]
        [InlineData("Toledo", Provincia.Toledo )]
        [InlineData("Valencia ", Provincia.Valencia )]
        [InlineData("Valladolid ", Provincia.Valladolid )]
        [InlineData("Bizkaia ", Provincia.Bizkaia )]
        [InlineData("Vizcaya ", Provincia.Bizkaia )]
        [InlineData("Zamora ", Provincia.Zamora )]
        [InlineData("Zaragoza ", Provincia.Zaragoza )]
        [InlineData("Ceuta ", Provincia.Ceuta )]
        [InlineData("Melilla ", Provincia.Melilla )]
        public void Should_convert_to_provincia(string inputText, Provincia provincia)
        {
            var converter = new EnumConverter<Provincia>(inputText);

            var result = converter.Convert();

            int id = (int)result;
            Assert.Equal((int)provincia, id);
        }

        [Theory]
        [InlineData("comunidad valenciana", Comunidad.Valencia)]
        [InlineData("Galicia", Comunidad.Galicia)]
        [InlineData("País Vasco", Comunidad.Euskadi)]
        [InlineData("Euskadi", Comunidad.Euskadi)]
        [InlineData("Castilla la mancha", Comunidad.Castillalamancha)]
        [InlineData("andalucía", Comunidad.Andalucia)]
        [InlineData("Asturias", Comunidad.Asturias)]
        [InlineData("Castilla león", Comunidad.Castillayleon)]
        [InlineData("Extremadura", Comunidad.Extremadura)]
        [InlineData("Baleares", Comunidad.Islasbaleares)]
        [InlineData("Canarias", Comunidad.Islascanarias)]
        [InlineData("Cataluña", Comunidad.Cataluna)]
        [InlineData("Cantabria", Comunidad.Cantabria)]
        [InlineData("Aragón", Comunidad.Aragon)]
        [InlineData("La Rioja", Comunidad.Larioja)]
        [InlineData("Madrid", Comunidad.Comunidaddemadrid)]
        [InlineData("Murcia", Comunidad.Regiondemurcia)]
        [InlineData("Navarra", Comunidad.Navarra)]
        [InlineData("Ceuta ", Comunidad.Ceuta)]
        [InlineData("Melilla ", Comunidad.Melilla)]
        public void Should_convert_to_comunidad(string inputText, Comunidad comunidad)
        {
            var converter = new EnumConverter<Comunidad>(inputText);

            var result = converter.Convert();

            int id = (int)result;
            Assert.Equal((int)comunidad, id);
        }

        [Theory]
        [InlineData("alacante")]
        [InlineData("Leone")]
        [InlineData("cualquier texto")]
        public void Should_not_convert_to_provincia(string inputText)
        {
            var converter = new EnumConverter<Provincia>(inputText);

            Assert.Throws<ConversionException>(() => converter.Convert());
        }

        [Fact]
        public void Should_throw_error_when_incorrect_input()
        {
            Assert.Throws<ArgumentNullException>(() => new EnumConverter<Provincia>(null));
            Assert.Throws<ArgumentNullException>(() => new EnumConverter<Comunidad>(null));
            Assert.Throws<ArgumentException>(() => new EnumConverter<Provincia>(""));
            Assert.Throws<ArgumentException>(() => new EnumConverter<Comunidad>("    "));
            Assert.Throws<ArgumentException>(() => new EnumConverter<Provincia>("x"));
            Assert.Throws<ArgumentException>(() => new EnumConverter<Comunidad>("  y"));
        }
    }
}
