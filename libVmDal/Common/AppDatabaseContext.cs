using VM.DataAccessLayer.EDM;
using VM.DataAccessLayer.EDM.Accounts;

namespace VM.DataAccessLayer.Common {
    public class AppDatabaseContext : IAppDatabaseContext {
        /// <summary>
        /// Create main database connection internally.
        /// </summary>
        /// <returns></returns>
        public VirtualManagerDatabaseContainer CreateNewMainContext() {
            return new VirtualManagerDatabaseContainer();
        }

        /// <summary>
        /// Create main database connection internally just for accounts
        /// </summary>
        /// <returns></returns>
        public AccountsDbContext CreateNewAccountContext() {
            return new AccountsDbContext();
        }
    }
}
