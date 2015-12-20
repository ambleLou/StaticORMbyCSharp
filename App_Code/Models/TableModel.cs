using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using colModel;

namespace tableModel
{
    public class TableModel
    {
        private string _tableName;
        private string _className;
        private List<ColModel> _models;
        private List<string> _PKs;

        public string tableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        public string className
        {
            get { return _className; }
            set { _className = value; }
        }

        public List<ColModel> models
        {
            get { return _models; }
            set { _models = value; }
        }

        public List<string> PKs
        {
            get { return _PKs; }
            set { _PKs = value; }
        }
    }
}