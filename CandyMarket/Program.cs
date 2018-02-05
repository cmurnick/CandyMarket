using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            // wanna be a l33t h@x0r? skip all this console menu nonsense and go with straight command line arguments. something like `candy-market add taffy "blueberry cheesecake" yesterday`
            var db = SetupNewApp();

            var run = true;
            while (run)
            {
                ConsoleKeyInfo userInput = MainMenu();

                switch (userInput.KeyChar)
                {
                    case '0':
                        run = false;
                        break;
                    case '1': // add candy to your bag

                        // select a candy type
                        var selectedCandyType = AddNewCandyType(db);

                      
                        db.SaveNewCandy(selectedCandyType.KeyChar);
                        break;
                    case '2':// eat candy
                        EatCandy(db);
                        Console.ReadKey();
                        db.RemoveCandy(selectedCandyType.KeyChar);
                       
                        break;
                    case '3': //Show candy
                        ShowCandy(db);
                        Console.ReadKey();
                        break;
                    case '4':
                        ShareCandy(db);
                        db.CandyToTable(selectedCandyType.KeyChar);
                        AssignCandy(db);

                        /** give candy
						 * feel free to hardcode your users. no need to create a whole UI to register users.
						 * no one is impressed by user registration unless it's just amazingly fast & simple
						 * 
						 * select candy in any manner you prefer.
						 * it may be easiest to reuse some code for throwing away candy since that's basically what you're doing. except instead of throwing it away, you're giving it away to another user.
						 * you'll need a way to select what user you're giving candy to.
						 * one design suggestion would be to put candy "on the table" and then "give the candy on the table" to another user once you've selected all the candy to give away
						 */
                      
                        break;
                    case '5':
                        /** trade candy
						 * this is the next logical step. who wants to just give away candy forever?
						 */
                        break;
                    default: // what about requesting candy? like a wishlist. that would be cool.
                        break;
                }
            }
        }

        static DatabaseContext SetupNewApp()
        {
            Console.Title = "Cross Confectioneries Incorporated";

            var cSharp = 554;
            var db = new DatabaseContext(tone: cSharp);

            Console.SetWindowSize(60, 30);
            Console.SetBufferSize(60, 30);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            return db;
        }

        static ConsoleKeyInfo MainMenu()
        {
            View mainMenu = new View()
                    .AddMenuOption("Did you just get some new candy? Add it here.")
                    .AddMenuOption("Do you want to eat some candy? Take it here.")
                    .AddMenuOption("Show me the candy options I have.")
                    .AddMenuOption("Who do you want to share your candy with?")
                    .AddMenuText("Press 0 to exit.");

            Console.Write(mainMenu.GetFullMenu());
            ConsoleKeyInfo userOption = Console.ReadKey();
            return userOption;
        }

        static ConsoleKeyInfo AddNewCandyType(DatabaseContext db)
        {
            var candyTypes = db.GetCandyTypes();

            var newCandyMenu = new View()
                    .AddMenuText("What type of candy did you get?")
                    .AddMenuOptions(candyTypes);

            Console.Write(newCandyMenu.GetFullMenu());

            ConsoleKeyInfo selectedCandyType = Console.ReadKey();
            return selectedCandyType;
        }

        static void ShowCandy(DatabaseContext db)
        {
            var FinalContents = db.GetUserCandy();
            var haveCandyMenu = new View();
            foreach (var keyValuPair in FinalContents)
            {
                if (keyValuPair.Value >= 1)
                {
                    haveCandyMenu.AddMenuText($"{keyValuPair.Key} has {keyValuPair.Value} pieces of candy");
                }
            }
            Console.Write(haveCandyMenu.GetFullMenu());
           
        }

        static ConsoleKeyInfo EatCandy(DatabaseContext db)
        {
            ShowCandy(db);
            Console.ReadKey();
            var candyTypes = db.GetCandyTypes();

            var newCandyMenu = new View()
                    .AddMenuText("What type of candy do you want to eat?")

                    .AddMenuOptions(candyTypes);

            Console.Write(newCandyMenu.GetFullMenu());

            ConsoleKeyInfo selectedCandyType = Console.ReadKey();
            return selectedCandyType;
        }

        static ConsoleKeyInfo ShareCandy(DatabaseContext db)
        {
            ShowCandy(db);
            Console.ReadKey();
            var candyTypes = db.GetCandyTypes();

            var newCandyMenu = new View()
                    .AddMenuText("What type of candy do you want to share?")

                    .AddMenuOptions(candyTypes);

            Console.Write(newCandyMenu.GetFullMenu());
            
            ConsoleKeyInfo selectedCandyType = Console.ReadKey();
            return selectedCandyType;
        }

        static ConsoleKeyInfo AssignCandy(DatabaseContext db)
        {
            var whichUser = db.GetUsers();
            var newUser = new View()
               .AddMenuText("Who do you want to share with?")

               .AddMenuOptions(whichUser);

            Console.Write(newUser.GetFullMenu());
            ConsoleKeyInfo selectedUser = Console.ReadKey();
            return selectedUser;
        }
    }
}
