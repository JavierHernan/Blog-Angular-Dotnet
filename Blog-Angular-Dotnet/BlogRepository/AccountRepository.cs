using Blog.Models.Account;
using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Blog.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IConfiguration _config;
        private readonly ILogger<AccountRepository> _logger;
        public AccountRepository(IConfiguration config, ILogger<AccountRepository> logger)
        {
            _config = config;
            _logger = logger;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUserIdentity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var dataTable = new DataTable();
            dataTable.Columns.Add("Username", typeof(string));
            dataTable.Columns.Add("NormalizedUsername", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("NormalizedEmail", typeof(string));
            dataTable.Columns.Add("Fullname", typeof(string));
            dataTable.Columns.Add("PasswordHash", typeof(string));

            dataTable.Rows.Add(
                user.Username,
                user.NormalizedUsername,
                user.Email,
                user.NormalizedEmail,
                user.Fullname,
                user.PasswordHash
                );
            //creates connection with sql server
            using (var connection = new Microsoft.Data.SqlClient.SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await connection.OpenAsync(cancellationToken);

                await connection.ExecuteAsync("Account_Insert",
                new { Account = dataTable.AsTableValuedParameter("dbo.AccountType") }, commandType: CommandType.StoredProcedure);
            }
                return IdentityResult.Success;
        }

        public async Task<ApplicationUserIdentity> GetByUsernameAsync(string normalizedUsername, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            ApplicationUserIdentity applicationUser;

            using (var connection = new Microsoft.Data.SqlClient.SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await connection.OpenAsync(cancellationToken);

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                applicationUser = await connection.QuerySingleOrDefaultAsync<ApplicationUserIdentity>(
                    "Account_GetByUsername", 
                    new { NormalizedUsername = normalizedUsername },
                    commandType: CommandType.StoredProcedure
                    );
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            }
            if (applicationUser == null)
            {
                _logger.LogWarning("User with normalized username '{NormalizedUsername}' not found. This is in AccountRepository.cs in Blog.Repository.", normalizedUsername);
            }
            return applicationUser;
        }
    }
}
