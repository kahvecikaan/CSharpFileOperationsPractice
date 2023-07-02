namespace FileOperationPractice;

class Program
{
    static void Main(string[] args)
    {
        // Console.Write("Enter the file path to the file: ");
        // var path = Console.ReadLine();

        string path =  ("./testfile.txt");
        var content = "Hello, this is a test file. It contains several words of varying lengths!";
        File.WriteAllText(path, content);

        var text = RemovePunctuation(File.ReadAllText(path));
        Console.WriteLine("Number of words in the file: " + CountWords(text));
        Console.WriteLine("Longest word in the file: " + FindLongestWord(text));

        File.Delete(path);

    }

    /// <summary>
    /// Write a program that reads a text file and displays the number of words.
    /// </summary>
    
    public static string RemovePunctuation(string input)
    {
        var punctuation = new char[] { '.', ',', ';', ':', '!', '?', '-' };
        foreach (char c in punctuation)
        {
            input = input.Replace(c.ToString(), " ");
        }

        return input;
    }
    public static int CountWords(string text)
    {
        int wordCount = 0, index = 0;
        
        // Skip whitespace until first word
        while (index < text.Length && char.IsWhiteSpace(text[index]))
            index++;
        while (index < text.Length)
        {
            // Skip non-whitespace (the word)
            while (index < text.Length && !char.IsWhiteSpace(text[index]))
                index++;
            
            // Count the word
            wordCount++;

            // Skip whitespace until next word
            while (index < text.Length && char.IsWhiteSpace(text[index]))
                index++;
        }

        return wordCount;
    }

    // <summary>
    // Write a program that reads a text file and displays the longest word in the file.
    // </summary>
    public static string FindLongestWord(string text)
    {
        int index = 0;
        string longestWord = "";
        int longestWordLength = 0;

        while (index < text.Length)
        {
            string word = "";
            while (index < text.Length && !char.IsWhiteSpace(text[index]))
            {
                word += text[index];
                index++;
            }

            if (word.Length > longestWordLength)
            {
                longestWord = word;
                longestWordLength = word.Length;
            }

            while (index < text.Length && char.IsWhiteSpace(text[index]))
                index++;
        }

        return longestWord;
    }
    
}