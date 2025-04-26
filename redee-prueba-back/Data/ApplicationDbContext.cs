using Microsoft.EntityFrameworkCore;
using redee_prueba_back.Entities;

namespace redee_prueba_back.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }



           public DbSet<Company> Companies { get; set; }

        // Metos de store procedures

        public virtual Task<List<Company>> GetAllCompaniesAsync() => Set<Company>()
            .FromSqlRaw("EXECUTE dbo.GetAllCompanies_SP")
            .ToListAsync();

        public virtual async Task<Company?> GetCompanyByIdAsync(int id)
        {
            var companies = await Set<Company>()
                .FromSqlRaw("EXEC GetCompanyById_SP {0}", id)
                .ToListAsync(); 

            return companies.SingleOrDefault();
        }

        public virtual async Task<int> InsertCompanyAsync(Company company)
        {
            return await Database.ExecuteSqlRawAsync("EXEC InsertCompany_SP {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}",
                company.Rnc, company.Name, company.CommercialName, company.Status, company.Category, company.Payment, company.Activity, company.Branch);
           
        }

        public virtual async Task<int> UpdateCompanyAsync(Company company)
        {
            return await Database.ExecuteSqlRawAsync("EXEC UpdateCompany_SP {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}",
                company.Id, company.Rnc, company.Name, company.CommercialName, company.Status, company.Category, company.Payment, company.Activity, company.Branch);
        }

    }
}
