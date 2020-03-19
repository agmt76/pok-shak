using PokemonShakespeare.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokemonShakespeare.Infrastructure
{
    public class ShakespeareTranslator : ITranslator
    {
        public Task<string> TranslateAsync(string text)
        {
            // the shakespeare api listed in the docs is not free
            // mock the result

            return Task.FromResult("MOCK SHAKESPEARE - " + text);
        }
    }
}
