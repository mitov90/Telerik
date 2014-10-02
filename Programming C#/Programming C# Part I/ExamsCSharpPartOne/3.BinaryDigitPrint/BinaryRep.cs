using System;
using System.Text;

class BinaryRep
{
    static void Main()
    {
        int value = int.Parse(Console.ReadLine());
        if ( value < 0 )
            value = -value;
        StringBuilder sb = new StringBuilder();
        string valueAsString = Convert.ToString(value, 2);
        if ( valueAsString.Length > 16 )
        {
            valueAsString = valueAsString.Substring(valueAsString.Length - 16, 16);
        }
        else if (valueAsString.Length<16)
        {
            valueAsString = new string('0', 16 - valueAsString.Length) + valueAsString;
        }
        for ( int row = 0; row < 4; row++ )
        {

            for ( int i = 0; i < valueAsString.Length; i++ )
            {
               
                #region CheckDigit
               
                if ( valueAsString[i] == '1' )
                {
                    switch ( row )
                    {
                        case 0:
                            sb.Append(".#.");
                            break;
                        case 1:
                            sb.Append("##.");
                            break;
                        case 2:
                            sb.Append(".#.");
                            break;
                        case 3:
                            sb.Append("###");
                            break;
                    }
                }
                else
                {
                    switch ( row )
                    {
                        case 0:
                            sb.Append("###");
                            break;
                        case 1:
                            sb.Append("#.#");
                            break;
                        case 2:
                            sb.Append("#.#");
                            break;
                        case 3:
                            sb.Append("###");
                            break;
                    }
                }
                #endregion

               if (i!=15) sb.Append('.');
            }
            sb.Append(Environment.NewLine);
        }
        Console.WriteLine(sb);
    }
}
// TEST:
// 32767
// 196607