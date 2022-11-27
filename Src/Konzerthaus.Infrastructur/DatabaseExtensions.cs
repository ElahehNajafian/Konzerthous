using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konzerthaus.Infrastructur;

namespace Konzerthaus.Infrastructur
{
    public static class DatabaseExtensions
    {
        public static void ConfigureSqLite(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<KonzerthausDbContext>(options =>
            {
                if (!options.IsConfigured)
                {
                    options.UseSqlite(connectionString);
                }
            });
        }
    }
}