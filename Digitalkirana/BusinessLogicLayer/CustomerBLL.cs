using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalkirana.BusinessLogicLayer
{
    public class CustomerBLL
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
