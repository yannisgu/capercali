using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Capercali.Entities;
using Microsoft.Data.OData;
using NDatabase;
using NDatabase.Api;

namespace Capercali.DataAccess.NDatabase
{
    public class NDatabaseBaseService
    {
        public IOdb OpenDb()
        {
            var odb =  OdbFactory.Open("Data9.db");
            
            return odb;
        }


        protected Task Run(Action<IOdb> func)
        {
            return Task.Run(() =>
            {
                try
                {
                    using (var db = OpenDb())
                    {
                        func(db);
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            });
        }

        protected Task<T> Run<T>(Func<IOdb, T> func)
        {
            return Task.Run(() =>
            {
                try
                {
                    using (var db = OpenDb())
                    {
                        return func(db);
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return default(T);
                }
            });
        }
    }
}