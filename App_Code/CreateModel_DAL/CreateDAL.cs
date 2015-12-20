using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CreateMethod;
using tableModel;
using System.IO;
using globalVal;

namespace createDAL
{
    /* 
     * create the DAL for every table, package the methods like add, delete, update, getlist
     * all the method in this software must use those methods to operate the database
     * those methods are universal for local and SaaS platform, and the advance methods are more powerfull but only use in a part
     */ 
    public class CreateDAL
    {
        //projectName independent with tableModel for mutil from DB
        protected string CreateDALStr(TableModel tableModel, string dbName)
        {
            string result =
@"using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using sqlHelper;
namespace " + dbName + @"DAL
{
    public class " + tableModel.className + @"
    {";

            ////addd the methods string
            FunctionAdd functionAdd = new FunctionAdd();
            string add = functionAdd.CreateAddFunction(dbName, tableModel);
            result += add;

            FunctionDelete functionDel = new FunctionDelete();
            string del = functionDel.CreateFunctionDelete(dbName, tableModel);
            result += del;

            FunctionUpdate functionUpdate = new FunctionUpdate();
            string update = functionUpdate.CreateFunctionUpdate(dbName, tableModel);
            result += update;

            FunctionSelectTop functionSelectTop = new FunctionSelectTop();
            string selectTop = functionSelectTop.CreateFunctionSelectTop(dbName, tableModel);
            result += selectTop;

            FunctionRowToModel functionRowToModel = new FunctionRowToModel();
            string RowToModel = functionRowToModel.CreateFuntionRowToModel(dbName, tableModel);
            result += RowToModel;

            FunctionGetList functionGetList = new FunctionGetList();
            string getList = functionGetList.CreateFunctionGetList(tableModel);
            result += getList;

            FunctionDataSetToList functionDataSetToList = new FunctionDataSetToList();
            string DataSetToList = functionDataSetToList.CreateFunctionDataSetToList(dbName, tableModel);
            result += DataSetToList;

            FunctionGetListByPage functionGetListByPage = new FunctionGetListByPage();
            string getListByPage = functionGetListByPage.CreateFunctionGetListPage(tableModel);
            result += getListByPage;
            ////-----------------------

            result += @"
    }
}";
            return result;
        }

        protected void StrToCSFile(string path, string DALStr, string tableName)
        {
            try
            {
                File.WriteAllText(path + tableName + ".cs", DALStr);
            }
            catch (Exception e)
            {
                tempLog.ErrLog.ErrLogToFile(e.ToString());
            }
        }

        public void CreateDALFile(string path, string dbName, TableModel tableModel)
        {
            if (tableModel != null)
            {
                string DALStr = CreateDALStr(tableModel, dbName);
                StrToCSFile(path, DALStr, tableModel.tableName);
            }
            else
            {
                tempLog.ErrLog.ErrLogToFile("fialed to get tableModel");
                return;
            }
        }
    }
}