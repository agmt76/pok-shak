using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokemonShakespeare.Core.Services
{
    public interface IPokemonService
    {
        Task<string> PokemonSpeciesAsync(string pokemonName);

        Task<string> FlavorTextAsync(string speciesName);
    }
}
