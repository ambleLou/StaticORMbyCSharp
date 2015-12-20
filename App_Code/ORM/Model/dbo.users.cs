using System;
namespace Model
{
    public class dbo_users
    {
        private Int32? _id;
        private String _name;
        private String _password;
        public Int32? id
        {
            set { _id =value; }
            get { return _id; }
        }
        public String name
        {
            set { _name =value; }
            get { return _name; }
        }
        public String password
        {
            set { _password =value; }
            get { return _password; }
        }
    }
}