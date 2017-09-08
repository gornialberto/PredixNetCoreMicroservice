using netCoreWebApi.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netCoreWebApi.DataServices
{
    public interface IKeyValueService
    {
        /// <summary>
        /// Get Value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        KeyValue GetValue(string key);

        /// <summary>
        /// Set Value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        KeyValueResponse SetValue(KeyValue keyValue);

        /// <summary>
        /// Get all the Key Value pairs
        /// </summary>
        /// <returns></returns>
        IEnumerable<KeyValue> GetAll();

        /// <summary>
        /// Delete a Key Value pair
        /// </summary>
        /// <param name="key"></param>
        KeyValueResponse DeleteKey(string key);
    }
}
