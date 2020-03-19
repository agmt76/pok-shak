using PokemonLib.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokemonLib
{
    public interface IPokemonClient
    {
        Task<PokemonDto> GetPokemonAsync(string name);

        Task<PokemonSpeciesDto> GetPokemonSpeciesAsync(string name, LanguageCode language = LanguageCode.en);
    }
}
