using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkExpenseApp.Models
{
    public class CashFlow
    {
        public string CashFlowId { get; set; }
        public decimal Amount { get; set; }
        public string FlowType { get; set; } // "Inflow" or "Outflow"
        public string TransactionTitle { get; set; }
        public DateTime? Date { get; set; }
        public string Tag { get; set; } 
        public string CustomTag { get; set; } // Optional, can be null
        public string Notes { get; set; } // Optional, can be null
    }

}
