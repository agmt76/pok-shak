using Moq;
using NUnit.Framework;
using PokemonLib;
using PokemonLib.Model;
using System.Threading.Tasks;

namespace PokemonShakespeare.Infrastructure.Test
{
    public class Tests
    {

        [Test]
        public async Task GetSpecies()
        {
            string name = "foo pokemon";
            string species = "foo species";
            var pokemon = new PokemonDto(name, species);

            var client = new Mock<IPokemonClient>();
            client.Setup(x => x.GetPokemonAsync(name)).ReturnsAsync(pokemon);

            var service = new PokemonService(client.Object);

            string result = await service.PokemonSpeciesAsync(name);

            Assert.AreEqual(species, result);
        }

        [Test]
        public async Task GetFlavorText()
        {
            string species = "foo species";
            string flavor = "foo flavor";
            var pokemonSpecies = new PokemonSpeciesDto(species, flavor);

            var client = new Mock<IPokemonClient>();
            client.Setup(x => x.GetPokemonSpeciesAsync(species, It.IsAny<LanguageCode>())).ReturnsAsync(pokemonSpecies);

            var service = new PokemonService(client.Object);

            string result = await service.FlavorTextAsync(species);

            Assert.AreEqual(flavor, result);
        }
    }
}