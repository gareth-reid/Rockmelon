using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rockmelon.Repository
{
    public interface IDatabaseInitializer<in TContext> where TContext :
                    IDbContext
    {
        // Summary:
        //   Executes the strategy to initialize
        //   the database for the given context.
        // Parameters:
        //   context: The context.
        void InitializeDatabase(TContext context);
    } 
}
