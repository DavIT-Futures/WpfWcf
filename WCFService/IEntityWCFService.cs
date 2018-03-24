using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TestApp.Entity;

namespace TestApp.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEntityWCFService
    {
        [OperationContract]
        EntityObject GetById(string typeName, int id);

        [OperationContract]
        List<EntityObject> GetByTemplate(string typeName, EntityObject template);

        [OperationContract]
        List<EntityObject> GetAll(string typeName);
    }

}
