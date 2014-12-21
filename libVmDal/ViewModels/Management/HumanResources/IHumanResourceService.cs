using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.DataAccessLayer.Common;
using VM.DataAccessLayer.ViewModels.Management.HumanResources;

namespace VM.DataAccessLayer.ViewModels.Management.HumanResources {
    interface IHumanResourceService:IService {
        void AddEmployee(HumanResourceViewModel employee);
        void UpdateEmployee(HumanResourceViewModel employee);
        void DeleteEmployee(HumanResourceViewModel employee);
        HumanResourceViewModel GetEmployee(int id);
        //HumanResourceViewModel GetEmployee(int pesel);
        IEnumerable<HumanResourceViewModel> GetAllEmployee();
        IEnumerable<HumanResourceViewModel> GetEmployee(string name);
    }
}
