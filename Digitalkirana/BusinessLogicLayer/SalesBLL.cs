using System;
using System.Data;

namespace Digitalkirana.BusinessLogicLayer
{
    public class SalesBLL
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal GrandTotal { get; set; }
        public DateTime Date { get; set; }
        public decimal Tax { get; set; }
        public decimal Discount { get; set; }
        public int AddedBy { get; set; }
        public DataTable SalesDetails { get; set; }
    }
}
