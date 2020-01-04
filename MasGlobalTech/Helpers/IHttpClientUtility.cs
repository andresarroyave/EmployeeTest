using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasGlobalTech.Helpers
{
    public interface IHttpClientUtility
    {
        Task<IEnumerable<T>> GetListAsync<T>(string uri);
    }
}
