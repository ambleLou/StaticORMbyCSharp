using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using sqlHelper;
namespace DAL
{
    public class dbo_users
    {
        public bool Add(Model.dbo_users model)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("insert into dbo.users(");
            sqlStr.Append("[name],[password])");
            sqlStr.Append(" values(");
            sqlStr.Append("@name,@password)");
            
            SqlParameter[] parameters = {
                new SqlParameter("@name", SqlDbType.VarChar,80),
                new SqlParameter("@password", SqlDbType.VarChar,80)
            };
            
            if( model.name==null)
                parameters[0].Value = DBNull.Value;
            else
                parameters[0].Value = model.name;
            if( model.password==null)
                parameters[1].Value = DBNull.Value;
            else
                parameters[1].Value = model.password;
            int result = SQLHelper.ExecuteSql(sqlStr.ToString(),parameters);
            if(result==1){
                return true;
            }
            else{
                return false;
            }
        }
        public bool Delete(Model.dbo_users model)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("delete from dbo.users ");
            sqlStr.Append("where ");
            sqlStr.Append("[id]=@id ");
            SqlParameter[] parameters = {
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            
            if( model.id==null)
                parameters[0].Value = DBNull.Value;
            else
                parameters[0].Value = model.id;
            int result = SQLHelper.ExecuteSql(sqlStr.ToString(),parameters);
            if(result==1){
                return true;
            }
            else{
                return false;
            }
        }
        // this method is used to identity key as pk. not use this method if can change the primay key
        public bool Update(Model.dbo_users model)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("update dbo.users set ");
            
            sqlStr.Append("[name]=@name,");
            sqlStr.Append("[password]=@password");
            sqlStr.Append(" where ");
            
            sqlStr.Append("[id]=@id ");
            SqlParameter[] parameters = {
                new SqlParameter("@id", SqlDbType.Int,4),
                new SqlParameter("@name", SqlDbType.VarChar,80),
                new SqlParameter("@password", SqlDbType.VarChar,80)
            };
            
            if( model.id==null)
                parameters[0].Value = DBNull.Value;
            else
                parameters[0].Value = model.id;
            if( model.name==null)
                parameters[1].Value = DBNull.Value;
            else
                parameters[1].Value = model.name;
            if( model.password==null)
                parameters[2].Value = DBNull.Value;
            else
                parameters[2].Value = model.password;
            int result = SQLHelper.ExecuteSql(sqlStr.ToString(),parameters);
            if(result==1){
                return true;
            }
            else{
                return false;
            }
        }

        public bool Update(Model.dbo_users model,Model.dbo_users oldModel)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("update dbo.users set ");
            
            sqlStr.Append("[name]=@name,");
            sqlStr.Append("[password]=@password");
            sqlStr.Append(" where ");
            
            sqlStr.Append("[id]=@oldid ");
            SqlParameter[] parameters = {
                new SqlParameter("@id", SqlDbType.Int,4),
                new SqlParameter("@name", SqlDbType.VarChar,80),
                new SqlParameter("@password", SqlDbType.VarChar,80),
                new SqlParameter("@oldid", SqlDbType.Int,4),
            };
            
            if( model.id==null)
                parameters[0].Value = DBNull.Value;
            else
                parameters[0].Value = model.id;
            if( model.name==null)
                parameters[1].Value = DBNull.Value;
            else
                parameters[1].Value = model.name;
            if( model.password==null)
                parameters[2].Value = DBNull.Value;
            else
                parameters[2].Value = model.password;
            parameters[3].Value = oldModel.id;
            int result = SQLHelper.ExecuteSql(sqlStr.ToString(),parameters);
            if(result==1){
                return true;
            }
            else{
                return false;
            }
        }

        public Model.dbo_users SelectTop(Model.dbo_users model)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select top 1 * from dbo.users ");
            sqlStr.Append("where ");
            sqlStr.Append("id=@id ");
            SqlParameter[] parameters = {
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.id;
            DataSet result = SQLHelper.ExecuteDs(sqlStr.ToString(),parameters);
            if(result.Tables[0].Rows.Count>0){
                return RowToModel(result.Tables[0].Rows[0]);
            }
            else{
                return null;
            }
        }

        public Model.dbo_users SelectTop(System.Int32 id)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select top 1 * from dbo.users ");
            sqlStr.Append("where ");
            sqlStr.Append("id=@id ");
            SqlParameter[] parameters = {
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            DataSet result = SQLHelper.ExecuteDs(sqlStr.ToString(),parameters);
            if(result.Tables[0].Rows.Count>0){
                return RowToModel(result.Tables[0].Rows[0]);
            }
            else{
                return null;
            }
        }

        public Model.dbo_users SelectTop(Model.dbo_users model, string where)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select top 1 * from dbo.users ");
            sqlStr.Append("where ");
            sqlStr.Append("id=@id ");
            if (where != null)
                sqlStr.Append(" and "+where);
            SqlParameter[] parameters = {
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.id;
            DataSet result = SQLHelper.ExecuteDs(sqlStr.ToString(),parameters);
            if(result.Tables[0].Rows.Count>0){
                return RowToModel(result.Tables[0].Rows[0]);
            }
            else{
                return null;
            }
        }

        public Model.dbo_users SelectTop(string whereAfter)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select top 1 * from dbo.users ");
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
        public Model.dbo_users RowToModel(DataRow row)
        {
            Model.dbo_users model = new Model.dbo_users();
            if(row!=null)
            {
                if(row.Table.Columns.Contains("id")&&row["id"] != null&&row["id"].ToString() != ""){
                    model.id = Int32.Parse(row["id"].ToString());
                }
                if(row.Table.Columns.Contains("name")&&row["name"] != null&&row["name"].ToString() != ""){
                    model.name = row["name"].ToString();
                }
                if(row.Table.Columns.Contains("password")&&row["password"] != null&&row["password"].ToString() != ""){
                    model.password = row["password"].ToString();
                }
            }
            return model;
        }
        public DataSet GetList(string whereAfter)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select * ");
            sqlStr.Append("from dbo.users ");
            if(!string.IsNullOrEmpty(whereAfter)){
                sqlStr.Append("where "+whereAfter);
            }
            return SQLHelper.ExecuteDs(sqlStr.ToString());
        }

        public DataSet GetList(int top, string whereAfter)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select top "+ top.ToString() +" * ");
            sqlStr.Append("from dbo.users ");
            if(!string.IsNullOrEmpty(whereAfter)){
                sqlStr.Append("where "+whereAfter);
            }
            return SQLHelper.ExecuteDs(sqlStr.ToString());
        }

        public DataSet GetListDistinct(int top, string whereAfter)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select distinct top "+ top.ToString() +" * ");
            sqlStr.Append("from dbo.users ");
            if(!string.IsNullOrEmpty(whereAfter)){
                sqlStr.Append("where "+whereAfter);
            }
            return SQLHelper.ExecuteDs(sqlStr.ToString());
        }
        public List<Model.dbo_users> DataSetToList(DataSet ds)
        {
            List<Model.dbo_users> modelList = new List<Model.dbo_users >();
            if(ds.Tables[0].Rows.Count>0){
                for(int i=0;i<ds.Tables[0].Rows.Count;i++){
                    Model.dbo_users model = RowToModel(ds.Tables[0].Rows[i]);
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
            sqlStr.Append(") as Row, T.* from dbo.users T");
            if(!string.IsNullOrEmpty(whereAfter.Trim()))
                sqlStr.Append(" where "+ whereAfter);
            sqlStr.AppendFormat(") TT where TT.Row > {0} and TT.Row <= {1}", first, last);
            return SQLHelper.ExecuteDs(sqlStr.ToString());
        }
    }
}