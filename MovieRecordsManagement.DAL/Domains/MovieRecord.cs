using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecordsManagement.DAL.Domains
{
    public class MovieRecord
    {
        public Guid Id { get; set; }
        public string MovieTitle { get; set; }
        public int YearReleased { get; set; }
        public string Rating { get; set; }

        public static class RATING_CONST
        {
            public const string G = "G";
            public const string PG = "PG";
            public const string M = "M";
            public const string MA = "MA";
            public const string R = "R";
        }

        public MovieRecord()
        {
            this.Id = new Guid();
        }
    }
}
