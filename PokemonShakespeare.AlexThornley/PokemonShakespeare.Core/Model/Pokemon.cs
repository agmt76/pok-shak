using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonShakespeare.Core.Model
{
    public class Pokemon
    {
        public Pokemon(string name, string rawFlavorText, string shakespeareFlavorText)
        {
            Name = name;
            RawFlavorText = rawFlavorText;
            ShakespeareFlavorText = shakespeareFlavorText;
        }

        public string Name { get; }

        public string RawFlavorText { get; }

        public string ShakespeareFlavorText { get; }
    }
}
