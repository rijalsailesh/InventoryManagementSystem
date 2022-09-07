using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalkirana.BusinessLogicLayer
{
    public class PurchaseBLL
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public decimal GrandTotal { get; set; }
        public DateTime Date { get; set; }
        public decimal Tax { get; set; }
        public decimal Discount { get; set; }
        public int AddedBy { get; set; }
        public DataTable PurchaseDetails { get; set; }
    }
}
