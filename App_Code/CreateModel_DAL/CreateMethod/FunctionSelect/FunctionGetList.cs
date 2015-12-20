using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tableModel;

namespace CreateMethod
{
    public class FunctionGetList
    {
        public string CreateFunctionGetList(TableModel tableModel)
        {
            string result = "";
            if (tableModel != null) {
                result = @"
        public DataSet GetList(string whereAfter)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append(""select * "");
            sqlStr.Append(""from " + tableModel.tableName + @" "");
            if(!string.IsNullOrEmpty(whereAfter)){
                sqlStr.Append(""where ""+whereAfter);
            }
            return SQLHelper.ExecuteDs(sqlStr.ToString());
        }

        public DataSet GetList(int top, string whereAfter)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append(""select top ""+ top.ToString() +"" * "");
            sqlStr.Append(""from " + tableModel.tableName + @" "");
            if(!string.IsNullOrEmpty(whereAfter)){
                sqlStr.Append(""where ""+whereAfter);
            }
            return SQLHelper.ExecuteDs(sqlStr.ToString());
        }

        public DataSet GetListDistinct(int top, string whereAfter)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append(""select distinct top ""+ top.ToString() +"" * "");
            sqlStr.Append(""from " + tableModel.tableName + @" "");
            if(!string.IsNullOrEmpty(whereAfter)){
                sqlStr.Append(""where ""+whereAfter);
            }
            return SQLHelper.ExecuteDs(sqlStr.ToString());
        }";
            }
                
            return result;
        }
    }
}