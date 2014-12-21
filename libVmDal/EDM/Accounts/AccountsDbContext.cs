using Microsoft.AspNet.Identity.EntityFramework;
using System;
using VM.DataAccessLayer.Defaults;

namespace VM.DataAccessLayer.EDM.Accounts {
    [Obsolete("Make it internal")]
    public class AccountsDbContext : IdentityDbContext<AccountUserModel> {
        public AccountsDbContext()
            : base(ConnectionString.Accounts, throwIfV1Schema: false) {
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccountUserModel>().ToTable("AccountTable");
            modelBuilder.Entity<IdentityUser>().ToTable("AccountTable");
            modelBuilder.Entity<IdentityUserRole>().ToTable("AccountUserRoleTable");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("AccountLoginTable");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("AccountClaimsTable");
            modelBuilder.Entity<IdentityRole>().ToTable("AccountRoleTable");
        }

        [Obsolete("This method will be removed")]
        public static AccountsDbContext Create() {
            return new AccountsDbContext();
        }
    }
}
