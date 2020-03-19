using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonLib.Model
{
    public class PokemonSpeciesDto
    {
        public PokemonSpeciesDto(string name, string flavorText)
        {
            Name = name;
            FlavorText = flavorText;
        }

        public string Name { get; }

        public string FlavorText { get; }
    }
}
