using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace PatriaFabricaMuebles.DAO
{
    class ConnectionStringManager
    {
        public static String ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["MueblesDB"].ConnectionString;
            }
        }
    }
}
