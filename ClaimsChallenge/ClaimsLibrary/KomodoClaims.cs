using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsLibrary
{
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }
    public class KomodoClaims
    {
        public KomodoClaims() {}

        public KomodoClaims(int claimID, ClaimType claimType, string description, decimal claimAmount, DateTime dateofIncident, DateTime dateofClaim)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateofIncident = dateofIncident;
            DateofClaim = dateofClaim;
        }

        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateofIncident { get; set; }
        public DateTime DateofClaim { get; set; }

        public bool IsValid 
        { 
            get
            {
                return DateofClaim <= DateofIncident.AddDays(30);
            }      
        }
        
        
    }
}