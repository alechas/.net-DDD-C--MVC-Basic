using System.Web;
namespace Infrastructure.Utils
{
    public class SessionStorageFactory <IT>
    {
        private static string _sessionKey;
        public SessionStorageFactory(string sessionKey)
        {
            _sessionKey = sessionKey;
        }
        private static ISessionStorageContainer<IT> _nhSessionStorageContainer;
        public static ISessionStorageContainer<IT> GetStorageContainer()
        {
            if (_nhSessionStorageContainer == null)
            {
                if (HttpContext.Current != null)
                    _nhSessionStorageContainer = new HttpSessionContainer<IT>(_sessionKey);
            }
            return _nhSessionStorageContainer;
        }
    }
}
