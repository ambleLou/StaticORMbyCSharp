using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tableModel;
using colModel;
using SQLToCSharpNamespace;

namespace CreateMethod
{
    public class FunctionRowToModel
    {
        public string CreateFuntionRowToModel(string dbName, TableModel tableModel)
        {
            string result = "";
            if (tableModel != null) {
                string modelEnvaluation = GetModelEnvaluation(tableModel);
                string modelType = dbName + @"Model." + tableModel.className;
                result = @"
        public " + modelType + @" RowToModel(DataRow row)
        {
            " + modelType + " model = new " + modelType + @"();
            if(row!=null)
            {" +
            modelEnvaluation + @"
            }
            return model;
        }";
            }
            return result;
        }

        protected string GetModelEnvaluation(TableModel tableModel)
        {
            string result = "";
            if (tableModel != null && tableModel.models.Count > 0) {
                foreach (ColModel model in tableModel.models)
                {
                    Type CSharpType = SQLToCSharp.SqlTypeToCSharpType(model.type);
                    string sqlValue = @"row[""" + model.name + @"""].ToString()";
                    //for different type, rowToModel will get the different model property
                    string parseValue = "";
                    if (CSharpType.Name.ToLower().Equals("string"))
                        parseValue = @"
                    model." + model.name.Replace(' ', '_') + " = " + sqlValue + ";";
                    else if (CSharpType.Name.Equals("bool"))
                        parseValue = @"
                    if(" + sqlValue + @"==""1""||" + sqlValue + @"==""true""
                        model." + model.name.Replace(' ', '_') + @" = true;
                    else
                        model." + model.name.Replace(' ', '_') + @" = false;";
                    else if (CSharpType.Name.Equals("Object"))
                        parseValue = @"
                    model." + model.name.Replace(' ', '_') + " = " + sqlValue + ";";
                    else
                        parseValue = @"
                    model." + model.name.Replace(' ', '_') + " = " + CSharpType.Name + ".Parse(" + sqlValue + ");";

                    string envaluation = @"
                if(row.Table.Columns.Contains(""" + model.name + @""")&&row[""" + model.name + @"""] != null&&row[""" + model.name + @"""].ToString() != """"){" +
                    parseValue + @"
                }";
                    result += envaluation;
                }
            }
            return result;
        }
    }
}