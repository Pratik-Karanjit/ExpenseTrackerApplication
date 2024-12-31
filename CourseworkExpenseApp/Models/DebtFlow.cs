using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkExpenseApp.Models

{
    public class DebtFlow
    {
        public string DebtFormId { get; set; }
        public string DebtFormSource { get; set; }
        public decimal Amount { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string Tag { get; set; } // Optional, can be null
        public string CustomTag { get; set; } // Optional, can be null
        public string Notes { get; set; } // Optional, can be null

    }

}
