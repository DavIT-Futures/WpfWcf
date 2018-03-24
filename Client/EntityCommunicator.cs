using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Client.EntityWCFService;
using TestApp.Entity;
using System.Runtime.Serialization;

namespace TestApp.Client
{
    public static class EntityCommunicator
    {
        public static List<T> GetAll<T>() where T : EntityObject
        {
            //EntityService<T> service = new EntityService<T>();
            //List<T> result = service.GetAll();
            //return result;
            List<T> result = new List<T>();
            EntityWCFServiceClient client = new EntityWCFServiceClient();
            EntityObject[] response = client.GetAll(typeof(T).FullName);
            foreach (T item in response)
                result.Add(item);

            return result;
        }

        public static T GetById<T>(int id) where T : EntityObject
        {
            //EntityService<T> service = new EntityService<T>();
            //T result = service.GetById(id);
            //return result;
            EntityWCFServiceClient client = new EntityWCFServiceClient();
            EntityObject response = client.GetById(typeof(T).FullName, id);
            T result = response as T;
            return result;
        }

        public static List<T> GetByTemplate<T>(T template) where T : EntityObject
        {
            //EntityService<T> service = new EntityService<T>();
            //List<T> result = service.GetByTemplate(template);
            //return result;
            List<T> result = new List<T>();
            EntityWCFServiceClient client = new EntityWCFServiceClient();
            EntityObject[] response = client.GetByTemplate(typeof(T).FullName, template);
            foreach (T item in response)
                result.Add(item);

            return result;
        }
    }
}
