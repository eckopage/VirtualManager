using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.DataAccessLayer.EDM;
using VM.DataAccessLayer.EDM.Accounts;

namespace VM.DataAccessLayer.Common {
    public interface IAppDatabaseContext {
        VirtualManagerDatabaseContainer CreateNewMainContext();

        AccountsDbContext CreateNewAccountContext();
    }
}
