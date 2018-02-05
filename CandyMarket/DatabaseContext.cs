using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyMarket
{
    internal class DatabaseContext
    {
        private int _countOfTaffy;
        private int _countOfCandyCoated;
        private int _countOfChocolateBar;
        private int _countOfZagnut;

        private int _taffySavedToTable;
        private int _candyCoatedSavedToTable;
        private int _chocolateBarSavedToTable;
        private int _zagnutSavedToTable;
        /**
		 * this is just an example.
		 * feel free to modify the definition of this collection "BagOfCandy" if you choose to implement the more difficult data model.
		 * Dictionary<CandyType, List<Candy>> BagOfCandy { get; set; }
		 */

        public DatabaseContext(int tone) => Console.Beep(tone, 2500);

        internal List<string> GetCandyTypes()
        {
            return Enum
                .GetNames(typeof(CandyType))
                .Select(candyType =>
                    candyType.Humanize(LetterCasing.Title))
                .ToList();
        }

        internal List<string> GetUsers()
        {
            return Enum
                .GetNames(typeof(Users))
                .Select(Users =>
                    Users.Humanize(LetterCasing.Title))
                .ToList();
        }

        internal Dictionary<string, int> GetUserCandy()
        {
            var contents = new Dictionary<string, int>();
            contents.Add("Taffy", _countOfTaffy);
            contents.Add("CandyCoated", _countOfCandyCoated);
            contents.Add("Chocolate Bar", _countOfChocolateBar);
            contents.Add("Zaganut", _countOfZagnut);

            return contents;
        }

        //internal Dictionary<Users, > 
        //  {
        //}

        internal void SaveNewCandy(char selectedCandyMenuOption)
        {
            var candyOption = int.Parse(selectedCandyMenuOption.ToString());

            var maybeCandyMaybeNot = (CandyType)selectedCandyMenuOption;
            var forRealTheCandyThisTime = (CandyType)candyOption;

            switch (forRealTheCandyThisTime)
            {
                case CandyType.TaffyNotLaffy:
                    ++_countOfTaffy;
                    break;
                case CandyType.CandyCoated:
                    ++_countOfCandyCoated;
                    break;
                case CandyType.CompressedSugar:
                    ++_countOfChocolateBar;
                    break;
                case CandyType.ZagnutStyle:
                    ++_countOfZagnut;
                    break;
                default:
                    break;
            }


        }

        internal void RemoveCandy(char selectedCandyMenuOption)
        {
            var candyOption = int.Parse(selectedCandyMenuOption.ToString());

            var maybeCandyMaybeNot = (CandyType)selectedCandyMenuOption;
            var forRealTheCandyThisTime = (CandyType)candyOption;

            switch (forRealTheCandyThisTime)
            {
                case CandyType.TaffyNotLaffy:
                    --_countOfTaffy;
                    break;
                case CandyType.CandyCoated:
                    --_countOfCandyCoated;
                    break;
                case CandyType.CompressedSugar:
                    --_countOfChocolateBar;
                    break;
                case CandyType.ZagnutStyle:
                    --_countOfZagnut;
                    break;
                default:
                    break;
            }

        }

        internal void CandyToTable(char selectedCandyMenuOption)
        {
            var candyOption = int.Parse(selectedCandyMenuOption.ToString());

            var maybeCandyMaybeNot = (CandyType)selectedCandyMenuOption;
            var forRealTheCandyThisTime = (CandyType)candyOption;

            switch (forRealTheCandyThisTime)
            {
                case CandyType.TaffyNotLaffy:
                    --_countOfTaffy;
                    ++_taffySavedToTable;

                    break;
                case CandyType.CandyCoated:
                    --_countOfCandyCoated;
                    ++_candyCoatedSavedToTable;
                    break;
                case CandyType.CompressedSugar:
                    --_countOfChocolateBar;
                    ++_chocolateBarSavedToTable;
                    break;
                case CandyType.ZagnutStyle:
                    --_countOfZagnut;
                    ++_zagnutSavedToTable;
                    break;
                default:
                    break;
            }

        }

        internal void SelectUser(char selectedUserMenuOption)
        {
            var userOption = int.Parse(selectedUserMenuOption.ToString());

            var maybeUserMaybeNot = (Users)selectedUserMenuOption;
            var forRealTheUserThisTime = (Users)userOption;

            switch (forRealTheUserThisTime)
            {
                case CandyMarket.Users.Jason:
                    ++ _taffySavedToTable;
                    ++ _candyCoatedSavedToTable;
                    ++ _chocolateBarSavedToTable;
                    ++ _zagnutSavedToTable;
                    break;
                case CandyMarket.Users.Patrick:
                    --_countOfCandyCoated;
                    break;
                case CandyMarket.Users.Joe:
                    --_countOfChocolateBar;
                    break;
                case CandyMarket.Users.James:
                    --_countOfZagnut;
                    break;
                default:
                    break;
            }

        //    internal List<string> Users()
        //{
        //    var contents = new List<string>();
        //    contents.Add("Jason");
        //    contents.Add("Kelly");
        //    contents.Add("Adam");
        //    contents.Add("Patrick");

        //    return contents;
        }

        //    internal Dictionary<list<users>, int> SharedCandy()
        //    {

        //    }
    }
}