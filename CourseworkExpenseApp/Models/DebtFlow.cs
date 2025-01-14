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

        [Required(ErrorMessage = "Debt Flow Source is required.")]
        [StringLength(100, ErrorMessage = "Debt Flow Source cannot exceed 100 characters.")]
        public string DebtFormSource { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Due Date is required.")]
        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = "Transaction Date is required.")]
        public DateTime? TransactionDate { get; set; }

        [Required(ErrorMessage = "Tag is required.")]
        public string Tag { get; set; } // Optional, can be null

        public string CustomTag { get; set; } // Optional, can be null
        public string Notes { get; set; } // Optional, can be null

        public string FlowType { get; set; }
        public bool IsCleared { get; set; }
    }


}
