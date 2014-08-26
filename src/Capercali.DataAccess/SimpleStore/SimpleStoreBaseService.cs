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
        public SimpleStoreBaseService()
        {
            BlobCache.ApplicationName = "Capercali";
        }

        private Dictionary<long, Dictionary<string, FileStream>> files;


        public FileStream OpenFile(long eventId, string fileName)
        {
            FileStream file = null;
            Dictionary<string, FileStream> filesCollection;
            if (files.ContainsKey(eventId))
            {
                filesCollection = files[eventId];
            }
            else
            {
                filesCollection = new Dictionary<string, FileStream>();
                files.Add(eventId, filesCollection);
            }
            if (filesCollection.ContainsKey(fileName))
            {
                file = files[eventId][fileName];
            }
            if (file == null)
            {
                file = File.Open(eventId + "/" + fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                filesCollection.Add(fileName, file);
            }
            return file;
        }

        public void CloseFile(long eventId, string fileName)
        {
            var file = files[eventId][fileName];
            file.Close();
            files[eventId].Remove(fileName);
        }


        //protected Task Run(Action<IOdb> func)
        //{
        //    return Task.Run(() =>
        //    {
        //        try
        //        {
        //            using (var db = OpenDb())
        //            {
        //                func(db);
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            Debug.WriteLine(ex.Message);
        //        }
        //    });
        //}

        //protected Task<T> Run<T>(Func<IOdb, T> func)
        //{
        //    return Task.Run(() =>
        //    {
        //        try
        //        {
        //            using (var db = OpenDb())
        //            {
        //                return func(db);
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            Debug.WriteLine(ex.Message);
        //            return default(T);
        //        }
        //    });
        //}
    }
}