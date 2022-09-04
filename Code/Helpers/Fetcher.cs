using Code.Objects;
using Code.Helpers;
using Code.Libs;

using Microsoft.Extensions.Caching.Memory;

namespace Code.Helpers {

    public interface IFetchObj<T> {
        public Task<T> Fetch(bool forceNew = false);
    }

    public class Fetcher<T> : IFetchObj<T> where T: new() {
        private readonly IObjLib<T> _objLib;
        private readonly IMemoryCache _cache;

        public Fetcher(
            IMemoryCache cache,
            IObjLib<T> objLib
        ) {
            _cache = cache;
            _objLib = objLib;
        }
        

        public async Task<T> Fetch(bool forceNew = false) {
            string cacheKey = typeof(T).ToString(); 

            if ((!_cache.TryGetValue(cacheKey, out T result)) || forceNew)
            {
                try {
                    result = await _objLib.GetObj();
                } catch (Exception e) {
                    result = new T();
                    Console.WriteLine(e.Message);
                }

                var exp = DateTime.Now.Date.AddDays(1); 
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(new DateTimeOffset(DateTime.Now.Date.AddDays(1)));
                _cache.Set(cacheKey, result, cacheEntryOptions);
            }
            return result;
        }
    }


}