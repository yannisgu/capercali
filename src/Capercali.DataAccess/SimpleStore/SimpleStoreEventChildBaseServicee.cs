using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Akavache;
using Capercali.Entities;

namespace Capercali.DataAccess.SimpleStore
{
    public abstract class SimpleStoreEventChildBaseService<T> : SimpleStoreBaseService where T : IEntity
    {

        public SimpleStoreEventChildBaseService(bool isCache = false)
            : base(isCache)
        {
            
        }

        public async Task<IEnumerable<T>> Get(long eventId)
        {
            return await Cache.GetObject<IEnumerable<T>>(Key + eventId).Catch(Observable.Return(new List<T>()));
        }

        public async Task<long> Update(long eventId, T course)
        {
            return await UpdateItem(Key + eventId, (await Get(eventId)).ToList(), course);
        }

        public async Task Delete(long eventId, T course)
        {
            await DeleteItem(Key + eventId, (await Get(eventId)).ToList(), course);
        }


        public abstract string Key { get; }
    }
}
