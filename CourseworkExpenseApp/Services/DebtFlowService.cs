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
    public class DebtFlowService : IDebtFlowService
    {
        private readonly string debtFlowFilePath = Path.Combine(AppContext.BaseDirectory, "DebtFlowDetails.json");

        public async Task SaveDebtFlowAsync(DebtFlow debtFlow)
        {
            try
            {
                var debtFlows = await LoadDebtFlowAsync();

                debtFlows.Add(debtFlow);
                await SaveDebtFlowAsync(debtFlows);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving debt flow: {ex.Message}");
                throw;
            }
        }

        public async Task<List<DebtFlow>> LoadDebtFlowAsync()
        {
            try
            {
                if (!File.Exists(debtFlowFilePath))
                {
                    return new List<DebtFlow>();
                }


                var json = await File.ReadAllTextAsync(debtFlowFilePath);
                return JsonSerializer.Deserialize<List<DebtFlow>>(json) ?? new List<DebtFlow>();
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"JSON deserialization error: {jsonEx.Message}");
                return new List<DebtFlow>();
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"I/O error while loading DebtFlow: {ioEx.Message}");
                return new List<DebtFlow>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error while loading DebtFlow: {ex.Message}");
                return new List<DebtFlow>();
            }
        }

        private async Task SaveDebtFlowAsync(List<DebtFlow> debtFlows)
        {
            try
            {
                var json = JsonSerializer.Serialize(debtFlows, new JsonSerializerOptions { WriteIndented = true });

                await File.WriteAllTextAsync(debtFlowFilePath, json);
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"I/O error while loading DebtFlow: {ioEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error while saving DebtFlow: {ex.Message}");
                throw;
            }
        }
        public async Task MarkAsClearedAsync(string debtFormId)
        {
            try
            {
                var debtFlows = await LoadDebtFlowAsync();

                var debtFlow = debtFlows.FirstOrDefault(df => df.DebtFormId == debtFormId);
                if (debtFlow == null)
                {
                    throw new Exception($"No debt flow found with DebtFormId: {debtFormId}");
                }

                debtFlow.IsCleared = true;
                await SaveDebtFlowAsync(debtFlows);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error marking debt flow as cleared: {ex.Message}");
                throw;
            }

        }
    }
}