using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using getTableInfo;
using tableModel;
using sqlHelper;
using createModel;
using createDAL;

public partial class _Default : System.Web.UI.Page
{
    List<TableModel> tableModels;   //table model with table full name and column details
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCreateORM_Click(object sender, EventArgs e)
    {
        GetTableInfo();
        string curRoot = HttpRuntime.AppDomainAppPath.ToString();

        foreach (TableModel model in tableModels)
        {
            string modelPath = curRoot + @"\APP_Code\ORM\Model\";
            string dalPath = curRoot + @"\APP_Code\ORM\DAL\";
            //create models
            CreateModel createModel = new CreateModel();
            createModel.CreateModelFile(modelPath, "", model);
            //create DALs
            CreateDAL createDAL = new CreateDAL();
            createDAL.CreateDALFile(dalPath, "", model);
        }
    }

    private void GetTableInfo()
    {
        if (tableModels == null)
        {
            //get table info
            GetTableInfo getTableInfoObj = new GetTableInfo();
            tableModels = getTableInfo.GetTableInfo.GetTablesInfo();
        }
    }
}