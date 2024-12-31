using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CourseworkExpenseApp.Models;

namespace CourseworkExpenseApp.Services
{
    public interface IDebtFlowService
    {
        Task SaveDebtFlowAsync(DebtFlow debtFlow);

        Task<List<DebtFlow>> LoadDebtFlowAsync();
    }
}
