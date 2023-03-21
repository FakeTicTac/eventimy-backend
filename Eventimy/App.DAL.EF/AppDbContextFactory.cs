using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace App.DAL.EF;


/// <summary>
/// Factory For Creation Derived AppDbContext Instances. 
/// </summary>
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    /// <summary>
    /// Factory For Creation Derived AppDbContext Instances.
    /// </summary>
    /// <param name="args">Run Parameters.</param>
    /// <returns>New Instance of AppDbContext.</returns>
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
        const string connectionString = "Host=d118370.mysql.zonevs.eu;Username=d118370_romake;Password=ROR14121998ror;database=d118370_eventimy";
        
        optionBuilder.UseMySQL(connectionString);
        
        return new AppDbContext(optionBuilder.Options);
    }
}