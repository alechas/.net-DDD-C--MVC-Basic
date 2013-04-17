using System.Web;

namespace PHD.Session.SessionStorage
{
    public static class SessionStorageFactory
    {
        private static ISessionStorageContainer _nhSessionStorageContainer;
        public static ISessionStorageContainer GetStorageContainer()
        {
            if (_nhSessionStorageContainer == null)
            {
                if (HttpContext.Current != null)
                    _nhSessionStorageContainer = new HttpSessionContainer();
            }
            return _nhSessionStorageContainer;
        }
    }
}
