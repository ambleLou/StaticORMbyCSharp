using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tableModel;
using colModel;
using SQLToCSharpNamespace;

namespace CreateMethod
{
    public class FunctionSelectTop
    {
        public string CreateFunctionSelectTop(string dbName, TableModel tableModel)
        {
            string sqlStr = GetSqlStr(tableModel);
            string parameters = GetParameter(tableModel);
            string envaluation = GetEnvaluation(tableModel);
            string envaluationWithPK = GetEnvaluationWithPK(tableModel);
            string result = "";
            if (tableModel != null) {
                result = @"

        public " + dbName + @"Model." + tableModel.className + " SelectTop(" + dbName + @"Model." + tableModel.className + @" model)
        {" +
        sqlStr +
        parameters +
        envaluation + @"
            DataSet result = SQLHelper.ExecuteDs(sqlStr.ToString(),parameters);
            if(result.Tables[0].Rows.Count>0){
                return RowToModel(result.Tables[0].Rows[0]);
            }
            else{
                return null;
            }
        }";

                string resultWitPK = @"

        public " + dbName + @"Model." + tableModel.className + " SelectTop(" + GetPKsPara(tableModel) + @")
        {" +
            sqlStr +
            parameters +
            envaluationWithPK + @"
            DataSet result = SQLHelper.ExecuteDs(sqlStr.ToString(),parameters);
            if(result.Tables[0].Rows.Count>0){
                return RowToModel(result.Tables[0].Rows[0]);
            }
            else{
                return null;
            }
        }";
                string resultWitWhere = @"

        public " + dbName + @"Model." + tableModel.className + " SelectTop(" + dbName + @"Model." + tableModel.className + @" model, string where)
        {" +
        sqlStr +@"
            if (where != null)
                sqlStr.Append("" and ""+where);"+
        parameters +
        envaluation + @"
            DataSet result = SQLHelper.ExecuteDs(sqlStr.ToString(),parameters);
            if(result.Tables[0].Rows.Count>0){
                return RowToModel(result.Tables[0].Rows[0]);
            }
            else{
                return null;
            }
        }";
                string resultOnlyWitWhere = @"

        public " + dbName + @"Model." + tableModel.className + @" SelectTop(string whereAfter)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append(""select top 1 * from " + tableModel.tableName + @" "");
            if (!string.IsNullOrEmpty(whereAfter))
            {
                sqlStr.Append(""where "" + whereAfter);
            }" + @"
            DataSet result = SQLHelper.ExecuteDs(sqlStr.ToString());
            if(result.Tables[0].Rows.Count>0){
                return RowToModel(result.Tables[0].Rows[0]);
            }
            else{
                return null;
            }
        }";
                result += resultWitPK;
                result += resultWitWhere;
                result += resultOnlyWitWhere;
            }
            return result;
        }
        protected string GetSqlStr(TableModel tableModel)
        {
            string result = "";
            if (tableModel != null) {
                result = @"
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append(""select top 1 * from " + tableModel.tableName + @" "");
            sqlStr.Append(""where "");";
            }
            
            string PK = "";
            if (tableModel!=null&&tableModel.PKs!=null&&tableModel.PKs.Count>0)
            {
                foreach (string pk in tableModel.PKs)
                {
                    PK += @"
            sqlStr.Append(""" + pk + "=@" + pk + @" and"");";
                }
                PK = PK.Substring(0, PK.Length - 6);
                PK += @""");";
                result = result + PK;
            }
            return result;
        }

        protected string GetParameter(TableModel tableModel)
        {
            string PK = "";
            if (tableModel!=null&&tableModel.PKs!=null&&tableModel.PKs.Count>0)
            {
                foreach (string pk in tableModel.PKs)
                {
                    ColModel model = GetModelFromPK(pk, tableModel);
                    PK += @"
                new SqlParameter(""@" + pk + @""", SqlDbType." + SQLToCSharp.SqlTypeToSqlDBType(model.type) + "," + model.len + "),";
                }
                PK = PK.Substring(0, PK.Length - 1);
            }

            string result = "";
            if (tableModel != null) {
                result = @"
            SqlParameter[] parameters = {" +
            PK + @"
            };";
            }
            return result;
        }

        protected string GetEnvaluation(TableModel tableModel)
        {
            int count = 0;
            string envaluations = "";
            string result = "";
            if (tableModel != null && tableModel.PKs != null && tableModel.PKs.Count > 0) {
                foreach (string pk in tableModel.PKs)
                {
                    string envaluation = @"
            parameters[" + count + @"].Value = model." + pk + ";";
                    count++;
                    envaluations += envaluation;
                }
                result = envaluations;
            }
            return result;
        }

        protected string GetEnvaluationWithPK(TableModel tableModel)
        {
            int count = 0;
            string envaluations = "";
            string result = "";
            if (tableModel != null && tableModel.PKs != null && tableModel.PKs.Count > 0) {
                foreach (string pk in tableModel.PKs)
                {
                    string envaluation = @"
            parameters[" + count + @"].Value = " + pk + ";";
                    count++;
                    envaluations += envaluation;
                }
                result = envaluations;
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

        protected string GetPKsPara(TableModel tableModel)
        {
            string paras = "";
            if (tableModel!=null&&tableModel.PKs!=null&&tableModel.PKs.Count>0 && tableModel.PKs.Count > 0) {
                foreach (string pk in tableModel.PKs)
                {
                    ColModel model = GetModelFromPK(pk, tableModel);
                    string para = SQLToCSharp.SqlTypeToCSharpType(model.type.ToString()) + " " + pk + ",";
                    paras += para;
                }
                paras = paras.Substring(0, paras.Length - 1);
            }
            return paras;
        }
    }
}