using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using tableModel;
using colModel;
using SQLToCSharpNamespace;

namespace CreateMethod
{
    public class FunctionAdd
    {
        public string CreateAddFunction(string dbName, TableModel tableModel)
        {
            string result = "";     //return result
            string sqlField = "";   //sqlStr part assign
            string sqlPara = "";    //sqlStr part where
            string paramaters = ""; //SqlParameter[] parameters init
            int count = 0;
            string assign = "";     //SqlParameter[] parameters assign
            if (tableModel != null && tableModel.models.Count > 0)
            {
                foreach (ColModel model in tableModel.models)
                {
                    //if the column is identity, not need add this column
                    if (model.isIdentity == 0)
                    {
                        sqlField += "[" + model.name + "],";
                        sqlPara += "@" + model.name.Replace(' ', '_') + ",";
                        paramaters += @"
                new SqlParameter(""@" + model.name.Replace(' ', '_') + @""", SqlDbType." + SQLToCSharp.SqlTypeToSqlDBType(model.type).ToString() + @"," + model.len + @"),";
                        assign += @"
            if( model." + model.name.Replace(' ', '_') + @"==null)
                parameters[" + count + @"].Value = DBNull.Value;
            else
                parameters[" + count + @"].Value = model." + model.name.Replace(' ', '_') + @";";
                        count++;
                    }

                }
                sqlField = sqlField.Substring(0, sqlField.Length - 1);
                sqlPara = sqlPara.Substring(0, sqlPara.Length - 1);
                paramaters = paramaters.Substring(0, paramaters.Length - 1);
                if (tableModel != null)
                {
                    result = @"
        public bool Add(" + dbName + @"Model." + tableModel.className + @" model)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append(""insert into " + tableModel.tableName + @"("");
            sqlStr.Append(""" + sqlField + @")"");
            sqlStr.Append("" values("");
            sqlStr.Append(""" + sqlPara + @")"");
            
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
    }
}