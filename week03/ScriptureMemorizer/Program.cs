using System;
using System.Collections.Generic;

// Represents a single scripture verse with its reference and text.
public class ScriptureVerse
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int? _endVerse;

    // Constructor for a single verse.
    public ScriptureVerse(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = null;
    }

    // Constructor for a verse range.
    public ScriptureVerse(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    public string GetReference()
    {
        if (_endVerse.HasValue)
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }

        return $"{_book} {_chapter}:{_verse}";
    }
}

// Represents a single word in a scripture.
public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public bool IsHidden
    {
        get { return _isHidden; }
        set { _isHidden = value; }
    }

    public string Text
    {
        get { return _text; }
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }

        return _text;
    }
}

public class Scripture
{
    private ScriptureVerse _verse;
    private List<Word> _words;

    public Scripture(ScriptureVerse verse, string text)
    {
        _verse = verse;
        _words = new List<Word>();

        string[] wordArray = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int count)
    {
        if (count <= 0)
        {
            return;
        }

        Random random = new Random();
        int hiddenCount = 0;

        while (hiddenCount < count && hiddenCount < _words.Count)
        {
            int index = random.Next(_words.Count);
            if (!_words[index].IsHidden)
            {
                _words[index].Hide();
                hiddenCount++;
            }
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden)
            {
                return false;
            }
        }

        return true;
    }

    public string GetDisplayText()
    {
        List<string> displayWords = new List<string>();
        foreach (Word word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }

        return $"{_verse.GetReference()} {string.Join(" ", displayWords)}";
    }

    public string GetPlayText()
    {
        string result = _verse.GetReference() + "\n";
        foreach (Word word in _words)
        {
            result += word.GetDisplayText() + " ";
        }

        return result.Trim();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>();

        scriptures.Add(
            new Scripture(
                new ScriptureVerse("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish but have everlasting life."
            )
        );

        scriptures.Add(
            new Scripture(
                new ScriptureVerse("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
            )
        );

        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());

        while (!scripture.IsCompletelyHidden())
        {
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input != null && input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
        }
    }
}
