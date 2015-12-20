using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tableModel;


namespace CreateMethod
{
    public class FunctionDataSetToList
    {
        public string CreateFunctionDataSetToList(string dbName, TableModel tableModel)
        {
            string result = "";
            if (tableModel != null) {
                string modelType = dbName + "Model." + tableModel.className;
                result = @"
        public List<" + modelType + @"> DataSetToList(DataSet ds)
        {
            List<" + modelType + "> modelList = new List<" + modelType + @" >();
            if(ds.Tables[0].Rows.Count>0){
                for(int i=0;i<ds.Tables[0].Rows.Count;i++){
                    " + modelType + @" model = RowToModel(ds.Tables[0].Rows[i]);
                    modelList.Add(model);
                }
            }
            return modelList;
        }";
            }
            return result;
        }
    }
}