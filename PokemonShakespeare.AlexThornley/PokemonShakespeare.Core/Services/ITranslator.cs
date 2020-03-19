using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokemonShakespeare.Core.Services
{
    public interface ITranslator
    {
        Task<string> TranslateAsync(string text);
    }
}
