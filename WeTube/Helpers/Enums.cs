using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeTube.Helpers
{
    public class Enums
    {
        public enum Visibility
        {
            Invisible = 0,
            Visible = 1
        }

        public enum Role
        {
            Admin = 0,
            User = 1,
            Guest = 2
        }
    }
}