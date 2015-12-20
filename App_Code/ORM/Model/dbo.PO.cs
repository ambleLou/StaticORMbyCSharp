using System;
namespace Model
{
    public class dbo_PO
    {
        private Int32? _POID;
        private String _PartName;
        private Int32? _Qty;
        private Int32? _StatusID;
        private Double? _Price;
        private String _EmployeeName;
        private Int32? _Exchange;
        public Int32? POID
        {
            set { _POID =value; }
            get { return _POID; }
        }
        public String PartName
        {
            set { _PartName =value; }
            get { return _PartName; }
        }
        public Int32? Qty
        {
            set { _Qty =value; }
            get { return _Qty; }
        }
        public Int32? StatusID
        {
            set { _StatusID =value; }
            get { return _StatusID; }
        }
        public Double? Price
        {
            set { _Price =value; }
            get { return _Price; }
        }
        public String EmployeeName
        {
            set { _EmployeeName =value; }
            get { return _EmployeeName; }
        }
        public Int32? Exchange
        {
            set { _Exchange =value; }
            get { return _Exchange; }
        }
    }
}