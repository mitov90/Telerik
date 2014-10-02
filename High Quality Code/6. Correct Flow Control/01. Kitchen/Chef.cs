// ********************************
// <copyright file="Chef.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************

namespace Kitchen
{
    /// <summary>
    ///     Represents a chef.
    /// </summary>
    public class Chef
    {
        #region Private Fields

        /// <summary>
        ///     Keeps the actions that are performed while cooking.
        /// </summary>
        private readonly CookingLog _cookingLog = new CookingLog();

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the contents of the cooking log.
        /// </summary>
        public string Log
        {
            get { return _cookingLog.ToString(); }
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Describes the sequence of steps necessary to complete
        ///     the soup-making process.
        /// </summary>
        public void MakeSoup()
        {
            var pot = GetPot();

            FillWithWater(pot);

            var potato = GetPotato();

            if (!potato.IsRotten)
            {
                if (!potato.IsPeeled)
                {
                    Peel(potato);
                }

                Wash(potato);
                Cut(potato);
            }
            else
            {
                MaybeNextTime(potato);
                return;
            }

            var carrot = GetCarrot();

            if (!carrot.IsRotten)
            {
                if (!carrot.IsPeeled)
                {
                    Peel(carrot);
                }

                Wash(carrot);
                Cut(carrot);
            }
            else
            {
                MaybeNextTime(carrot);
                return;
            }

            PutIn(pot, potato);
            PutIn(pot, carrot);

            Boil(30);

            Success();
        }

        #endregion

        #region Private Methods

        private Pot GetPot()
        {
            var pot = new Pot();
            _cookingLog.Add("A developer makes soup (Episode I - Invisible Threat)");
            _cookingLog.Add(string.Format("Took a clean {0}. (What do they mean by 'clean'?)", pot));

            return pot;
        }

        private void FillWithWater(Utensil utensil)
        {
            var result = utensil.FillWithWater();
            _cookingLog.Add(result);
        }

        private Carrot GetCarrot()
        {
            var carrot = new Carrot();
            _cookingLog.Add(string.Format("Found a {0}. (Thank you, hamster.)", carrot));

            return carrot;
        }

        private Potato GetPotato()
        {
            var potato = new Potato();
            _cookingLog.Add(string.Format("Found a {0}. (The last one, the day is ours.)", potato));

            return potato;
        }

        private void MaybeNextTime(Vegetable vegetable)
        {
            _cookingLog.Add(
                string.Format(
                    "The {0} is rotten.\r\n" +
                    "(They betrayed meeee! Wish I knew who bought this.)",
                    vegetable));
        }

        private void Peel(Vegetable vegetable)
        {
            vegetable.IsPeeled = true;
            _cookingLog.Add(
                string.Format(
                    "Peeled the {0}.\r\n" +
                    "(What a useless operation. This is outrageous!)",
                    vegetable));
        }

        private void Wash(Vegetable vegetable)
        {
            _cookingLog.Add(
                string.Format(
                    "Washed the {0}.\r\n" +
                    "(I think the aquarium should be in the kitchen.)",
                    vegetable));
        }

        private void Cut(Vegetable vegetable)
        {
            _cookingLog.Add(
                string.Format(
                    "Cut the {0}. (Not a single drop of blood.\r\n" +
                    "I was blind but now I see I was born to be a chef.)",
                    vegetable));
        }

        private void PutIn(Utensil utensil, Vegetable vegetable)
        {
            var result = utensil.Add(vegetable);
            _cookingLog.Add(result);
        }

        private void Boil(int minutes)
        {
            _cookingLog.Add(
                string.Format(
                    "Wait for {0} minutes and then...\r\n" +
                    "What would my wife do without me?",
                    minutes));
        }

        private void Success()
        {
            _cookingLog.Add("Bon appetit, mon ami!");
        }

        #endregion
    }
}
