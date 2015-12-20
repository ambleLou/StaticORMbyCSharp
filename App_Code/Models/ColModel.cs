using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace colModel
{
    public class ColModel
    {
        private string _name;
        private string _type;
        private string _len;
        private int _isNullable;
        private int _isIdentity;
        private int _isComputed;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string len
        {
            get { return _len; }
            set { _len = value; }
        }

        public int isNullable
        {
            get { return _isNullable; }
            set { _isNullable = value; }
        }

        public int isIdentity
        {
            get { return _isIdentity; }
            set { _isIdentity = value; }
        }

        public int isComputed {
            get { return _isComputed; }
            set { _isComputed = value; }
        }
    }
}