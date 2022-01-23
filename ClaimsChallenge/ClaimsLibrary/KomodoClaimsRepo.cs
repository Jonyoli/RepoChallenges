using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsLibrary
{
    public class KomodoClaimsRepo
    {
        private readonly List<KomodoClaims> claims = new List<KomodoClaims>();

        // See all Claims
        public List<KomodoClaims> ViewClaims()
        {
            return claims;
        }

        //Display next claim in list
        public KomodoClaims ViewNextClaim()
        {
            return claims[0];
        }
        //Take Care of next claim
        public bool TakeCareofClaim(KomodoClaims nextClaim)
        {
            return claims.Remove(nextClaim);
        }

        //Enter a new claim
        public bool EnterNewClaim(KomodoClaims newClaim)
        {
            int startingCount = claims.Count;
            claims.Add(newClaim);

            return claims.Count > startingCount;
        }
    }
}

