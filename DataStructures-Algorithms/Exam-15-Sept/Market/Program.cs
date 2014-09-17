namespace Market
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Wintellect.PowerCollections;

    internal class Program
    {
        private static readonly OrderedBag<Item> ItemsByPrice = new OrderedBag<Item>();

        private static readonly HashSet<string> ItemsByName = new HashSet<string>();

        private static readonly OrderedBag<Item> ItemsByType =
            new OrderedBag<Item>((i, y) => string.CompareOrdinal(i.Type, y.Type));

        private static readonly StringBuilder ResultBuilder = new StringBuilder();

        private static void Main()
        {
            // if (Environment.CurrentDirectory
            // .ToLower()
            // .EndsWith(@"bin\debug"))
            // {
            // Console.SetIn(new StreamReader("test.txt"));
            // }
            while (true)
            {
                string[] command = Console.ReadLine()
                                          .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "add":
                        {
                            AddItem(command);
                            break;
                        }

                    case "filter":
                        {
                            if (command[2] == "type")
                            {
                                FilterByType(command);
                            }
                            else
                            {
                                FilterByPrice(command);
                            }

                            break;
                        }

                    case "end":
                        {
                            Console.Write(ResultBuilder.ToString());
                            return;
                        }
                }
            }
        }

        private static void AddItem(IList<string> command)
        {
            if (ItemsByName.Contains(command[1]))
            {
                ResultBuilder.AppendLine(string.Format("Error: Product {0} already exists", command[1]));
            }
            else
            {
                string type = string.Empty;
                if (command.Count > 3)
                {
                    type = command[3];
                }

                Item newItem = new Item
                                   {
                                       Name = command[1], 
                                       Price = double.Parse(command[2]), 
                                       Type = type
                                   };
                ItemsByPrice.Add(newItem);
                ItemsByType.Add(newItem);
                ItemsByName.Add(command[1]);
                ResultBuilder.AppendLine(
                                         string.Format("Ok: Product {0} added successfully", command[1]));
            }
        }

        private static void FilterByPrice(IList<string> command)
        {
            double min = double.MinValue;
            double max = double.MaxValue;
            if (command.Count >= 6)
            {
                min = double.Parse(command[4]);
                max = double.Parse(command[6]);
            }
            else if (command[3] == "from")
            {
                min = double.Parse(command[4]);
            }
            else
            {
                max = double.Parse(command[4]);
            }

            Item minItem = new Item { Price = min, };
            Item maxItem = new Item { Price = max, };
            IEnumerable<Item> view = ItemsByPrice.Range(minItem, true, maxItem, true).Take(10);
            ResultBuilder.AppendLine(string.Format("Ok: {0}", string.Join(", ", view)));
        }

        private static void FilterByType(IList<string> command)
        {
            string type = command[3];
            Item item = new Item { Type = type };
            IEnumerable<Item> view =
                ItemsByType.Range(item, true, item, true)
                           .OrderBy(i => i.Price)
                           .ThenBy(i => i.Name)
                           .Take(10);

            ResultBuilder.AppendLine(
                                     !view.Any()
                                         ? string.Format("Error: Type {0} does not exists", type)
                                         : string.Format("Ok: {0}", string.Join(", ", view)));
        }

        public class Item : IComparable<Item>
        {
            public string Name { get; set; }

            public double Price { get; set; }

            public string Type { get; set; }

            public int CompareTo(Item other)
            {
                int dif = this.Price.CompareTo(other.Price);
                if (dif != 0)
                {
                    return dif;
                }

                if (this.Name != null && other.Name != null)
                {
                    dif = string.Compare(this.Name, other.Name, StringComparison.Ordinal);
                    if (dif != 0)
                    {
                        return dif;
                    }
                }

                if (this.Type != null && other.Type != null)
                {
                    return string.Compare(this.Type, other.Type, StringComparison.Ordinal);
                }

                return 0;
            }

            public override string ToString()
            {
                return string.Format("{1}({0})", this.Price, this.Name);
            }
        }
    }
}