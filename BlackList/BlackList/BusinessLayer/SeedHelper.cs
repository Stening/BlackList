using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackList.BusinessLayer
{
    public class SeedHelper
    {
        private Random rand = new Random();

        public DateTime Randomday()
        {
            DateTime start = new DateTime(2016, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(rand.Next(range));
        }
    }
}