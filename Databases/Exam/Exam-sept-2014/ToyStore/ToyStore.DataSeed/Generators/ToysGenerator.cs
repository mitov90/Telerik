namespace ToyStore.DataSeed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ToyStore.Data;
    using ToyStore.DataSeed.Abstract;
    using ToyStore.DataSeed.Contracts;

    public class ToysGenerator : Generator
    {
        public ToysGenerator(ToysStoreEntities db, ILogger logger, int seedCount)
            : base(db, logger, seedCount)
        {
        }

        public override void Generate()
        {
            List<int> manufacturerIds = this.db.Manufacturers.Select(m => m.id).ToList();
            List<int> categoryIds = this.db.Categories.Select(c => c.id).ToList();
            List<int> ageRangeIds = this.db.AgeRanges.Select(r => r.id).ToList();
            this.logger.Log("Adding toys\n");
            for (int i = 0; i < this.count; i++)
            {
                Toy newToy = new Toy
                                 {
                                     ageRangeId = ageRangeIds[this.random.GetRandomNumber(0, ageRangeIds.Count - 1)], 
                                     manufacturerId =
                                         manufacturerIds[this.random.GetRandomNumber(0, manufacturerIds.Count - 1)], 
                                     color =
                                         this.random.GetChance(50) ? this.random.GetRandomLengthString(2, 10) : null, 
                                     type =
                                         this.random.GetChance(60) ? this.random.GetRandomLengthString(3, 20) : null, 
                                     name = this.random.GetRandomLengthString(4, 40), 
                                     price = this.random.GetRandomNumber(1, 400)
                                 };

                if (this.db.Categories.Any())
                {
                    int numberCategories = this.random.GetRandomNumber(1, Math.Min(this.db.Categories.Count(), 8));
                    HashSet<int> categoriesSet = new HashSet<int>();
                    while (categoriesSet.Count != numberCategories)
                    {
                        categoriesSet.Add(categoryIds[this.random.GetRandomNumber(0, categoryIds.Count - 1)]);
                    }

                    foreach (int categoryId in categoriesSet)
                    {
                        newToy.Categories.Add(this.db.Categories.Find(categoryId));
                    }
                }

                this.db.Toys.Add(newToy);
                if (i % 100 == 0)
                {
                    this.logger.Log(".");
                    this.db.SaveChanges();
                }
            }

            this.logger.Log("\nToys added");
        }
    }
}