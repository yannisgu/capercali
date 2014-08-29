using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Akavache;
using Capercali.Entities;


namespace Capercali.DataAccess.SimpleStore
{
    public class SimpleStoreBaseService
    {
        private readonly IBlobCache cache;

        public SimpleStoreBaseService(IBlobCache cache = null)
        {
            BlobCache.ApplicationName = "Capercali";
            this.cache = cache;
            if (cache == null)
            {
                this.cache = BlobCache.LocalMachine;
            }
            
        }

        public IBlobCache Cache
        {
            get { return cache; }
        }

        protected async Task UpdateItem<T>(string key, List<T> list, T item) where T : IEntity
        {
            var index = (list.FindIndex(c => c.Id == item.Id));
            if (index >= 0)
            {
                list[index] = item;
            }
            else
            {
                var lastOrDefault = list.OrderBy(e => e.Id).LastOrDefault();
                item.Id = lastOrDefault != null ? lastOrDefault.Id + 1 : 1;
                list.Add(item);
            }
            await Cache.InsertObject(key, list);
        }


        protected async Task DeleteItem<T>(string key, List<T> list, T item) where T : IEntity
        {
            var index = (list.FindIndex(c => c.Id == item.Id));
            if (index >= 0)
            {
                list.RemoveAt(index);
            }
            await Cache.InsertObject(key, list);
        }
 
    }
}