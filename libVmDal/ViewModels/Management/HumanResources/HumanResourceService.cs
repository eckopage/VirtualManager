using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.DataAccessLayer.Common;

namespace VM.DataAccessLayer.ViewModels.Management.HumanResources {
    public class HumanResourceService: IHumanResourceService {
        private IAppDatabaseContext _context;

        public HumanResourceService(IAppDatabaseContext context) {
            _context = context;
        }

        public void AddEmployee(HumanResourceViewModel employee) {

        }

        public void UpdateEmployee(HumanResourceViewModel employee) {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(HumanResourceViewModel employee) {
            throw new NotImplementedException();
        }

        public HumanResourceViewModel GetEmployee(int id) {
            throw new NotImplementedException();
        }

        public IEnumerable<HumanResourceViewModel> GetAllEmployee() {
            throw new NotImplementedException();
        }

        public IEnumerable<HumanResourceViewModel> GetEmployee(string name) {
            throw new NotImplementedException();
        }
    }
}
