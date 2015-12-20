using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tableModel;
using colModel;
using SQLToCSharpNamespace;

namespace CreateMethod
{
    public class FunctionDelete
    {
        public string CreateFunctionDelete(string dbName, TableModel tableModel)
        {
            string result = "";     //return result
            string sqlPara = "";    //sqlStr part where
            string paramaters = ""; //SqlParameter[] parameters init
            int count = 0;
            string assign = "";     //SqlParameter[] parameters assign
            if (tableModel != null && tableModel.models.Count > 0)
            {
                foreach (string pk in tableModel.PKs)
                {
                    //pk.name need add [] 
                    //pk.name parameter change Database Version to Database_Version
                    sqlPara += @"
            sqlStr.Append(""[" + pk + "]=@" + pk.Replace(' ', '_') + @" and "");";
                    ColModel model = GetModelFromPK(pk, tableModel);
                    paramaters += @"
                new SqlParameter(""@" + pk.Replace(' ', '_') + @""", SqlDbType." + SQLToCSharp.SqlTypeToSqlDBType(model.type) + "," + model.len + "),";
                    assign += @"
            if( model." + model.name.Replace(' ', '_') + @"==null)
                parameters[" + count + @"].Value = DBNull.Value;
            else
                parameters[" + count + @"].Value = model." + model.name.Replace(' ', '_') + @";";
                    count++;
                }
                sqlPara = sqlPara.Substring(0, sqlPara.Length - 7);
                sqlPara += @""");";
                paramaters = paramaters.Substring(0, paramaters.Length - 1);
                if (tableModel != null)
                {
                    result = @"
        public bool Delete(" + dbName + @"Model." + tableModel.className + @" model)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append(""delete from " + tableModel.tableName + @" "");
            sqlStr.Append(""where "");" +
            sqlPara + @"
            SqlParameter[] parameters = {" +
            paramaters + @"
            };
            " + assign + @"
            int result = SQLHelper.ExecuteSql(sqlStr.ToString(),parameters);
            if(result==1){
                return true;
            }
            else{
                return false;
            }
        }";
                }
            }
            return result;
        }

        protected ColModel GetModelFromPK(string pk, TableModel tableModel)
        {
            if (tableModel != null && tableModel.models.Count > 0) {
                foreach (ColModel model in tableModel.models)
                {
                    if (model.name.Equals(pk))
                    {
                        return model;
                    }
                }
            }
            return null;
        }
    }
}