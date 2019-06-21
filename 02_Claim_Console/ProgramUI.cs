using _02_Claim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claim_Console
{
    class ProgramUI
    {
        private ClaimRepo _claimRepo = new ClaimRepo();
        public void Run()
        {
            RunMenu();
        }
        public void RunMenu()
        {
            bool continueToRunMenu = true;
            while (continueToRunMenu == true)
            {
                Console.Clear();
                Console.Write("Choose a menu item: " +
                    "\n1. See all claims" +
                    "\n2. Take care of next claim" +
                    "\n3. Enter a new claim" +
                    "\n4. Exit" +
                    "\nChoose an option: ");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ListAllClaims();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    case "4":
                        continueToRunMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option." +
                             "\n Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void ListAllClaims() 
        {
            Queue<Claim> listOfClaims = _claimRepo.GetClaims();
            Console.WriteLine("{0,-8} {1,-8} {2,-30} {3,-15} {4,-15} {5,-15} {6, -6}", "ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid");
            foreach (Claim claim in listOfClaims)
            {

                Console.WriteLine("{0,-8} {1,-8} {2,-30} {3,-15} {4,-15} {5,-15} {6, -6}", claim.ClaimID, claim.TypeOfClaim, claim.Desciption, $"${claim.Amount}", claim.DateOfAccident.ToString("MM/dd/yy"), claim.DateOfClaim.ToString("MM/dd/yy"), claim.IsValid);
            }
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        private void NextClaim()
        {
            Queue<Claim> listOfClaims = _claimRepo.GetClaims();
            foreach (Claim claim in listOfClaims.ToList())
            {
                Console.Write($"ClaimID: {claim.ClaimID}" +
                    $"\nType: {claim.TypeOfClaim}" +
                    $"\nDescription: {claim.Desciption}" +
                    $"\nDateOfAccident: {claim.DateOfAccident.ToString("MM/dd/yy")}" +
                    $"\nDateOfClaim: {claim.DateOfClaim.ToString("MM/dd/yy")}" +
                    $"\nIsValid: {claim.IsValid}" +
                    $"\n\nDo you want to deal with this claim now(y/n)?");
                var userInput = Console.ReadLine();
                if (userInput == "y")
                {
                    listOfClaims.Dequeue();
                }
                else break;
            }
        }
        private void AddNewClaim()
        {
            Claim claim = new Claim();
            Console.Write("ClaimID: ");
            claim.ClaimID = int.Parse(Console.ReadLine());

            Console.Write("1: Car" +
                "\n2: Home" +
                "\n3: Theft" +
                "\nType of Claim: ");
            int userChoice = int.Parse(Console.ReadLine());
            claim.TypeOfClaim = (ClaimType)userChoice;

            Console.Write("Claim Description: ");
            claim.Desciption = Console.ReadLine();

            Console.Write("Claim Amount: ");
            claim.Amount = decimal.Parse(Console.ReadLine());

            Console.Write("Date of Accident: ");
            DateTime dateOfAccident;
            DateTime.TryParse(Console.ReadLine(), out dateOfAccident);
            claim.DateOfAccident = dateOfAccident;

            Console.Write("Date of Claim: ");
            DateTime dateOfClaim;
            DateTime.TryParse(Console.ReadLine(), out dateOfClaim);
            claim.DateOfClaim = dateOfClaim;

            TimeSpan validClaim = dateOfClaim.Subtract(dateOfAccident);

            if (validClaim.TotalDays < 30)
            {
                claim.IsValid = true;
            }
            else claim.IsValid = false;
            _claimRepo.AddNewClaim(claim);
        }
    }
}
