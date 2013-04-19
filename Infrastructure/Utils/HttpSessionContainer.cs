using System.Web;

namespace Infrastructure.Utils
{
    public class HttpSessionContainer<IT> : ISessionStorageContainer<IT>
    {
        private static string _sessionKey;
        private static IT _session;

        public HttpSessionContainer(string sessionKey)
        {
            _sessionKey = sessionKey;
        }

        public IT GetCurrentSession()
        {

            if (HttpContext.Current.Items.Contains(_sessionKey))
            {
                _session = (IT)HttpContext.Current.Items[_sessionKey];
                return _session;
            }
            return default(IT);
        }

        public void Store(IT session)
        {
            if (HttpContext.Current.Items.Contains(_sessionKey))
                HttpContext.Current.Items[_sessionKey] = session;
            else
                HttpContext.Current.Items.Add(_sessionKey, session);
        }
    }
}
