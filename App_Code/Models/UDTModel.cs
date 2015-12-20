using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace colModel
{
    //some type is defined by user
    //this modle is the mapping of user defined type and system defined type
    public class UDTModel
    {
        private List<string> _UDTType;
        private List<string> _realType;
        private List<string> _len;

        public List<string> UDTType {
            get { return _UDTType; }
            set { _UDTType = value; }
        }

        public List<string> realType
        {
            get { return _realType; }
            set { _realType = value; }
        }

        public List<string> len
        {
            get { return _len; }
            set { _len = value; }
        }
    }
}
