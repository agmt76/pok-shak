using PokemonLib;
using PokemonShakespeare.Core.Services;
using System;
using System.Threading.Tasks;

namespace PokemonShakespeare.Infrastructure
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonClient client;

        public PokemonService(IPokemonClient client)
        {
            this.client = client;
        }

        public async Task<string> FlavorTextAsync(string speciesName)
        {
            var species = await client.GetPokemonSpeciesAsync(speciesName);
            return species.FlavorText;
        }

        public async Task<string> PokemonSpeciesAsync(string pokemonName)
        {
            var pokemon = await client.GetPokemonAsync(pokemonName);
            return pokemon.Species;
        }
    }
}
