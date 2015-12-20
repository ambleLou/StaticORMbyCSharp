using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sqlHelper;
using System.Text.RegularExpressions;

namespace globalVal
{
    public static class GlobalVariables
    {
        private static string _basePath;
        private static string _execPath;
        private static string _connectStr;

        //hlou: the global value is static now, will change to input after time.
        public static string basePath {
            get { return @"C:\Users\hlou\Documents\Visual Studio 2010\Projects\DataExchangePurchaseOne\DataExchange"; }
            set { _basePath = value; }
        }

        public static string LocalAPP_CodePath
        {
            get { return basePath + "\\App_Code"; }
        }

        public static string LocalPath
        {
            get { return basePath + "\\App_Code" + "\\Local"; }
        }

        public static string execPath
        {
            get { return @"C:\Users\hlou\Documents\Visual Studio 2010\Projects\executionPurchaseOne\execution"; }
            set { _execPath = value; }
        }
        public static string APP_CodePath
        {
            get { return execPath + "\\App_Code"; }
            set { APP_CodePath = value; }
        }

        public static string DestLocalPath
        {
            get { return execPath + "\\App_Code" + "\\Local"; }
        }

        public static string TempdbPath
        {
            get { return execPath + @"\App_Code\Tempdb"; }
        }

        public static string DestPath
        {
            get { return APP_CodePath + "\\Dest"; }
        }

        public static string connectStr
        {
            get
            {
                return @"Server=HLOU-MOBL\SQLEXPRESS;Database=PurchaseOne;uid=CCR\hlou;pwd=l912389750@;Integrated Security=SSPI";
            }
            //one key
            set
            {
                if (_connectStr == null)
                    _connectStr = value;
            }
        }
        public static string connectTempdnStr
        {
            get
            {
                string tempConnectTempdnStr = connectStr.Replace(LocalDBName, "tempdb");
                return tempConnectTempdnStr;
            }
        }

        //get the dbName from the connect string
        public static string LocalDBName
        {
            get
            {
                string reg = @"Database=.*?;|Initial Catalog=.*?;";
                Regex regex = new Regex(reg, RegexOptions.IgnoreCase);
                string DBString = regex.Match(connectStr).Groups[0].Value;
                DBString = DBString.Substring(DBString.IndexOf('=') + 1);
                DBString = DBString.Substring(0, DBString.Length - 1);
                return DBString;
            }
        }

        //hlou:errlog File path
        public static string ErrLogPath
        {
            get { return basePath + "\\App_Code"; }
        }

        //hlou:init in front
        public static int perExchangeItems
        {
            get { return 100; }
        }
    }
}
