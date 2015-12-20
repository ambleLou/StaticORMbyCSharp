using System;
namespace Model
{
    public class dbo_Purchance
    {
        private Int32? _ID;
        private Int32? _StatusID;
        private String _PartName;
        private Int32? _Qty;
        private Int32? _SumPrice;
        private Int32? _Exchange;
        public Int32? ID
        {
            set { _ID =value; }
            get { return _ID; }
        }
        public Int32? StatusID
        {
            set { _StatusID =value; }
            get { return _StatusID; }
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
        public Int32? SumPrice
        {
            set { _SumPrice =value; }
            get { return _SumPrice; }
        }
        public Int32? Exchange
        {
            set { _Exchange =value; }
            get { return _Exchange; }
        }
    }
}