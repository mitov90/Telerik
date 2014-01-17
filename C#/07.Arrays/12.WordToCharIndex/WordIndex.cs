using System;

class WordIndex
{
    static void Main()
    {
        Console.Write("Enter word: ");
        string word = Console.ReadLine().ToUpper();
        char[] letters = new char[26];
        byte counter = 0;
        for ( int i = 'A'; i <= 'Z'; i++ )
        {
            letters[counter++] = (char)i;
        }
        for ( int i = 0; i < word.Length; i++ )
        {
            Console.WriteLine(word[i] + "= " + LetterToIndex(word[i],letters));
        }
    }

    static int LetterToIndex(char letter,char[] letters)
    {
        for ( int i = 0; i < letters.Length; i++ )
        {
            if ( letters[i] == letter )
                return i;
        }
        return -1;
    }
}
