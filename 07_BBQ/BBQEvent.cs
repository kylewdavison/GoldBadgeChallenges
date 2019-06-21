using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_BBQ
{
    public enum BurgerTicket
    {
        Hamburger = 1,
        Veggie,
        Hotdog,
        None
    }

    public enum TreatTicket
    {
        IceCream = 1,
        Popcorn,
        None
    }

    public class Booth
    {
        public decimal MiscCost { get; set; }
        public Booth() { }
        public Booth(decimal miscCost)
        {
            MiscCost = miscCost;
        }
    }

    public class Burger : Booth
    {
        public int VegCount { get; set; }
        public int HamCount { get; set; }
        public int HotdogCount { get; set; }
        public decimal VegCost { get; set; }
        public decimal HamCost { get; set; }
        public decimal HotdogCost { get; set; }
        public Burger(int vegCount, int hamCount, int hotdogCount, decimal miscCost, decimal vegCost, decimal hamCost, decimal hotdogCost)
            :base(miscCost)
        {
            VegCount = vegCount;
            HamCount = hamCount;
            HotdogCount = hotdogCount;
            VegCost = vegCost;
            HamCost = hamCost;
            HotdogCost = hotdogCost;
        }
    }
    public class Treat : Booth
    {
        public int IceCreamCount { get; set; }
        public int PopcornCount { get; set; }
        public decimal IceCreamCost { get; set; }
        public decimal PopcornCost { get; set; }
        public Treat(int iceCreamCount, int popcornCount, decimal iceCreamCost, decimal popcornCost, decimal miscCost)
            :base(miscCost)
        {
            IceCreamCount = iceCreamCount;
            PopcornCount = popcornCount;
            IceCreamCost = iceCreamCost;
            PopcornCost = popcornCost;
        }        
    }
}
