using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using sqlHelper;
namespace DAL
{
    public class dbo_PO
    {
        public bool Add(Model.dbo_PO model)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("insert into dbo.PO(");
            sqlStr.Append("[POID],[PartName],[Qty],[StatusID],[Price],[EmployeeName],[Exchange])");
            sqlStr.Append(" values(");
            sqlStr.Append("@POID,@PartName,@Qty,@StatusID,@Price,@EmployeeName,@Exchange)");
            
            SqlParameter[] parameters = {
                new SqlParameter("@POID", SqlDbType.Int,4),
                new SqlParameter("@PartName", SqlDbType.VarChar,50),
                new SqlParameter("@Qty", SqlDbType.Int,4),
                new SqlParameter("@StatusID", SqlDbType.Int,4),
                new SqlParameter("@Price", SqlDbType.Float,8),
                new SqlParameter("@EmployeeName", SqlDbType.VarChar,100),
                new SqlParameter("@Exchange", SqlDbType.Int,4)
            };
            
            if( model.POID==null)
                parameters[0].Value = DBNull.Value;
            else
                parameters[0].Value = model.POID;
            if( model.PartName==null)
                parameters[1].Value = DBNull.Value;
            else
                parameters[1].Value = model.PartName;
            if( model.Qty==null)
                parameters[2].Value = DBNull.Value;
            else
                parameters[2].Value = model.Qty;
            if( model.StatusID==null)
                parameters[3].Value = DBNull.Value;
            else
                parameters[3].Value = model.StatusID;
            if( model.Price==null)
                parameters[4].Value = DBNull.Value;
            else
                parameters[4].Value = model.Price;
            if( model.EmployeeName==null)
                parameters[5].Value = DBNull.Value;
            else
                parameters[5].Value = model.EmployeeName;
            if( model.Exchange==null)
                parameters[6].Value = DBNull.Value;
            else
                parameters[6].Value = model.Exchange;
            int result = SQLHelper.ExecuteSql(sqlStr.ToString(),parameters);
            if(result==1){
                return true;
            }
            else{
                return false;
            }
        }
        public bool Delete(Model.dbo_PO model)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("delete from dbo.PO ");
            sqlStr.Append("where ");
            sqlStr.Append("[POID]=@POID ");
            SqlParameter[] parameters = {
                new SqlParameter("@POID", SqlDbType.Int,4)
            };
            
            if( model.POID==null)
                parameters[0].Value = DBNull.Value;
            else
                parameters[0].Value = model.POID;
            int result = SQLHelper.ExecuteSql(sqlStr.ToString(),parameters);
            if(result==1){
                return true;
            }
            else{
                return false;
            }
        }
        // this method is used to identity key as pk. not use this method if can change the primay key
        public bool Update(Model.dbo_PO model)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("update dbo.PO set ");
            
            sqlStr.Append("[POID]=@POID,");
            sqlStr.Append("[PartName]=@PartName,");
            sqlStr.Append("[Qty]=@Qty,");
            sqlStr.Append("[StatusID]=@StatusID,");
            sqlStr.Append("[Price]=@Price,");
            sqlStr.Append("[EmployeeName]=@EmployeeName,");
            sqlStr.Append("[Exchange]=@Exchange");
            sqlStr.Append(" where ");
            
            sqlStr.Append("[POID]=@POID ");
            SqlParameter[] parameters = {
                new SqlParameter("@POID", SqlDbType.Int,4),
                new SqlParameter("@PartName", SqlDbType.VarChar,50),
                new SqlParameter("@Qty", SqlDbType.Int,4),
                new SqlParameter("@StatusID", SqlDbType.Int,4),
                new SqlParameter("@Price", SqlDbType.Float,8),
                new SqlParameter("@EmployeeName", SqlDbType.VarChar,100),
                new SqlParameter("@Exchange", SqlDbType.Int,4)
            };
            
            if( model.POID==null)
                parameters[0].Value = DBNull.Value;
            else
                parameters[0].Value = model.POID;
            if( model.PartName==null)
                parameters[1].Value = DBNull.Value;
            else
                parameters[1].Value = model.PartName;
            if( model.Qty==null)
                parameters[2].Value = DBNull.Value;
            else
                parameters[2].Value = model.Qty;
            if( model.StatusID==null)
                parameters[3].Value = DBNull.Value;
            else
                parameters[3].Value = model.StatusID;
            if( model.Price==null)
                parameters[4].Value = DBNull.Value;
            else
                parameters[4].Value = model.Price;
            if( model.EmployeeName==null)
                parameters[5].Value = DBNull.Value;
            else
                parameters[5].Value = model.EmployeeName;
            if( model.Exchange==null)
                parameters[6].Value = DBNull.Value;
            else
                parameters[6].Value = model.Exchange;
            int result = SQLHelper.ExecuteSql(sqlStr.ToString(),parameters);
            if(result==1){
                return true;
            }
            else{
                return false;
            }
        }

        public bool Update(Model.dbo_PO model,Model.dbo_PO oldModel)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("update dbo.PO set ");
            
            sqlStr.Append("[POID]=@POID,");
            sqlStr.Append("[PartName]=@PartName,");
            sqlStr.Append("[Qty]=@Qty,");
            sqlStr.Append("[StatusID]=@StatusID,");
            sqlStr.Append("[Price]=@Price,");
            sqlStr.Append("[EmployeeName]=@EmployeeName,");
            sqlStr.Append("[Exchange]=@Exchange");
            sqlStr.Append(" where ");
            
            sqlStr.Append("[POID]=@oldPOID ");
            SqlParameter[] parameters = {
                new SqlParameter("@POID", SqlDbType.Int,4),
                new SqlParameter("@PartName", SqlDbType.VarChar,50),
                new SqlParameter("@Qty", SqlDbType.Int,4),
                new SqlParameter("@StatusID", SqlDbType.Int,4),
                new SqlParameter("@Price", SqlDbType.Float,8),
                new SqlParameter("@EmployeeName", SqlDbType.VarChar,100),
                new SqlParameter("@Exchange", SqlDbType.Int,4),
                new SqlParameter("@oldPOID", SqlDbType.Int,4),
            };
            
            if( model.POID==null)
                parameters[0].Value = DBNull.Value;
            else
                parameters[0].Value = model.POID;
            if( model.PartName==null)
                parameters[1].Value = DBNull.Value;
            else
                parameters[1].Value = model.PartName;
            if( model.Qty==null)
                parameters[2].Value = DBNull.Value;
            else
                parameters[2].Value = model.Qty;
            if( model.StatusID==null)
                parameters[3].Value = DBNull.Value;
            else
                parameters[3].Value = model.StatusID;
            if( model.Price==null)
                parameters[4].Value = DBNull.Value;
            else
                parameters[4].Value = model.Price;
            if( model.EmployeeName==null)
                parameters[5].Value = DBNull.Value;
            else
                parameters[5].Value = model.EmployeeName;
            if( model.Exchange==null)
                parameters[6].Value = DBNull.Value;
            else
                parameters[6].Value = model.Exchange;
            parameters[7].Value = oldModel.POID;
            int result = SQLHelper.ExecuteSql(sqlStr.ToString(),parameters);
            if(result==1){
                return true;
            }
            else{
                return false;
            }
        }

        public Model.dbo_PO SelectTop(Model.dbo_PO model)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select top 1 * from dbo.PO ");
            sqlStr.Append("where ");
            sqlStr.Append("POID=@POID ");
            SqlParameter[] parameters = {
                new SqlParameter("@POID", SqlDbType.Int,4)
            };
            parameters[0].Value = model.POID;
            DataSet result = SQLHelper.ExecuteDs(sqlStr.ToString(),parameters);
            if(result.Tables[0].Rows.Count>0){
                return RowToModel(result.Tables[0].Rows[0]);
            }
            else{
                return null;
            }
        }

        public Model.dbo_PO SelectTop(System.Int32 POID)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select top 1 * from dbo.PO ");
            sqlStr.Append("where ");
            sqlStr.Append("POID=@POID ");
            SqlParameter[] parameters = {
                new SqlParameter("@POID", SqlDbType.Int,4)
            };
            parameters[0].Value = POID;
            DataSet result = SQLHelper.ExecuteDs(sqlStr.ToString(),parameters);
            if(result.Tables[0].Rows.Count>0){
                return RowToModel(result.Tables[0].Rows[0]);
            }
            else{
                return null;
            }
        }

        public Model.dbo_PO SelectTop(Model.dbo_PO model, string where)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select top 1 * from dbo.PO ");
            sqlStr.Append("where ");
            sqlStr.Append("POID=@POID ");
            if (where != null)
                sqlStr.Append(" and "+where);
            SqlParameter[] parameters = {
                new SqlParameter("@POID", SqlDbType.Int,4)
            };
            parameters[0].Value = model.POID;
            DataSet result = SQLHelper.ExecuteDs(sqlStr.ToString(),parameters);
            if(result.Tables[0].Rows.Count>0){
                return RowToModel(result.Tables[0].Rows[0]);
            }
            else{
                return null;
            }
        }

        public Model.dbo_PO SelectTop(string whereAfter)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select top 1 * from dbo.PO ");
            if (!string.IsNullOrEmpty(whereAfter))
            {
                sqlStr.Append("where " + whereAfter);
            }
            DataSet result = SQLHelper.ExecuteDs(sqlStr.ToString());
            if(result.Tables[0].Rows.Count>0){
                return RowToModel(result.Tables[0].Rows[0]);
            }
            else{
                return null;
            }
        }
        public Model.dbo_PO RowToModel(DataRow row)
        {
            Model.dbo_PO model = new Model.dbo_PO();
            if(row!=null)
            {
                if(row.Table.Columns.Contains("POID")&&row["POID"] != null&&row["POID"].ToString() != ""){
                    model.POID = Int32.Parse(row["POID"].ToString());
                }
                if(row.Table.Columns.Contains("PartName")&&row["PartName"] != null&&row["PartName"].ToString() != ""){
                    model.PartName = row["PartName"].ToString();
                }
                if(row.Table.Columns.Contains("Qty")&&row["Qty"] != null&&row["Qty"].ToString() != ""){
                    model.Qty = Int32.Parse(row["Qty"].ToString());
                }
                if(row.Table.Columns.Contains("StatusID")&&row["StatusID"] != null&&row["StatusID"].ToString() != ""){
                    model.StatusID = Int32.Parse(row["StatusID"].ToString());
                }
                if(row.Table.Columns.Contains("Price")&&row["Price"] != null&&row["Price"].ToString() != ""){
                    model.Price = Double.Parse(row["Price"].ToString());
                }
                if(row.Table.Columns.Contains("EmployeeName")&&row["EmployeeName"] != null&&row["EmployeeName"].ToString() != ""){
                    model.EmployeeName = row["EmployeeName"].ToString();
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
            sqlStr.Append("from dbo.PO ");
            if(!string.IsNullOrEmpty(whereAfter)){
                sqlStr.Append("where "+whereAfter);
            }
            return SQLHelper.ExecuteDs(sqlStr.ToString());
        }

        public DataSet GetList(int top, string whereAfter)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select top "+ top.ToString() +" * ");
            sqlStr.Append("from dbo.PO ");
            if(!string.IsNullOrEmpty(whereAfter)){
                sqlStr.Append("where "+whereAfter);
            }
            return SQLHelper.ExecuteDs(sqlStr.ToString());
        }

        public DataSet GetListDistinct(int top, string whereAfter)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select distinct top "+ top.ToString() +" * ");
            sqlStr.Append("from dbo.PO ");
            if(!string.IsNullOrEmpty(whereAfter)){
                sqlStr.Append("where "+whereAfter);
            }
            return SQLHelper.ExecuteDs(sqlStr.ToString());
        }
        public List<Model.dbo_PO> DataSetToList(DataSet ds)
        {
            List<Model.dbo_PO> modelList = new List<Model.dbo_PO >();
            if(ds.Tables[0].Rows.Count>0){
                for(int i=0;i<ds.Tables[0].Rows.Count;i++){
                    Model.dbo_PO model = RowToModel(ds.Tables[0].Rows[i]);
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
            sqlStr.Append(") as Row, T.* from dbo.PO T");
            if(!string.IsNullOrEmpty(whereAfter.Trim()))
                sqlStr.Append(" where "+ whereAfter);
            sqlStr.AppendFormat(") TT where TT.Row > {0} and TT.Row <= {1}", first, last);
            return SQLHelper.ExecuteDs(sqlStr.ToString());
        }
    }
}