using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tableModel;
using colModel;
using SQLToCSharpNamespace;

namespace CreateMethod
{
    public class FunctionUpdate
    {
        public string CreateFunctionUpdate(string dbName, TableModel tableModel)
        {
            string result = "";     //return result
            string sqlField = "";   //sqlStr part assign
            string sqlPara = "";    //sqlStr part where
            string sqlParaOld = ""; //sqlStr part where from old model
            string paramaters = ""; //SqlParameter[] parameters init
            string paramatersOld = "";  //SqlParameter[] parameters init for old model
            int count = 0;
            string assign = "";     //SqlParameter[] parameters assign
            string assignOld = "";     //SqlParameter[] parameters assign
            if (tableModel != null && tableModel.models.Count > 0)
            {
                foreach (ColModel model in tableModel.models)
                {
                    //not need update the identity column
                    if (model.isIdentity == 0)
                    {
                        sqlField += @"
            sqlStr.Append(""[" + model.name + "]=@" + model.name.Replace(' ', '_') + @","");";
                    }
                    paramaters += @"
                new SqlParameter(""@" + model.name.Replace(' ', '_') + @""", SqlDbType." + SQLToCSharp.SqlTypeToSqlDBType(model.type).ToString() + @"," + model.len + @"),";
                    assign += @"
            if( model." + model.name.Replace(' ', '_') + @"==null)
                parameters[" + count + @"].Value = DBNull.Value;
            else
                parameters[" + count + @"].Value = model." + model.name.Replace(' ', '_') + @";";
                    count++;
                }
                foreach (string pk in tableModel.PKs)
                {
                    sqlPara += @"
            sqlStr.Append(""[" + pk + "]=@" + pk.Replace(' ', '_') + @" and "");";
                    sqlParaOld += @"
            sqlStr.Append(""[" + pk + "]=@old" + pk.Replace(' ', '_') + @" and "");";
                    ColModel model = GetModelFromPK(pk, tableModel);
                    paramatersOld += @"
                new SqlParameter(""@old" + model.name.Replace(' ', '_') + @""", SqlDbType." + SQLToCSharp.SqlTypeToSqlDBType(model.type).ToString() + @"," + model.len + @"),";
                    assignOld += @"
            parameters[" + count + @"].Value = oldModel." + model.name.Replace(' ', '_') + @";";
                    count++;
                }
                sqlField = sqlField.Substring(0, sqlField.Length - 4);
                sqlField += @""");";
                sqlPara = sqlPara.Substring(0, sqlPara.Length - 7);
                sqlPara += @""");";
                sqlParaOld = sqlParaOld.Substring(0, sqlParaOld.Length - 7);
                sqlParaOld += @""");";
                paramaters = paramaters.Substring(0, paramaters.Length - 1);
                if (tableModel != null)
                {
                    result = @"
        // this method is used to identity key as pk. not use this method if can change the primay key
        public bool Update(" + dbName + @"Model." + tableModel.className + @" model)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append(""update " + tableModel.tableName + @" set "");
            " + sqlField + @"
            sqlStr.Append("" where "");
            " + sqlPara + @"
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
        }

        public bool Update(" + dbName + @"Model." + tableModel.className + @" model,Model." + tableModel.className + @" oldModel)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append(""update " + tableModel.tableName + @" set "");
            " + sqlField + @"
            sqlStr.Append("" where "");
            " + sqlParaOld + @"
            SqlParameter[] parameters = {" +
            paramaters + "," +
            paramatersOld + @"
            };
            " +
            assign +
            assignOld + @"
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

        //get the pk's model detail from the name of pk
        protected ColModel GetModelFromPK(string pk, TableModel tableModel)
        {
            if (tableModel != null && tableModel.models.Count > 0)
            {
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