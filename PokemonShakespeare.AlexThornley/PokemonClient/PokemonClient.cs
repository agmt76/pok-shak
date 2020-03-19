using PokemonLib.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonLib
{
    public class PokemonClient : IPokemonClient
    {
        #region Deserialization classes

        // These classes map directly onto the shape of the pokemon api json.
        // They are used only here for deserialization, so are kept private, to not pollute the object model

#pragma warning disable 0649        // fields never assigned to - the fields get set by reflection in Json deserialization

        private class Language
        {
            public string name;
            public string url;
        }

        private class FlavorTextEntry
        {
            public string flavor_text;
            public Language language;
        }

        private class Species
        {
            public string name;
            public FlavorTextEntry[] flavor_text_entries;
        }

        private class SpeciesRef
        {
            public string name;
            public string url;
        }

        private class Pokemon
        {
            public string name;
            public SpeciesRef species;
        }

#pragma warning restore 0649

        #endregion

        private readonly string baseUrl;

        public PokemonClient(string baseUrl) => this.baseUrl = baseUrl;

        public PokemonClient() : this("https://pokeapi.co/api/v2/") { }

        public async Task<PokemonDto> GetPokemonAsync(string name)
        {
            var pokemon = await SimpleHttp.Get<Pokemon>(baseUrl + "pokemon/" + name);
            var result = new PokemonDto(pokemon.name, pokemon.species.name);
            return result;
        }

        public async Task<PokemonSpeciesDto> GetPokemonSpeciesAsync(string name, LanguageCode language = LanguageCode.en)
        {
            var species = await SimpleHttp.Get<Species>(baseUrl + "pokemon-species/" + name);

            string lang = language.ToString();
            var flavor = species.flavor_text_entries.First(x => x.language.name == lang);

            var result = new PokemonSpeciesDto(species.name, flavor.flavor_text);

            return result;
        }
    }
}
