using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuestbookLibrary.Models;
//Capture information about each guest.  Assume at least one guest.
//Info to capture, first name, last name, message to host.
//Once done, loop through each and print their info.
namespace BetterGuestbook
{
    class Program
    {
       private static List<GuestModel> guests = new List<GuestModel>();
    
        static void Main(string[] args)
        {
            GetGuestInfo();

            PrintCompleteGuestInfo();

            Console.ReadLine();

        }

        private static void GetGuestInfo()
        {
            string moreGuestsComing = "";
            do
            {

                GuestModel guest = new GuestModel();

                guest.FirstName = GetInfoFromUser("What is your first name?");
               
                guest.LastName = GetInfoFromUser("What is your last name?");
            
                guest.MessageToHost = GetInfoFromUser("What is your message to the host?");

                moreGuestsComing = GetInfoFromUser("Are more guests coming? yes/no");

                Console.Clear();


            } while (moreGuestsComing.ToLower() == "yes");


        }

        private static void PrintCompleteGuestInfo()
        {
            foreach (var guest in guests)
            {
                Console.WriteLine(guest.CompleteGuestInfo);
            }
        }

        private static string GetInfoFromUser(string message)
        {
            Console.WriteLine(message);
            string output = Console.ReadLine();
            return output;
        }
    }
}
