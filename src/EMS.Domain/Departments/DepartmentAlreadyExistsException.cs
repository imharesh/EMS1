using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace EMS.Departments
{
    public class DepartmentAlreadyExistsException : BusinessException
    {
        public DepartmentAlreadyExistsException(string name)
       : base(EMSDomainErrorCodes.EmployeeAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
