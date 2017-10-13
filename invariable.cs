using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientMonitor
{
   public  class invariable
    {

        //SQL Statements
        public static String sqlQuerySelectAll = "SELECT * FROM BedList";
        public static String sqlQuerySelectStaffOnCall = "SELECT Id, staff_name, staff_jobtitle FROM Staff WHERE Staff_oncall = 1";
        public static String sqlQuerySelectStaffNotOnCall = "SELECT Id, staff_name, staff_jobtitle FROM Staff WHERE Staff_oncall = 0";
        public static String sqlQuerySelectStaffAll = "SELECT ID, staff_name, staff_jobtitle FROM Staff";
        public static String sqlQuerySelectLogsAll = "SELECT ID_Log, Date, Time FROM Logs";
        public static String sqlQuerySetOnCall = "UPDATE Staff Set Staff_oncall ='1' WHERE Id=@curRow";
        public static String sqlQuerySetOffCall = "UPDATE Staff Set Staff_oncall ='0' WHERE Id=@curRow1";
        public static int OncallError = 1;
        public static int OffcallError = 1;

        //Error Codes
        public static int errNothingChanged = 0;

        //Error Messages
        public static string errNothingMovedTables = "Press okay to confirm your selection.";
    }  

}
