using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackList
{
    public class UserLightWeight
    {
        public string userName { get; set; }
        public int UserID { get; set; }
    }

    public class ConnectedUser
    {
        public string UserName { get; set; }
        public List<UserLightWeight> Friends { get; set; }
        

    }
}