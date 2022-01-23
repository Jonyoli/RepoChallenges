using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClaimsLibrary;


namespace ClaimsUI
{
    public class UserInterface
    {
        private readonly KomodoClaimsRepo claims = new KomodoClaimsRepo();

        public void Display()
        {
            ClaimsContent();
            DisplayMenu();
        }

        public void ClaimsContent()
        {
            KomodoClaims damagedCar = new KomodoClaims(1, ClaimType.Car, "Damaged fender", 150.00m, new DateTime(2022, 01, 01), new DateTime(2022, 01, 21));
            KomodoClaims damagedHome = new KomodoClaims(2, ClaimType.Home, "Home flooded", 5000.00m, new DateTime(2022, 01, 01), new DateTime(2022, 02, 03));
            KomodoClaims stolenCar = new KomodoClaims(3, ClaimType.Theft, "Stolen Car", 22000.00m, new DateTime(2022, 01, 20), new DateTime(2022, 01, 21));

            claims.EnterNewClaim(damagedCar);
            claims.EnterNewClaim(damagedHome);
            claims.EnterNewClaim(stolenCar);
        }

        private void DisplayMenu()
        {
            bool isDisplaying = true;
            while (isDisplaying)
            {
                Console.Clear();
                Console.WriteLine(
                    "Welcome to Komodo Claims. Please select an option below:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n"
                );

                string userSelection = Console.ReadLine();

                switch (userSelection.ToLower())
                {
                    case "1":
                    case "see all claims":
                        Console.Clear();
                        ViewClaims();
                        break;
                    case "2":
                    case "take care of next claim":
                        Console.Clear();
                        TakeCareofClaim();
                        break;
                    case "3":
                    case "enter a new claim":
                        Console.Clear();
                        break;
                }
            }
        }
        //End of Menu Creation

        private void ViewClaims()
        {
            Console.Clear();

            List<KomodoClaims> listofClaims = claims.ViewClaims();

            foreach (KomodoClaims claims in listofClaims)
            {
                Console.Write(
                    $"ClaimID: {claims.ClaimID}\n" +
                    $"Type: {claims.ClaimType}\n" +
                    $"Description: {claims.Description}\n" +
                    $"Amount: ${claims.ClaimAmount}\n" +
                    $"DateOfAccident: {claims.DateofIncident}\n" +
                    $"DateofClaim: {claims.DateofClaim}\n" +
                    $"IsValid: {claims.IsValid}\n\n"
                );
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();


        }

        private void TakeCareofClaim()
        {
            Console.Clear();
            KomodoClaims nextClaim = claims.ViewNextClaim();
            Console.WriteLine(
                   $"ClaimID {nextClaim.ClaimID}\n" +
                   $"Type {nextClaim.ClaimType}\n" +
                   $"Description {nextClaim.Description}\n" +
                   $"Amount  ${nextClaim.ClaimAmount}\n" +
                   $"DateOfAccident {nextClaim.DateofIncident}\n" +
                   $"DateofClaim {nextClaim.DateofClaim}\n" +
                   $"IsValid {nextClaim.IsValid}"
               );

            string userSelection2 = "";
            Console.WriteLine("Do you want to do deal with this claim?  Yes or No");
            userSelection2 = Console.ReadLine();
            switch (userSelection2.ToLower())
            {
                case "yes":
                    Console.Clear();
                    Console.WriteLine($"{nextClaim.ClaimID} was taken care of. Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "no":
                    Console.Clear();
                    Console.WriteLine("Maybe another time. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }


        // Able to grab one list and then display it and remove it if necessary


        //    int counter = 1;
        //     foreach (KomodoClaims currentClaim in claimList)
        //     {
        //         Console.WriteLine(counter + ". " + currentClaim.ClaimID);
        //         counter++;
        //     }


        // List<KomodoClaims> claimList = claims.ViewClaims();
        // Console.WriteLine("Do you want to do deal with this claim? yes or no?");

        // int claimSelection = int.Parse(Console.ReadLine());
        // int targetIndex = claimSelection - 1;
        // Console.ReadLine();
        // Console.Clear();

        // if(targetIndex >= 0 && targetIndex < claimList.Count)  //(claimList.Equals())
        // {
        //     KomodoClaims targetClaims = claimList[targetIndex];

        //     if(claims.TakeCareofClaim(targetClaims))
        //     {
        //         Console.WriteLine($"{targetClaims.ClaimID} was taken care of");
        //     }
        //     else
        //     {
        //         Console.WriteLine("Maybe another time");
        //     }
        // }
        // Console.WriteLine("Press any key to continue...");
        // Console.ReadKey();

        private void EnterNewClaim()
        {
            Console.Clear();

            KomodoClaims newclaim = new KomodoClaims();

            Console.WriteLine("Enter a claim ID:");
            newclaim.ClaimID = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine(
                "Select claim type\n" +
                "1: Car\n" +
                "2: Home\n" +
                "3: Theft"
            );
            string userSelection3 = Console.ReadLine();
            switch (userSelection3.ToLower())
            {
                case "1":
                case "car":
                    newclaim.ClaimType = ClaimType.Car;
                    break;

                case "2":
                case "home":
                    newclaim.ClaimType = ClaimType.Home;
                    break;

                case "3":
                case "theft":
                    newclaim.ClaimType = ClaimType.Theft;
                    break;
            }

            Console.Clear();
            Console.WriteLine("Enter a description");
            newclaim.Description = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Enter the amount");
            Console.Write("$");
            newclaim.ClaimAmount = decimal.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Enter Date of Incident");
            newclaim.DateofIncident = DateTime.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Enter Date of Claim");
            newclaim.DateofClaim = DateTime.Parse(Console.ReadLine());

            claims.EnterNewClaim(newclaim);
        }
    }
}
