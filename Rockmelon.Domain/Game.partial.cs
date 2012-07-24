using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rockmelon.Domain
{
    public partial class Game
    {
        public int RatingValue { get; set; }
        public int TotalRating()
        {
            if (Ratings == null || !Ratings.Any())
            {
                return 0;
            }
            var total = Ratings.Sum(r => r.RatingValue ?? 1);
            if (total < 1 || Ratings.Count < 1)
            {
                return 0;
            }            
            return total / Ratings.Count;
        }
    }
}
