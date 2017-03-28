using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace DemoDB.DAL
{
    class DBEstablish
    {
        public static string makeConnection()
        {
           

            string con = ConfigurationManager.ConnectionStrings["MetroCampusSystemDBCon"].ToString();
            return con;
        }
       
    }
}
