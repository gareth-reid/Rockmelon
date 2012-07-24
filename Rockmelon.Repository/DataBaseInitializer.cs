using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rockmelon.Repository
{
    public class DataBaseInitializer : IDatabaseInitializer<ApplicationContext>
    {
        public void InitializeDatabase(ApplicationContext context)
        {
            //context.Database.Delete();
            //context.Database.Create();
        }
    } 
}
