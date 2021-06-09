using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCounter.Blazor.Pages
{
    public partial class Counter
    {
        public int currentCount = 0;

        public void Increase()
        {
            currentCount++;
        }

        public void Decrease()
        {
            currentCount--;
        }
    }
}
