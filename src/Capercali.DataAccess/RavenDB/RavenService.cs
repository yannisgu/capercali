using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;

namespace Capercali.DataAccess.Services
{
    public  class RavenService
    {
        private DocumentStore store;

        public DocumentStore Store
        {
            get
            {
                return store ?? (store = GetStore());
            }
        }

        public IAsyncDocumentSession Session
        {
            get { return session ?? (session = GetSession()); }
        }

        private IAsyncDocumentSession GetSession()
        {
            return Store.OpenAsyncSession();
        }

        private DocumentStore GetStore()
        {

            var documentStore = new EmbeddableDocumentStore
            {
                DataDirectory = "Data"
            };
            documentStore.Initialize();
            return documentStore;
        }

        public IAsyncDocumentSession session;
    }
}
