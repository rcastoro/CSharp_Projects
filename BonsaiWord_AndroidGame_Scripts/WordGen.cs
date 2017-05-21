using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class WordGen : MonoBehaviour {
	
    public  float vowelPercentage;
	private	List<string> _words = new List<string> ();
	private HashSet<string> _dictionary;
	private char[] abc = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
    private char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'y' };
	private int _boardSize;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	public HashSet<string> Dictionary
	{
		get{ return _dictionary; }
	}
	
	private void LoadDictionary()
	{
		var text = Resources.Load ("Words", typeof(TextAsset)) as TextAsset;
		char[] delim = new char[] { '\r', '\n' };
		string[] array = text.text.Split (delim, StringSplitOptions.RemoveEmptyEntries);
		_dictionary = new HashSet<string> (array);
	}
	
	public void GenerateWords(int level, int rows, int columns, bool newPieces)//implement level complexities;
	{
		if (!newPieces) {
			LoadDictionary ();
			
			_boardSize = rows * columns;
			int totalLetters = Convert.ToInt32 (((float)(rows * columns) * .75f)); // do math here to use level * percent to get good amount of words to use in each level
			int randomIndex = UnityEngine.Random.Range (0, _dictionary.Count);	
			string currentWord;
			int charCount = 0;
			
			while (charCount < totalLetters) 
			{
				currentWord = _dictionary.ElementAt (randomIndex);
				if (currentWord.Count () <= rows && currentWord.Count () > 1) 
				{
					charCount += currentWord.Count ();
                    _words.Add (currentWord);
				}
				randomIndex = UnityEngine.Random.Range (0, _dictionary.Count);
			}
		}
	}
	
    public List<char> ExtractLetters(int vowelsOnBoard)
	{
		List<char> letters = new List<char>();
		foreach (string word in _words) 
		{
            List<char> charWord = word.ToList();
            letters.AddRange(RandomizeLetters(charWord));
		}
		if (letters.Count < _boardSize) 
		{
            letters.AddRange(RandomizeLetters(PadBoard(letters.Count, vowelsOnBoard)));
		}
		return letters;
	}
	
	private List<char> RandomizeLetters(List<char> letters)
	{
		List<char> newLetters = new List<char> ();
		System.Random rnd = new System.Random();
		var randomLetters = letters.OrderBy (a => System.Guid.NewGuid ());
		foreach (char letter in randomLetters)
		{
			newLetters.Add (letter);
		}
		return newLetters;
	}
	
	private List<char> PadBoard(int count, int vowelsOnBoard)
	{
		List<char> extraLetters = new List<char>();
		for (int a = 0; a < _boardSize - count; a++)
		{
            int randomIndex = 0;
            if (vowelsOnBoard < _boardSize * vowelPercentage)
            {
                randomIndex = UnityEngine.Random.Range(0, vowels.Length - 1);
                extraLetters.Add(vowels[randomIndex]);
                vowelsOnBoard++;
            }
            else
            {
                randomIndex = UnityEngine.Random.Range(0, abc.Length - 1);
                extraLetters.Add(abc[randomIndex]);
            }
		}
		_words.Clear ();
		return extraLetters.ToList();
	}
	
}
