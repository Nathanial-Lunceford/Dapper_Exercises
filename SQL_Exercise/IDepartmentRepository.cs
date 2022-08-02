using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Exercise
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartments();

        public void InsertDepartments( string NewDepartmentName);
    }
}
