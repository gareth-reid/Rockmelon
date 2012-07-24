namespace Rockmelon.Repository
{
    public class BaseUnitTest
    {       
        public void Init()
        {
            Ioc.Container = new Factory();
        }
    }
}
