using System.Collections.Generic;
using System.Linq;

class CrosswordGenerator
{
    private readonly int size;
    private readonly List<string> words;
    private char[] ch;

    private string[] currentCrossword;
    private bool solutionFound;

    public CrosswordGenerator(List<string> words, int size)
    {
        this.words = words.OrderBy(x => x).ToList();
        this.size = size;
    }

    private void Solve(int currentIndex)
    {
        if (currentIndex == this.size)
        {
            bool isOK = true;
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    this.ch[j] = this.currentCrossword[j][i];
                }
                if (!this.words.Contains(new string(this.ch)))
                    //if (words.BinarySearch(new string(ch)) < 0)
                {
                    isOK = false;
                    break;
                }
            }
            if (isOK)
            {
                this.solutionFound = true;
            }
            return;
        }
        for (int i = 0; i < this.words.Count; i++)
        {
            this.currentCrossword[currentIndex] = this.words[i];
            this.Solve(currentIndex + 1);
            if (this.solutionFound) return;
        }
    }

    public string[] GenerateCrossword()
    {
        this.currentCrossword = new string[this.size];
        this.ch = new char[this.size];
        this.Solve(0);
        if (this.solutionFound)
        {
            return this.currentCrossword;
        }
        return null;
    }
}
