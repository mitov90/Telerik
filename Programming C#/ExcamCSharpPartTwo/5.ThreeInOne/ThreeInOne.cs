using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

class ThreeInOne
{

    private static void FirstProblem()
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        int maxPoints = -1;
        int players = 0;
        int index = -1;

        for (int i = 0; i < input.Length; i++)
        {
            int tempValue = int.Parse(input[i]);
            if (tempValue < 22 && tempValue > maxPoints)
            {
                maxPoints = tempValue;
                players = 1;
                index = i;
            }
            else if (tempValue == maxPoints)
            {
                players++;
            }
        }

        Console.WriteLine("{0}", players == 1 ? index : -1);
    }

    private static void SecondProblem()
    {
        var input = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        int length = input.Length;

        var pieces = new int[length];
        int eaters = int.Parse(Console.ReadLine());

        for (int piece = 0; piece < length; piece++)
        {
            pieces[piece] = int.Parse(input[piece]);
        }
        Array.Sort(pieces, (x, y) => y.CompareTo(x));
        int howEat = 0;
        for (int index = 0; index < length; index += eaters + 1)
        {
            howEat += pieces[index];
        }
        Console.WriteLine(howEat);
    }

    static void Main()
    {
        FirstProblem();

        SecondProblem();

        string[] money = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        int[] tempMoney = new int[3];
        for (int i = 0; i < tempMoney.Length; i++)
        {
            tempMoney[i] = int.Parse(money[i]) - int.Parse(money[i + 3]);
        }

        bool[] tempLock = new bool[3];

        int transfers = 0;
        while (true)
        {
            if (tempMoney[0] >= 0 && tempMoney[1] >= 0 && tempMoney[2] >= 0)
            {
                Console.WriteLine(transfers);
                break;
            }
            if (tempLock[0] && tempLock[2] && (tempMoney[1] < 0))
            {
                Console.WriteLine(-1);
                break;
            }

            #region Gold
            if (tempMoney[0] < 0)
            {
                while (tempMoney[0] != 0)
                {
                    transfers++;
                    tempMoney[1] -= 11;
                    tempMoney[0]++;
                    tempLock[0] = true;
                }
            }
            #endregion
            #region Bronze
            if (tempMoney[2] < 0)
            {
                while (tempMoney[2] < 0)
                {
                    transfers++;
                    tempMoney[2]+=9;
                    tempMoney[1] --;
                    tempLock[2] = true;
                }
            }
            #endregion
            #region Silver
            if (tempMoney[1] < 0)
            {

                while (true)
                {
                    if (tempMoney[0] == 0)
                    {
                        break;
                    }
                    if (tempMoney[1] >= 0)
                    {
                        break;
                    }
                    transfers++;
                    tempMoney[0]--;
                    tempMoney[1] += 9;
                }
                while (tempMoney[2] > 0)
                {
                    if (tempMoney[1] >= 0)
                        break;
                    transfers++;
                    tempMoney[2]-=11;
                    tempMoney[1] ++;
                }

            }
            #endregion

        }
    }


}
