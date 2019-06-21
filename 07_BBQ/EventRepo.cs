using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_BBQ
{
    public class EventRepo
    {
        private Burger _burgerBooth = new Burger(0, 0, 0, 0m, 2m, 1.5m, 1m);
        private Treat _treatBooth = new Treat(0, 0, 1m, 0.5m, 0m);
        public Burger GetBurgerBooth()
        {
            return _burgerBooth;
        }

        public Treat GetTreatBooth()
        {
            return _treatBooth;
        }

        public void RedeemTicket(BurgerTicket burgerTicket, TreatTicket treatTicket, decimal burgerMisc, decimal treatMisc)
        {
            switch (burgerTicket)
            {
                case BurgerTicket.Hotdog:
                    _burgerBooth.HotdogCount++;
                    break;
                case BurgerTicket.Hamburger:
                    _burgerBooth.HamCount++;
                    break;
                case BurgerTicket.Veggie:
                    _burgerBooth.VegCount++;
                    break;
                case BurgerTicket.None:
                    break;
                default:
                    break;
            }
            switch (treatTicket)
            {
                case TreatTicket.IceCream:
                    _treatBooth.IceCreamCount++;
                    break;
                case TreatTicket.Popcorn:
                    _treatBooth.PopcornCount++;
                    break;
                default:
                    break;
            }
            _burgerBooth.MiscCost =+ burgerMisc;
            _treatBooth.MiscCost =+ treatMisc;
        }
    }
}
