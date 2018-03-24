using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Entity;
using TestApp.Server.SQL;

namespace TestApp.Server.Service
{
    public class EntityService<T> where T : EntityObject
    {
        public T GetById(int id)
        {
            SQLEntityDataAccess<T> data = new SQLEntityDataAccess<T>();
            return data.GetById(id);
        }

        public List<T> GetByTemplate(T template)
        {
            SQLEntityDataAccess<T> data = new SQLEntityDataAccess<T>();
            return data.GetByTemplate(template);
        }

        public List<T> GetAll()
        {
            SQLEntityDataAccess<T> data = new SQLEntityDataAccess<T>();
            return data.GetAll();
        }
    }
}
