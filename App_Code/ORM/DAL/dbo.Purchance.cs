using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using sqlHelper;
namespace DAL
{
    public class dbo_Purchance
    {
        public bool Add(Model.dbo_Purchance model)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("insert into dbo.Purchance(");
            sqlStr.Append("[ID],[StatusID],[PartName],[Qty],[SumPrice],[Exchange])");
            sqlStr.Append(" values(");
            sqlStr.Append("@ID,@StatusID,@PartName,@Qty,@SumPrice,@Exchange)");
            
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
                new SqlParameter("@StatusID", SqlDbType.Int,4),
                new SqlParameter("@PartName", SqlDbType.VarChar,50),
                new SqlParameter("@Qty", SqlDbType.Int,4),
                new SqlParameter("@SumPrice", SqlDbType.Int,4),
                new SqlParameter("@Exchange", SqlDbType.Int,4)
            };
            
            if( model.ID==null)
                parameters[0].Value = DBNull.Value;
            else
                parameters[0].Value = model.ID;
            if( model.StatusID==null)
                parameters[1].Value = DBNull.Value;
            else
                parameters[1].Value = model.StatusID;
            if( model.PartName==null)
                parameters[2].Value = DBNull.Value;
            else
                parameters[2].Value = model.PartName;
            if( model.Qty==null)
                parameters[3].Value = DBNull.Value;
            else
                parameters[3].Value = model.Qty;
            if( model.SumPrice==null)
                parameters[4].Value = DBNull.Value;
            else
                parameters[4].Value = model.SumPrice;
            if( model.Exchange==null)
                parameters[5].Value = DBNull.Value;
            else
                parameters[5].Value = model.Exchange;
            int result = SQLHelper.ExecuteSql(sqlStr.ToString(),parameters);
            if(result==1){
                return true;
            }
            else{
                return false;
            }
        }
        public bool Delete(Model.dbo_Purchance model)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("delete from dbo.Purchance ");
            sqlStr.Append("where ");
            sqlStr.Append("[ID]=@ID ");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4)
            };
            
            if( model.ID==null)
                parameters[0].Value = DBNull.Value;
            else
                parameters[0].Value = model.ID;
            int result = SQLHelper.ExecuteSql(sqlStr.ToString(),parameters);
            if(result==1){
                return true;
            }
            else{
                return false;
            }
        }
        // this method is used to identity key as pk. not use this method if can change the primay key
        public bool Update(Model.dbo_Purchance model)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("update dbo.Purchance set ");
            
            sqlStr.Append("[ID]=@ID,");
            sqlStr.Append("[StatusID]=@StatusID,");
            sqlStr.Append("[PartName]=@PartName,");
            sqlStr.Append("[Qty]=@Qty,");
            sqlStr.Append("[SumPrice]=@SumPrice,");
            sqlStr.Append("[Exchange]=@Exchange");
            sqlStr.Append(" where ");
            
            sqlStr.Append("[ID]=@ID ");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
                new SqlParameter("@StatusID", SqlDbType.Int,4),
                new SqlParameter("@PartName", SqlDbType.VarChar,50),
                new SqlParameter("@Qty", SqlDbType.Int,4),
                new SqlParameter("@SumPrice", SqlDbType.Int,4),
                new SqlParameter("@Exchange", SqlDbType.Int,4)
            };
            
            if( model.ID==null)
                parameters[0].Value = DBNull.Value;
            else
                parameters[0].Value = model.ID;
            if( model.StatusID==null)
                parameters[1].Value = DBNull.Value;
            else
                parameters[1].Value = model.StatusID;
            if( model.PartName==null)
                parameters[2].Value = DBNull.Value;
            else
                parameters[2].Value = model.PartName;
            if( model.Qty==null)
                parameters[3].Value = DBNull.Value;
            else
                parameters[3].Value = model.Qty;
            if( model.SumPrice==null)
                parameters[4].Value = DBNull.Value;
            else
                parameters[4].Value = model.SumPrice;
            if( model.Exchange==null)
                parameters[5].Value = DBNull.Value;
            else
                parameters[5].Value = model.Exchange;
            int result = SQLHelper.ExecuteSql(sqlStr.ToString(),parameters);
            if(result==1){
                return true;
            }
            else{
                return false;
            }
        }

        public bool Update(Model.dbo_Purchance model,Model.dbo_Purchance oldModel)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("update dbo.Purchance set ");
            
            sqlStr.Append("[ID]=@ID,");
            sqlStr.Append("[StatusID]=@StatusID,");
            sqlStr.Append("[PartName]=@PartName,");
            sqlStr.Append("[Qty]=@Qty,");
            sqlStr.Append("[SumPrice]=@SumPrice,");
            sqlStr.Append("[Exchange]=@Exchange");
            sqlStr.Append(" where ");
            
            sqlStr.Append("[ID]=@oldID ");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
                new SqlParameter("@StatusID", SqlDbType.Int,4),
                new SqlParameter("@PartName", SqlDbType.VarChar,50),
                new SqlParameter("@Qty", SqlDbType.Int,4),
                new SqlParameter("@SumPrice", SqlDbType.Int,4),
                new SqlParameter("@Exchange", SqlDbType.Int,4),
                new SqlParameter("@oldID", SqlDbType.Int,4),
            };
            
            if( model.ID==null)
                parameters[0].Value = DBNull.Value;
            else
                parameters[0].Value = model.ID;
            if( model.StatusID==null)
                parameters[1].Value = DBNull.Value;
            else
                parameters[1].Value = model.StatusID;
            if( model.PartName==null)
                parameters[2].Value = DBNull.Value;
            else
                parameters[2].Value = model.PartName;
            if( model.Qty==null)
                parameters[3].Value = DBNull.Value;
            else
                parameters[3].Value = model.Qty;
            if( model.SumPrice==null)
                parameters[4].Value = DBNull.Value;
            else
                parameters[4].Value = model.SumPrice;
            if( model.Exchange==null)
                parameters[5].Value = DBNull.Value;
            else
                parameters[5].Value = model.Exchange;
            parameters[6].Value = oldModel.ID;
            int result = SQLHelper.ExecuteSql(sqlStr.ToString(),parameters);
            if(result==1){
                return true;
            }
            else{
                return false;
            }
        }

        public Model.dbo_Purchance SelectTop(Model.dbo_Purchance model)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select top 1 * from dbo.Purchance ");
            sqlStr.Append("where ");
            sqlStr.Append("ID=@ID ");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = model.ID;
            DataSet result = SQLHelper.ExecuteDs(sqlStr.ToString(),parameters);
            if(result.Tables[0].Rows.Count>0){
                return RowToModel(result.Tables[0].Rows[0]);
            }
            else{
                return null;
            }
        }

        public Model.dbo_Purchance SelectTop(System.Int32 ID)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select top 1 * from dbo.Purchance ");
            sqlStr.Append("where ");
            sqlStr.Append("ID=@ID ");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;
            DataSet result = SQLHelper.ExecuteDs(sqlStr.ToString(),parameters);
            if(result.Tables[0].Rows.Count>0){
                return RowToModel(result.Tables[0].Rows[0]);
            }
            else{
                return null;
            }
        }
        public Model.dbo_Purchance RowToModel(DataRow row)
        {
            Model.dbo_Purchance model = new Model.dbo_Purchance();
            if(row!=null)
            {
                if(row.Table.Columns.Contains("ID")&&row["ID"] != null&&row["ID"].ToString() != ""){
                    model.ID = Int32.Parse(row["ID"].ToString());
                }
                if(row.Table.Columns.Contains("StatusID")&&row["StatusID"] != null&&row["StatusID"].ToString() != ""){
                    model.StatusID = Int32.Parse(row["StatusID"].ToString());
                }
                if(row.Table.Columns.Contains("PartName")&&row["PartName"] != null&&row["PartName"].ToString() != ""){
                    model.PartName = row["PartName"].ToString();
                }
                if(row.Table.Columns.Contains("Qty")&&row["Qty"] != null&&row["Qty"].ToString() != ""){
                    model.Qty = Int32.Parse(row["Qty"].ToString());
                }
                if(row.Table.Columns.Contains("SumPrice")&&row["SumPrice"] != null&&row["SumPrice"].ToString() != ""){
                    model.SumPrice = Int32.Parse(row["SumPrice"].ToString());
                }
                if(row.Table.Columns.Contains("Exchange")&&row["Exchange"] != null&&row["Exchange"].ToString() != ""){
                    model.Exchange = Int32.Parse(row["Exchange"].ToString());
                }
            }
            return model;
        }
        public DataSet GetList(string whereAfter)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select * ");
            sqlStr.Append("from dbo.Purchance ");
            if(!string.IsNullOrEmpty(whereAfter)){
                sqlStr.Append("where "+whereAfter);
            }
            return SQLHelper.ExecuteDs(sqlStr.ToString());
        }

        public DataSet GetList(int top, string whereAfter)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select top "+ top.ToString() +" * ");
            sqlStr.Append("from dbo.Purchance ");
            if(!string.IsNullOrEmpty(whereAfter)){
                sqlStr.Append("where "+whereAfter);
            }
            return SQLHelper.ExecuteDs(sqlStr.ToString());
        }

        public DataSet GetListDistinct(int top, string whereAfter)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select distinct top "+ top.ToString() +" * ");
            sqlStr.Append("from dbo.Purchance ");
            if(!string.IsNullOrEmpty(whereAfter)){
                sqlStr.Append("where "+whereAfter);
            }
            return SQLHelper.ExecuteDs(sqlStr.ToString());
        }
        public List<Model.dbo_Purchance> DataSetToList(DataSet ds)
        {
            List<Model.dbo_Purchance> modelList = new List<Model.dbo_Purchance >();
            if(ds.Tables[0].Rows.Count>0){
                for(int i=0;i<ds.Tables[0].Rows.Count;i++){
                    Model.dbo_Purchance model = RowToModel(ds.Tables[0].Rows[i]);
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        public DataSet GetListByPage(string whereAfter, string orderby, int first, int last)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select * from( select ROW_NUMBER() OVER( order by T.");
            if(!string.IsNullOrEmpty(orderby.Trim()))
                sqlStr.Append(orderby.Trim());
            else
                sqlStr.Append("desc");
            sqlStr.Append(") as Row, T.* from dbo.Purchance T");
            if(!string.IsNullOrEmpty(whereAfter.Trim()))
                sqlStr.Append(" where "+ whereAfter);
            sqlStr.AppendFormat(") TT where TT.Row > {0} and TT.Row <= {1}", first, last);
            return SQLHelper.ExecuteDs(sqlStr.ToString());
        }
    }
}