using NUnit.Framework;
using PokemonLib;
using PokemonShakespeare.Core.Services;
using PokemonShakespeare.Infrastructure;
using System.Net;
using System.Threading.Tasks;

namespace PokemonShakespeare.IntegrationTest
{
    public class PokemonShakespeareService_Test
    {
        private IPokemonShakespeareService service;

        [SetUp]
        public void Setup()
        {
            service = new PokemonShakespeareService(
                new PokemonService(new PokemonClient()),
                new ShakespeareTranslator()
            );
        }

        [Test]
        public async Task GetKnownPokemon()
        {
            string name = "charizard";
            string flavor = 
                "Charizard flies around the sky in search of powerful opponents.\n" +
                "It breathes fire of such great heat that it melts anything.\n" +
                "However, it never turns its fiery breath on any opponent\n" +
                "weaker than itself.";
            string shakespeare = "MOCK SHAKESPEARE - " + flavor;

            var pokemon = await service.GetPokemonAsync(name);

            Assert.AreEqual(name, pokemon.Name);
            Assert.AreEqual(flavor, pokemon.RawFlavorText);
            Assert.AreEqual(shakespeare, pokemon.ShakespeareFlavorText);
        }

        [Test]
        public void ThrowsOnGetUnknownPokemon()
        {
            string name = "unknown pokemen";
            Assert.ThrowsAsync<WebException>(async () => await service.GetPokemonAsync(name));
        }
    }
}