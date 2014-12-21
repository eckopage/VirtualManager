using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace VM.DataAccessLayer.Defaults {
    public static class ConnectionString {
        /// <summary>
        /// Gets connection string to the main database.
        /// </summary>
        public static string Main {
            get {
                if(string.IsNullOrWhiteSpace(_main))
                    _main = ConnectionString.BuildEntityFrameworkConnectionString("VirtualManagerDatabase");
                return _main;
            }
        }
        private static string _main;

        /// <summary>
        /// Gets connection string to accounts database.
        /// <remarks>
        /// This database use code-first approach.
        /// It is directed by concept to reuse Microsoft.AspNet.Identity.EntityFramework wchich do not support DB-first approach.
        /// </remarks>
        /// </summary>
        public static string Accounts {
            get {
                if(string.IsNullOrWhiteSpace(_accounts))
                    _accounts = ConnectionString.BuildProvideConnectionString("VirtualManagerDatabase");
                return _accounts;
            }
        }
        private static string _accounts;

        private static string BuildEntityFrameworkConnectionString(string databaseName) {
            var builder = new EntityConnectionStringBuilder();

            builder.Metadata = @"res://*/EDM.VirtualManagerDatabase.csdl|res://*/EDM.VirtualManagerDatabase.ssdl|res://*/EDM.VirtualManagerDatabase.msl";
            builder.Provider = "System.Data.SqlClient";
            builder.ProviderConnectionString = ConnectionString.BuildProvideConnectionString(databaseName);

            // example
            //metadata=res://*/EDM.TachoEkspertDatabaseModel.csdl    |res://*/EDM.TachoEkspertDatabaseModel.ssdl    |res://*/EDM.TachoEkspertDatabaseModel.msl;    provider=System.Data.SqlClient;provider connection string="data source=STEFAN-PC\SQLEXPRESS;initial catalog=MainTachoEkspertDatabase;user id=TachoEkspertMainLogin1087;password=***********;MultipleActiveResultSets=True;App=EntityFramework"
            //metadata=res://*/Models.EDM.VirtualManagerDatabase.csdl|res://*/Models.EDM.VirtualManagerDatabase.ssdl|res://*/Models.EDM.VirtualManagerDatabase.msl;provider=System.Data.SqlClient;provider connection string="data source=STEFAN-PC\SQLEXPRESS;initial catalog=VirtualManagerDatabase;user id=VirtualManagerDeveloper;password=***************;MultipleActiveResultSets=True;App=EntityFramework"

            return builder.ToString();
        }

        private static string BuildProvideConnectionString(string databaseName) {
            var serverName = string.Format("{0}\\SQLEXPRESS", Environment.MachineName);
            var password = "qwerty1234";
            var userId = "VirtualManagerDeveloper";

            var sqlBuilder = new SqlConnectionStringBuilder();

            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;
            sqlBuilder.Password = password;
            sqlBuilder.Add("App", "EntityFramework");
            sqlBuilder.UserID = userId;
            sqlBuilder.MultipleActiveResultSets = true;

            sqlBuilder.IntegratedSecurity = true;

            return sqlBuilder.ToString();
        }
    }
}