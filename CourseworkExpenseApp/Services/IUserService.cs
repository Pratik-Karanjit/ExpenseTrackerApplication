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
    public interface IUserService
    {
        Task SaveUserAsync(User user);

        Task<List<User>> LoadUsersAsync();
    }
}
