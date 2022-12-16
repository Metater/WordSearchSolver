Console.WriteLine("Hello World");

//string[] wordsearch = File.ReadAllLines("/home/runner/WordSearchSolver/wordsearch.txt");
string[] wordsearch = File.ReadAllLines(@"E:\Projects\Visual Studio\WordSearchSolver\wordsearch.txt");

while (true)
{
    Console.WriteLine("Enter search word: ");
    string? searchWord = Console.ReadLine();
    if (searchWord!.Length == 0)
    {
        break;
    }
    else
    {
        Search(searchWord);
    }
}

bool TryGetChar(int x, int y, out char c)
{
    c = ' ';
    if (x < 0 || x >= wordsearch[0].Length
       || y < 0 || y >= wordsearch.Length)
    {
        return false;
    }
    c = wordsearch[y][x];
    return true;
}

bool IsWord(int x, int y, int dirX, int dirY, int i, string searchWord)
{
    int xP = x + dirX;
    int yP = y + dirY;
    int iP = i + 1;

    if (iP == searchWord.Length)
    {
        return true;
    }

    char searchChar = searchWord[iP];
    if (TryGetChar(xP, yP, out char c) && c == searchChar)
    {
        return IsWord(xP, yP, dirX, dirY, iP, searchWord);
    }
    else
    {
        return false;
    }
}

void Search(string searchWord)
{
    int xMax = wordsearch[0].Length;
    int yMax = wordsearch.Length;
    for (int y = 0; y < yMax; y++)
    {
        for (int x = 0; x < xMax; x++)
        {
            char c = wordsearch[y][x];
            if (c == searchWord[0])
            {
                if (IsWord(x, y, 0, 1, 0, searchWord))
                {
                    Console.WriteLine($"({(int)((((double)x) / ((double)(xMax - 1))) * 100)}%, {(int)((((double)y) / ((double)(yMax - 1))) * 100)}%)");
                    Console.WriteLine("N");
                    return;
                }
                if (IsWord(x, y, 1, 1, 0, searchWord))
                {
                    Console.WriteLine($"({(int)((((double)x) / ((double)(xMax - 1))) * 100)}%, {(int)((((double)y) / ((double)(yMax - 1))) * 100)}%)");
                    Console.WriteLine("NE");
                    return;
                }
                if (IsWord(x, y, 1, 0, 0, searchWord))
                {
                    Console.WriteLine($"({(int)((((double)x) / ((double)(xMax - 1))) * 100)}%, {(int)((((double)y) / ((double)(yMax - 1))) * 100)}%)");
                    Console.WriteLine("E");
                    return;
                }
                if (IsWord(x, y, 1, -1, 0, searchWord))
                {
                    Console.WriteLine($"({(int)((((double)x) / ((double)(xMax - 1))) * 100)}%, {(int)((((double)y) / ((double)(yMax - 1))) * 100)}%)");
                    Console.WriteLine("SE");
                    return;
                }
                if (IsWord(x, y, 0, -1, 0, searchWord))
                {
                    Console.WriteLine($"({(int)((((double)x) / ((double)(xMax - 1))) * 100)}%, {(int)((((double)y) / ((double)(yMax - 1))) * 100)}%)");
                    Console.WriteLine("S");
                    return;
                }
                if (IsWord(x, y, -1, -1, 0, searchWord))
                {
                    Console.WriteLine($"({(int)((((double)x) / ((double)(xMax - 1))) * 100)}%, {(int)((((double)y) / ((double)(yMax - 1))) * 100)}%)");
                    Console.WriteLine("SW");
                    return;
                }
                if (IsWord(x, y, -1, 0, 0, searchWord))
                {
                    Console.WriteLine($"({(int)((((double)x) / ((double)(xMax - 1))) * 100)}%, {(int)((((double)y) / ((double)(yMax - 1))) * 100)}%)");
                    Console.WriteLine("W");
                    return;
                }
                if (IsWord(x, y, -1, 1, 0, searchWord))
                {
                    Console.WriteLine($"({(int)((((double)x) / ((double)(xMax - 1))) * 100)}%, {(int)((((double)y) / ((double)(yMax - 1))) * 100)}%)");
                    Console.WriteLine("NW");
                    return;
                }
            }
        }
    }
}
