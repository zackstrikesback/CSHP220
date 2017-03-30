using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TrackerDB;

namespace TrackerRepository
{
    class DatabaseManager
    {
        private static readonly TrackerEntities entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new TrackerEntities();
            entities.Database.Connection.Open();
        }

        // Provide an accessor to the database
        public static TrackerEntities Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
