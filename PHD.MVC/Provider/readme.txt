//kode ditaro di dalem system.web

<roleManager defaultProvider="CustomRoleProvider"
      enabled="true"
      cacheRolesInCookie="true"
      cookieName=".ASPROLES"
      cookieTimeout="30"
      cookiePath="/"
      cookieRequireSSL="false"
      cookieSlidingExpiration="true"
      cookieProtection="All" >
      <providers>
        <clear />
        <add
          name="CustomRoleProvider"
          type="TRIMS.UI.MVC.Provider.HibernateRoleProvider"
          
          applicationName="/"
          writeExceptionsToEventLog="false" />
      </providers>
    </roleManager>

