using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatabaseAccess
    {
        // Fields
        private QLBHDataContext db = new QLBHDataContext();
        private string serverName = ".\\SQLEXPRESS";
        private string dbName = "POS_HCL";
        // Constructors
        public DatabaseAccess(QLBHDataContext db, string serverName, string dbName)
        {
            this.db = db;
            this.serverName = serverName;
            this.dbName = dbName;
        }

        public DatabaseAccess()
        {
            Db = new QLBHDataContext(Properties.Settings.Default.POS_HCLConnectionString);
        }

        // Properties
        public QLBHDataContext Db { get => db; set => db = value; }
        public string ServerName { get => serverName; set => serverName = value; }
        public string DbName { get => dbName; set => dbName = value; }
    }
}
