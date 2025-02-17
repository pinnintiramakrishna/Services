﻿using DataService.Data;
using DataService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repositories
{
    public class EmployeeLoginRepository : IEmployeeLoginRepository
    {
        private readonly DataBaseContext _dbContext;
        private readonly ILogger _logger;
        public EmployeeLoginRepository(DataBaseContext dbContext, ILogger<EmployeeLoginRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<bool> Validate(string username, string password)
        {
            try
            {
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    var Obj = await _dbContext.EmployeeLogin.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
                    if (Obj != null) return true;
                    else return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex) { _logger.LogError(ex.ToString()); throw; }
        }
    }
}
