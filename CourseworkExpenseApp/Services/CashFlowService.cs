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
    public class CashFlowService : ICashFlowService
    {
        private readonly string cashFlowFilePath = Path.Combine(AppContext.BaseDirectory, "CashFlowDetails.json");

        public async Task SaveCashFlowAsync(CashFlow cashFlow)
        {
            try
            {
                var cashFlows = await LoadCashFlowAsync();

                cashFlows.Add(cashFlow);
                await SaveCashFlowAsync(cashFlows);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving cash flow: {ex.Message}");
                throw;
            }
        }

        public async Task<List<CashFlow>> LoadCashFlowAsync()
        {
            try
            {
                if (!File.Exists(cashFlowFilePath))
                {
                    return new List<CashFlow>();
                }


                var json = await File.ReadAllTextAsync(cashFlowFilePath);
                return JsonSerializer.Deserialize<List<CashFlow>>(json) ?? new List<CashFlow>();
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"JSON deserialization error: {jsonEx.Message}");
                return new List<CashFlow>();
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"I/O error while loading CashFlow: {ioEx.Message}");
                return new List<CashFlow>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error while loading CashFlow: {ex.Message}");
                return new List<CashFlow>();
            }
        }

        private async Task SaveCashFlowAsync(List<CashFlow> cashFlows)
        {
            try
            {
                var json = JsonSerializer.Serialize(cashFlows, new JsonSerializerOptions { WriteIndented = true });

                await File.WriteAllTextAsync(cashFlowFilePath, json);
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"I/O error while loading CashFlow: {ioEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error while saving CashFlow: {ex.Message}");
                throw;
            }
        }
    }
}