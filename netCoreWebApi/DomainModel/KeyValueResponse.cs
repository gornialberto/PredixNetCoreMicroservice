using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netCoreWebApi.DomainModel
{
    /// <summary>
    /// Enumerator for the response
    /// </summary>
    public enum KeyValueResponse
    {
        Created,
        Updated,
        Deleted,
        NotFound,
        NotCreated
    }
}
