using PokemonShakespeare.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokemonShakespeare.Core.Services
{
    public interface IPokemonShakespeareService
    {
        Task<Pokemon> GetPokemonAsync(string name);
    }
}
