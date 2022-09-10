using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalkirana.BusinessLogicLayer
{
    public class SalesDetailsBLL
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public decimal Rate { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
        public int CustomerId { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public int SalesId { get; set; }
    }
}
