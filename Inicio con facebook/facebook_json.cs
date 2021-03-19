using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inicio_con_facebook
{
    public class facebook_json
    {
        public class tok
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public int expires_in { get; set; }
        }

        public class usuario
        {
            public string id { get; set; }
            public string name { get; set; }
        }
    }
}