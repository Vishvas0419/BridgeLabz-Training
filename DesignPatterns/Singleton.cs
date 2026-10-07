using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Singleton
    {
    }

    public class DBConnection
    {
        private static DBConnection DBInstance;

        private DBConnection(){ }

        public static DBConnection GetDBInstance()
        {
            if(DBInstance==null)
            {
                DBInstance = new DBConnection();
            }
            return DBInstance;
        }
    }
}
