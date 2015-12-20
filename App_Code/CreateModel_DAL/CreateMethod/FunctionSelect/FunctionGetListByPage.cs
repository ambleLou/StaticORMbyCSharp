using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tableModel;
using colModel;

namespace CreateMethod
{
    public class FunctionGetListByPage
    {
        public string CreateFunctionGetListPage(TableModel tableModel)
        {
            string result = "";
            if (tableModel != null) {
                result = @"
        public DataSet GetListByPage(string whereAfter, string orderby, int first, int last)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append(""select * from( select ROW_NUMBER() OVER( order by T."");
            if(!string.IsNullOrEmpty(orderby.Trim()))
                sqlStr.Append(orderby.Trim());
            else
                sqlStr.Append(""desc"");
            sqlStr.Append("") as Row, T.* from " + tableModel.tableName + @" T"");
            if(!string.IsNullOrEmpty(whereAfter.Trim()))
                sqlStr.Append("" where ""+ whereAfter);
            sqlStr.AppendFormat("") TT where TT.Row > {0} and TT.Row <= {1}"", first, last);
            return SQLHelper.ExecuteDs(sqlStr.ToString());
        }";
            }
            return result;
        }
    }
}