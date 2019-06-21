using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claim
{
    public class ClaimRepo
    {
        private Queue<Claim> _claimQueue = new Queue<Claim>();

        public void AddNewClaim(Claim claim)
        {
            _claimQueue.Enqueue(claim);
        }

        public Queue<Claim> GetClaims()
        {
            return _claimQueue;
        }

        public Claim GetNextClaim()
        {
            return _claimQueue.Peek();
        }
    }
}
