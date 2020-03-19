using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PokemonShakespeare.Core.Model;
using PokemonShakespeare.Core.Services;

namespace PokemonShakespeare.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonShakespeareService service;

        private readonly IMemoryCache memoryCache;

        public PokemonController(IPokemonShakespeareService service, IMemoryCache memoryCache)
        {
            this.service = service;
            this.memoryCache = memoryCache;
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<Pokemon> Get([FromRoute] string name)
        {
            // MemoryCache is thread safe
            // There is a race condition, where 2 simultaneous requests get a cache miss and both populate the cache
            // This will do no harm, just waste a bit of cpu and network traffic
            // Locking would solve this, with a slight overhead on every cache miss

            bool exists = memoryCache.TryGetValue(name, out Pokemon pokemon);
            if (!exists)
            {
                pokemon = await service.GetPokemonAsync(name);
                memoryCache.Set(name, pokemon, TimeSpan.FromHours(1));
            }

            return pokemon;
        }
    }
}
