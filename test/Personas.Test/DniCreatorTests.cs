using Personas.Core;
using System;
using Xunit;

namespace Personas.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Should_create_a_valid_DNI()
        {
            var dni = new Dni(new TestRandomProvider());

            var numberLength = dni.Number.ToString().Length;

            Assert.Equal(11111111, numberLength);
            Assert.Equal("11111111H", dni.ToString());
        }
    }
}
