using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netCoreWebApi.DomainModel
{
    /// <summary>
    /// KeyValue
    /// </summary>
    public class KeyValue
    {
        /// <summary>
        /// Key
        /// </summary>
        [Key]
        public string Key { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastUpdate { get; set; }
    }
}
