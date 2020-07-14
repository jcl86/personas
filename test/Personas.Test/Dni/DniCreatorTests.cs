using Personas.Domain;
using Xunit;

namespace Personas.Test
{
    public class DniCreatorTests
    {
        [Fact]
        public void Should_create_a_valid_DNI()
        {
            var dni = new Dni(new OnlyOneProvider());

            var numberLength = dni.Number.ToString().Length;

            Assert.Equal(8, numberLength);
            Assert.Equal("11111111H", dni.ToString());
        }

        [Fact]
        public void Should_create_a_concrete_DNI()
        {
            var dni = new Dni(new IncrementalProvider());

            var numberLength = dni.Number.ToString().Length;

            Assert.Equal(87654321, dni.Number);
            Assert.Equal(8, numberLength);
            Assert.Equal("87654321X", dni.ToString());
        }

        [Fact]
        public void Should_create_a_random_valid_DNI()
        {
            var dni = new Dni(new RandomProvider(new System.Random()));

            Assert.NotNull(dni.ToString());
        }
    }
}
