using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;
using globalVal;
using sqlHelper;

namespace tempLog
{
    public static class ErrLog
    {
        public static void ErrLogToFile(string errStr) {
            File.AppendAllText(GlobalVariables.ErrLogPath + @"\err.log", errStr, System.Text.Encoding.ASCII);
            
        }

        //some time get the error log from execu sql
        public static int ExecuteSql(string sqlStr){
            try
            {
                SQLHelper.ExecuteSql(sqlStr);

            }
            catch (Exception e)
            {
                ErrLogToFile("\n\n" + DateTime.Now.ToString() + " Exception info:\n" + e.ToString());
                return 0;
            }
            return 1;
        }
    }
}
