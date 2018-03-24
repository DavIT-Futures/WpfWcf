using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TestApp.Entity;
using TestApp.Server.Service;

namespace TestApp.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class EntityWCFService : IEntityWCFService
    {
        public EntityObject GetById(string typeName, int id)
        {
            return BusinessManager.Instance.GetById(typeName, id);
        }

        public List<EntityObject> GetByTemplate(string typeName, EntityObject template)
        {
            return BusinessManager.Instance.GetByTemplate(typeName, template);
        }

        public List<EntityObject> GetAll(string typeName)
        {
            return BusinessManager.Instance.GetAll(typeName);
        }
    }
}
