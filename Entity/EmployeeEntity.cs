using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace TestApp.Entity
{
    [DataContract]
    public class EmployeeEntity : EntityObject
    {
        private int employeeId;
        [DataMember(Name = "EmployeeId")]
        public int EmployeeId
        {
            get
            {
                return employeeId;
            }
            set
            {
                employeeId = value;
                Id = employeeId;
            }
        }

        [DataMember(Name = "FirstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "LastName")]
        public string LastName { get; set; }

        public override string Error
        {
            get
            {
                return "Error";
            }
        }

        public override string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                result = base[columnName];
                switch (columnName)
                {
                    case "FirstName":
                        if (string.IsNullOrEmpty(FirstName)) result = "First Name must have a value."; break;
                    case "LastName":
                        if (string.IsNullOrEmpty(LastName)) result = "Last Name must have a value."; break;
                };
                return result;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", {0}, {1}, Table={2}, Key={3}", FirstName, LastName, GetTableName(), GetKeyName());
        }

        public override string GetTableName()
        {
            return "Employee";
        }

        public override string GetKeyName()
        {
            return "EmployeeId";
        }
    }
}
