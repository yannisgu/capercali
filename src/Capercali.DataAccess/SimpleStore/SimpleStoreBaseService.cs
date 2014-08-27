using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
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
    }
}