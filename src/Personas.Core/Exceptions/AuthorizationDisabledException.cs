using System;

namespace Personas.Core
{
    public class AuthorizationDisabledException : Exception
    {
        public AuthorizationDisabledException() : 
            base("Authorization must be enabled. To enable authorization, Add a json file in the root path named 'appsettingssecret.json'. " +
                "This file must include the following: '{ \"ApiKey\": \"Your secret Production Api key\",}' Do not track this file in the source control")
        {
        }
    }
}
