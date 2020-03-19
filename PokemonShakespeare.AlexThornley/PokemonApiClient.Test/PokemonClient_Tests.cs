using NUnit.Framework;
using PokemonLib;
using System.Threading.Tasks;

namespace PokemonLib.Test
{
    public class PokemonClient_Tests
    {
        [Test]
        public async Task GetPokemon()
        {
            var client = new PokemonClient();
            var b = await client.GetPokemonAsync("bulbasaur");

            Assert.AreEqual("bulbasaur", b.Name);
            Assert.AreEqual("bulbasaur", b.Species);
        }

        [Test]
        public async Task GetPokemonSpecies()
        {
            var client = new PokemonClient();
            var b = await client.GetPokemonSpeciesAsync("bulbasaur");

            Assert.AreEqual("bulbasaur", b.Name);
            Assert.IsTrue(b.FlavorText.StartsWith("Bulbasaur can be seen napping"));
        }
    }
}