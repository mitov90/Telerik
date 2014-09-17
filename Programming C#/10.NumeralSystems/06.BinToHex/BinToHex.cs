using System;
using System.Text;

class BinToHex
{
    static void Main()
    {
        string binaryNumber = "1111011111110000";

        int nibbles = (int)Math.Ceiling(binaryNumber.Length / 4.0);
        binaryNumber = binaryNumber.PadLeft(nibbles * 4, '0');
        StringBuilder sb = new StringBuilder();

        for ( int i = 0; i < nibbles; i++ )
        {
            string hexDigit = binaryNumber.Substring(i * 4, 4);
            sb.Append(GetHexDigit(hexDigit));
        }
        Console.WriteLine(sb);
    }
    
        private static string GetHexDigit(string nibble)
        {
            switch (nibble)
            {
                case "0000":
                    {
                        return "0";
                    }
                case "0001":
                    {
                        return "1";
                    }
                case "0010":
                    {
                        return "2";
                    }
                case "0011":
                    {
                        return "3";
                    }
                case "0100":
                    {
                        return "4";
                    }
                case "0101":
                    {
                        return "5";
                    }
                case "0110":
                    {
                        return "6";
                    }
                case "0111":
                    {
                        return "7";
                    }
                case "1000":
                    {
                        return "8";
                    }
                case "1001":
                    {
                        return "9";
                    }
                case "1010":
                    {
                        return "A";
                    }
                case "1011":
                    {
                        return "B";
                    }
                case "1100":
                    {
                        return "C";
                    }
                case "1101":
                    {
                        return "D";
                    }
                case "1110":
                    {
                        return "E";
                    }
                case "1111":
                    {
                        return "F";
                    }
                default:
                    {
                        return String.Empty;
                    }
            }
        }

}