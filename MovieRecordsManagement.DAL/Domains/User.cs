using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieRecordsManagement.DAL.Domains
{
    public class User
    {
        [Key]
        public string UserName;
        public string Role;

        public static class ROLE_CONST
        {
            public const string MANAGER = "MANAGER";
            public const string TEAM_LEADER = "TEAM_LEADER";
            public const string FLOOR_STAFF = "FLOOR_STAFF";
        }

    }
}
