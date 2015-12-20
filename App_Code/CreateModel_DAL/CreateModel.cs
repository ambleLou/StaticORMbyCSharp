using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using colModel;
using tableModel;
using System.IO;
using SQLToCSharpNamespace;
using System.Data;
using globalVal;

namespace createModel
{
    /* 
     * create the models about all the tables, the colums transact to properties
     * the type of property in C# is map to the sql type
     * dbName is for namespace conflict
     */
    public class CreateModel
    {
        //get the model file string for every table
        protected string CreateModelStr(TableModel tableModel, string dbName)
        {
            string privateVals = "";
            string propertys = "";
            string result = "";
            if (tableModel != null && tableModel.models.Count > 0)
            {
                foreach (ColModel colModel in tableModel.models)
                {
                    SqlDbType DBType = SQLToCSharp.SqlTypeToSqlDBType(colModel.type);
                    string type = SQLToCSharp.sqlDBTypeToCSharpType(DBType).Name;   //get CSharpType from sqlType
                    //create model proterty change space to _
                    string propertyName = colModel.name.Replace(' ', '_');
                    if (type.ToLower() == "string")
                    {
                        string privatePart = @"
        private " + type + " _" + propertyName + @";";
                        string propertyPart = @"
        public " + type + " " + propertyName + @"
        {
            set { _" + propertyName + @" =value; }
            get { return _" + propertyName + @"; }
        }";
                        privateVals += privatePart;
                        propertys += propertyPart;
                    }
                    else
                    {
                        string privatePart = @"
        private " + type + "? _" + propertyName + @";";
                        string propertyPart = @"
        public " + type + "? " + propertyName + @"
        {
            set { _" + propertyName + @" =value; }
            get { return _" + propertyName + @"; }
        }";
                        privateVals += privatePart;
                        propertys += propertyPart;
                    }

                }
                if (tableModel != null)
                {
                    result = @"using System;
namespace " + dbName + @"Model
{
    public class " + tableModel.className + @"
    {"
                   + privateVals
                   + propertys + @"
    }
}";
                }
            }
            return result;
        }

        protected void StrToCSFile(string path, string modelStr, string tableName)
        {
            try
            {
                File.WriteAllText(path + tableName + ".cs", modelStr);
            }
            catch (Exception e)
            {
                tempLog.ErrLog.ErrLogToFile(e.ToString());
            }
        }

        //create a file to description one table
        public void CreateModelFile(string path, string dbName, TableModel tableModel)
        {
            if (tableModel != null)
            {
                string modelStr = CreateModelStr(tableModel, dbName);
                StrToCSFile(path, modelStr, tableModel.tableName);
            }
            else
            {
                tempLog.ErrLog.ErrLogToFile("fialed to get tableModel");
                return;
            }
        }
    }
}