using System.Web;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Runtime.Remoting.Messaging;
using NHibernate.Cache;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using System.Reflection;
using System.Configuration;
using Session.Domain;
using FluentNHibernate.Automapping;
using Session.Mappings;



namespace Session.SessionStorage
{
    public sealed class SessionFactory
    {

        private ISessionFactory _sessionFactory;

        private SessionFactory()
        {
            Init();
        }

        public static SessionFactory Instance
        {
            get { return SessionFactoryCreator.uniqueInstance; }
        }

        private class SessionFactoryCreator
        {
            static SessionFactoryCreator() { }
            internal static readonly SessionFactory uniqueInstance = new SessionFactory();
        }

        private void Init()
        {
            /*Configuration config = new Configuration();
            config.AddAssembly("ContactManager.Repository");
            //log4net.Config.XmlConfigurator.Configure();
            config.Configure();
            _sessionFactory = config.BuildSessionFactory();
             * */
            NHibernate.Cfg.Configuration config = new NHibernate.Cfg.Configuration();
            config.Configure();
            //string mappingAssembly = ConfigurationManager.AppSettings["NHibernate.Mapping.Assembly"];
            _sessionFactory = Fluently.Configure(config).Mappings(m => m.FluentMappings
                   .AddFromAssemblyOf<UserMap>()
                   )
               .BuildSessionFactory();

           

            
            
        }
        public void OpenSession()
        {
            ISession session = GetNewSession();
            ISessionStorageContainer sessionStorageContainer = SessionStorageFactory.GetStorageContainer();
            sessionStorageContainer.Store(session);
        }

        private ISession GetNewSession()
        {
            return _sessionFactory.OpenSession();
        }

        public ISession GetCurrentSession()
        {
            ISessionStorageContainer sessionStorageContainer = SessionStorageFactory.GetStorageContainer();
            ISession currentSession = sessionStorageContainer.GetCurrentSession();

            if (currentSession == null)
            {
                currentSession = GetNewSession();
                sessionStorageContainer.Store(currentSession);
            }
            return currentSession;
        }

        public void BeginTransaction()
        {
            // ISession session = GetCurrentSession();
            // masih bingung di bagian sini untuk yang ideal seperti apa
            ITransaction transaction = GetCurrentSession().BeginTransaction();
        }

        public void CloseSession()
        {
            ISession session = GetCurrentSession();
            if (session != null && session.IsOpen)
            {
                //session.Flush();
                session.Close();
            }
            ISessionStorageContainer sessionStorageContainer = SessionStorageFactory.GetStorageContainer();
            sessionStorageContainer.Store(null);
        }

        //public void Dispose() {
        //    Dispose(true);
        //}

        //public void Dispose(bool isDispose){
        //    if(isDispose)
        //        GC.SuppressFinalize(this);
        //    GetCurrentSession().Dispose();

        //}

        //~SessionFactory() {
        //    Dispose(false);
        //}

    }
   
}
