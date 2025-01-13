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

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Flow Type is required.")]
        public string FlowType { get; set; }

        [Required(ErrorMessage = "Transaction Title is required.")]
        [StringLength(100, ErrorMessage = "Transaction Title cannot exceed 100 characters.")]
        public string TransactionTitle { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "Tag is required.")]
        public string Tag { get; set; }
        public string CustomTag { get; set; } // Optional, can be null
        public string Notes { get; set; } // Optional, can be null
    }

}
