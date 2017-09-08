using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using netCoreWebApi.DomainModel;
using netCoreWebApi.DataLayer;

namespace netCoreWebApi.DataServices
{
    /// <summary>
    /// Key Value Service
    /// </summary>
    public class KeyValueService : IKeyValueService
    {
        private readonly EFDataContext _context;

        public KeyValueService(EFDataContext context)
        {
            _context = context;
        }

        public KeyValueResponse DeleteKey(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KeyValue> GetAll()
        {
            //easy one just return all the items in the DB
            return _context.KeyValues.ToList();
        }

        public KeyValue GetValue(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                KeyValue existingItem = null;

                existingItem = _context.KeyValues.Where(itm => itm.Key == key).FirstOrDefault();

                if (existingItem != null)
                {
                    return existingItem;
                }
            }

            return null;
        }

        public KeyValueResponse SetValue(KeyValue keyValue)
        {
            KeyValueResponse response;

            if (keyValue != null && !string.IsNullOrEmpty(keyValue.Key))
            {
                KeyValue existingItem = null;

                existingItem = _context.KeyValues.Where(itm => itm.Key == keyValue.Key).FirstOrDefault();

                if (existingItem != null)
                {
                    //update it
                    existingItem.Value = keyValue.Value;
                    keyValue.LastUpdate = DateTime.UtcNow;
                    existingItem.LastUpdate = keyValue.LastUpdate;
                    _context.SaveChanges();
                    response = KeyValueResponse.Updated;
                }
                else
                {
                    //just add it
                    keyValue.LastUpdate = DateTime.UtcNow;
                    _context.KeyValues.Add(keyValue);
                    _context.SaveChanges();
                    response = KeyValueResponse.Created;
                }
            }
            else
            {
                response = KeyValueResponse.NotCreated;
            }

            return response;
        }
    }
}
