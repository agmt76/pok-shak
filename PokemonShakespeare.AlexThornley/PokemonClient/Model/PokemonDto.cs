using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonLib.Model
{
    public class PokemonDto
    {
        public PokemonDto(string name, string species)
        {
            Name = name;
            Species = species;
        }

        public string Name { get; }

        public string Species { get; }
    }
}
