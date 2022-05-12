using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.context
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<Context >
    {
        public Context CreateDbContext(string[] args)
        {
            AppConfiguration appConfiguration = new AppConfiguration();

            var opsBuilder = new DbContextOptionsBuilder<Context>();

            opsBuilder.UseSqlServer(appConfiguration.SqlConnectionString);

            return new Context(opsBuilder.Options);

        }
    }
}
