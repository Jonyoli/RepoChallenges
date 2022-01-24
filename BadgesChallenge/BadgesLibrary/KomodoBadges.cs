using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadgesLibrary
{
    public class KomodoBadges
    {
        public KomodoBadges(int badgeID, Dictionary<int, string> doorNames, string badgeName)
        {
            BadgeID = badgeID;
            DoorNames = doorNames;
            BadgeName = badgeName;
        }

        public int BadgeID { get; set; }
        public Dictionary<int, string> DoorNames { get; set; } = new Dictionary<int, string>();
        public string BadgeName { get; set; }
    }
}