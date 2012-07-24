using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Rockmelon;
using Rockmelon.Repository;
using Rockmelon.Domain;


namespace Rockmelon.Business
{
    public class BaseUnitTest
    {       
        public void Init()
        {
            Ioc.Container = new Factory();            
        }
    }
}
