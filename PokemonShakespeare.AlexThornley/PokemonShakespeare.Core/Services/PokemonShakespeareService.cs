using PokemonShakespeare.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokemonShakespeare.Core.Services
{
    public class PokemonShakespeareService : IPokemonShakespeareService
    {
        public PokemonShakespeareService(IPokemonService pokemonService, ITranslator translator)
        {
            this.pokemonService = pokemonService;
            this.translator = translator;
        }

        private readonly IPokemonService pokemonService;

        private readonly ITranslator translator;

        public async Task<Pokemon> GetPokemonAsync(string name)
        {
            string species = await pokemonService.PokemonSpeciesAsync(name);
            string flavor = await pokemonService.FlavorTextAsync(species);
            string shakespeare = await translator.TranslateAsync(flavor);

            return new Pokemon(name, flavor, shakespeare);
        }
    }
}
