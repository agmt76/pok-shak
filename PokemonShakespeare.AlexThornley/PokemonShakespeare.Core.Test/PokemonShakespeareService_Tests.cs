using Moq;
using NUnit.Framework;
using PokemonShakespeare.Core.Services;
using System;
using System.Threading.Tasks;

namespace PokemonShakespeare.Core.Test
{
    public class Tests
    {
        const string Name = "foo pokemon";
        const string Species = "foo species";
        const string Flavor = "foo flavor";
        const string Translation = "foo translation";

        const string BadName = "pokemon does not exist";
        const string ExceptionMsg = "foo exception";

        IPokemonShakespeareService service;

        [SetUp]
        public void Init()
        {
            var pokemonService = new Mock<IPokemonService>();
            pokemonService.Setup(x => x.PokemonSpeciesAsync(Name)).ReturnsAsync(Species);
            pokemonService.Setup(x => x.PokemonSpeciesAsync(BadName)).Throws(new Exception(ExceptionMsg));
            pokemonService.Setup(x => x.FlavorTextAsync(Species)).ReturnsAsync(Flavor);

            var translator = new Mock<ITranslator>();
            translator.Setup(x => x.TranslateAsync(Flavor)).ReturnsAsync(Translation);

            service = new PokemonShakespeareService(pokemonService.Object, translator.Object);
        }

        [Test]
        public async Task GetPokemon()
        {
            var pokemon = await service.GetPokemonAsync(Name);

            Assert.AreEqual(Name, pokemon.Name);
            Assert.AreEqual(Flavor, pokemon.RawFlavorText);
            Assert.AreEqual(Translation, pokemon.ShakespeareFlavorText);
        }

        [Test]
        public void GetPokemon_ThrowsAnyException()
        {
            var ex = Assert.ThrowsAsync<Exception>(async () => await service.GetPokemonAsync(BadName));
            Assert.AreEqual(ExceptionMsg, ex.Message);
        }
    }
}