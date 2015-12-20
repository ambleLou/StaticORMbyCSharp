using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using sqlHelper;
using System.Data;
using colModel;
using tableModel;

namespace getTableInfo
{
    /* this class is to get the list of models of tables which is need exchange(in mapping xml)
     * every table has a tableModel calss, and all the front operate is depending on this model
     * every col model contains cols name, type, length
     * the calssName of a table is used for program, and the tableName is used for splite the schema name and real table name
     * pk and UDT must base on the real table
     */
    public class GetTableInfo
    {
        public static TableModel GetTableModel(string tableName)
        {
            List<ColModel> colModels = new List<ColModel>();
            TableModel tableModel = new TableModel();
            string sqlStr = @"
                                select Col.name as colName,T.name as colType,Col.max_length as colLen, Col.is_nullable as nullable, Col.is_identity as isIdentity, Col.is_computed as isComputed
                                from sys.columns Col left join sys.types T on Col.system_type_id=T.system_type_id and Col.user_type_id=T.user_type_id
                                where Col.object_id = OBJECT_ID('" + tableName + "')";
            //for special tableName
            if (tableName[0] == '\'' && tableName[tableName.Length - 1] == '\'')
            {
                sqlStr = @"
                                select Col.name as colName,T.name as colType,Col.max_length as colLen, Col.is_nullable as nullable, Col.is_identity as isIdentity, Col.is_computed as isComputed
                                from sys.columns Col left join sys.types T on Col.system_type_id=T.system_type_id and Col.user_type_id=T.user_type_id
                                where Col.object_id = OBJECT_ID(N''" + tableName + "'')";
            }
            DataSet colTable = SQLHelper.ExecuteDs(sqlStr);

            foreach (DataRow row in colTable.Tables[0].Rows)
            {
                ColModel col = new ColModel();
                col.name = row["colName"].ToString();
                col.type = row["colType"].ToString();
                col.len = row["colLen"].ToString();

                //for the maxlen of nvarchar is double
                if ((col.type.Equals("nvarchar") || col.type.Equals("nchar")) && !col.len.Equals("-1"))
                {
                    int len = int.Parse(col.len);
                    len = len / 2;
                    col.len = len.ToString();
                }
                //for the len max about varchar(max)
                if (col.len.Equals("-1"))
                    col.len = "4000";
                ////-----------------------

                if (row["nullable"].ToString().ToLower().Equals("true") || row["nullable"].ToString().Equals("1"))
                    col.isNullable = 1;
                else
                    col.isNullable = 0;

                if (row["isIdentity"].ToString().ToLower().Equals("true") || row["isIdentity"].ToString().Equals("1"))
                    col.isIdentity = 1;
                else
                    col.isIdentity = 0;

                if (row["isComputed"].ToString().ToLower().Equals("true") || row["isComputed"].ToString().ToLower().Equals("1"))
                    col.isComputed = 1;
                else
                    col.isComputed = 0;

                /*
                 * if the column is computed, it will not exchenge to dest, because it will be very complex to exchange to local
                 * it need to create models and dals for local database not only to tempdb for insert method
                 * hlou:explain more...
                 */
                if (col.isComputed == 0)
                    colModels.Add(col);
            }
            if (colModels.Count > 0)
            {
                tableModel.models = colModels;
            }
            else
            {
                tempLog.ErrLog.ErrLogToFile("no cols");
                return null;
            }

            //get the key column, not use tempdb
            sqlStr = @"
EXEC sp_pkeys @table_name = N'" + tableName.Substring(tableName.IndexOf('.') + 1) + @"',@table_owner = N'" + tableName.Substring(0, tableName.IndexOf('.')) + @"'";
            DataSet KPTable = SQLHelper.ExecuteDs(sqlStr);
            List<string> PKs = new List<string>();
            foreach (DataRow row in KPTable.Tables[0].Rows)
            {
                PKs.Add(row["COLUMN_NAME"].ToString());
            }
            if (PKs != null)
            {
                tableModel.PKs = PKs;
            }
            tableModel.className = tableName.Replace('.', '_'); //class for program
            tableModel.tableName = tableName;
            return tableModel;
        }

        /// <summary>
        /// get the table detail info, columns info
        /// </summary>
        /// <returns>List of TableModel</returns>
        public static List<TableModel> GetTablesInfo()
        {
            DataSet ds;
            List<TableModel> tablesinfo = new List<TableModel>();
            string sqlStr = @"
SELECT s.name AS SchemaName, 
       t.name tableName 
FROM   sys.tables AS t 
       INNER JOIN sys.schemas AS s 
               ON t.[schema_id] = s.[schema_id]
where t.type='u' and t.name not in ('sysdiagrams')";
            //视图部分
            //+@" 
            //union
            //SELECT s.name AS SchemaName, 
            //       t.name tableName 
            //FROM   sys.views AS t 
            //       INNER JOIN sys.schemas AS s 
            //               ON t.[schema_id] = s.[schema_id]
            //where t.type='v' and t.name not in ('sysdiagrams')";
            ds = SQLHelper.ExecuteDs(sqlStr);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                TableModel model = new TableModel();
                string tableName = row[0].ToString() + "." + row[1].ToString(); //table name with schema
                if (row[0] == null)
                    tableName = "dbo." + row[1].ToString(); //default is dbo
                //judge if the tableName is Needed to Exchenge, only the table in mapping xml is need to exchange
                //DBInfoReader dbInforReader = new DBInfoReader();
                //DBInfoModel dbInfoModel = new DBInfoModel();
                //dbInfoModel = dbInforReader.GetDBInfoModel();
                //if (dbInfoModel.LocalTableNames.Contains(tableName))
                //{
                //    model = GetTableModel(tableName);
                //    tablesinfo.Add(model);
                //}
                model = GetTableModel(tableName);
                tablesinfo.Add(model);
            }
            return tablesinfo;
        }
    }
}