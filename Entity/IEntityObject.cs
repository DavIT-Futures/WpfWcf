using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Entity
{
    public interface IEntityObject
    {
        string GetTableName();
        string GetKeyName();
    }
}
