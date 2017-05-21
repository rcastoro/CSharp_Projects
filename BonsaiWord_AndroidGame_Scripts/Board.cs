using UnityEngine;
using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;

public class Board : MonoBehaviour {

	private static Board instance = null;
    private WordGen _wordGen;
	private List<GamePiece> _gamePieces = new List<GamePiece>();
	public List<GamePiece> GamePieces
	{
		get {return _gamePieces;}
	}
   
	private LinePieces _activeLine;
	public LinePieces ActiveLine
	{
		get {return _activeLine;}
		set { _activeLine = value;}
    }

    private List<LinePieces> _rows;
    public List<LinePieces> Rows
    {
        get {return _rows;}
        set
        {
            _rows = value;
        }
    }

    private List<LinePieces> _columns;
    public List<LinePieces> Columns
    {
        get {return _columns;}
        set{ _columns = value;}
    }

    private List<LinePieces> _lines;
    public List<LinePieces> Lines
    {
        get {return _lines;}
    }

	private int _fallingPieces;
	public int FallingPieces
	{
		get{ return _fallingPieces;}
		set { _fallingPieces = value;}
	}
    
	// Use this for initialization
	void Awake () {

        _wordGen = GetComponent<WordGen>();

    	//Singleton instantiation pattern
    	if (instance == null)
    		instance = this;
    	else
    		DestroyObject(instance);
	}

	public void AddPiece(GamePiece gamePiece)
	{
		_gamePieces.Add(gamePiece);
	}

	public int GetIndex(GamePiece gamePiece)
	{
		return _gamePieces.IndexOf (gamePiece);
	}

	public GamePiece GetGamePieceByIndex(int index)
	{
		return _gamePieces[index];
	}

	public void RemovePiece(GamePiece piece)
	{
		_gamePieces.Remove(piece);
	}

	public void ResetBoard()
	{
        _gamePieces = new List<GamePiece>();
	}

	private void Move(int index1, int index2)
	{
		GamePiece movedPiece = _gamePieces [index1];
		_gamePieces [index1] = _gamePieces [index2];
		_gamePieces [index2] = movedPiece;
	}

    private void UnionLines()
    {
        _lines = new List<LinePieces> ();
        _lines.AddRange (_rows);
        _lines.AddRange (_columns);
    }

	public IEnumerator GetEnumerator()
	{
		return _gamePieces.GetEnumerator ();
	}

    public List<string> GetWordsOnBoard()
    {
        //Properties
        Rows = GetRows();
        Columns = GetColumns();
        UnionLines ();
        bool match = false;
        List<LinePieces> wordsToSearch = new List<LinePieces> ();
        wordsToSearch = CombinationsToList ();
        
        string wordString = string.Empty;
        List<string> wordStrings = new List<string>();
        char[] reversedCharArray;
        string reversedWord = string.Empty;
        bool isReversed = false;
        
        foreach (LinePieces word in wordsToSearch) 
        {
            foreach(GamePiece piece in word)
            {
                wordString += piece.alphaCharacter;
            }
            
            if (word.Count > 2)
            {
                match = _wordGen.Dictionary.Contains(wordString);
                
                reversedCharArray = wordString.ToCharArray();
                System.Array.Reverse(reversedCharArray);
                reversedWord = new string(reversedCharArray);

                if (!match)
                {
                    match = _wordGen.Dictionary.Contains(reversedWord);
                    if (match)
                    {
                        isReversed = true;
                    }
                }

                if (match)
                {
                    if (isReversed)
                    {
                        char[] charArray = wordString.ToCharArray();
                        Array.Reverse(charArray);
                        wordString = new string(charArray);
                        wordStrings.Add(wordString);
                    }
                    else
                    {
                        wordStrings.Add(wordString);
                        wordString = "";
                    }
                }
                else
                {
                    wordString = "";
                }
            }
        }
        return wordStrings;
    }

    List<LinePieces> CombinationsToList() 
    {
        List<LinePieces> combos = new List<LinePieces> ();
        LinePieces currentLine;
        GamePiece piece = new GamePiece ();
        LinePieces searchRow = new LinePieces ();
        List<GamePiece> currentWord;
        
        foreach (LinePieces line in Lines)
        {
            for(int x = 0; x <= 6; x++)
            {
                currentWord = new List<GamePiece> ();
                searchRow.AddLine(line.Line.Where ((j, i) => (i >= x) == true ).ToList());
                for (int y = 0; y < searchRow.Count; y++)
                {
                    currentLine = new LinePieces();
                    piece = searchRow.Line[y];
                    currentWord.Add(piece);
                    
                    if (currentWord.Count > 1)
                    {
                        currentLine.AddLine(currentWord);
                        combos.Add(currentLine);
                    }
                    
                    piece = new GamePiece ();
                }
                searchRow = new LinePieces ();
                
            }
        }        
        return combos;
    }

    List<LinePieces> GetRows()
    {
        List<LinePieces> lines = new List<LinePieces> ();
        LinePieces line;
        List<GamePiece> pieces = new List<GamePiece> ();
        for (float x = 1.5f; x < 7.5; x += 1.5f)
        {
            line = new LinePieces ();
            
            pieces = GamePieces.Where (z => z.transform.position.x == x).ToList();
            
            /* Allow blank spaces to be skipped (not necessary when new pieces drop into place when others dissappear)
            for(int x = 0; x < pieces.Count; x++)
            {
                GamePiece piece = new GamePiece();
                GamePiece piece = new GamePiece();

                piece = pieces[x];
                nextPiece = pieces[x+1];

                if (piece.transform.position.y + 1 != pieces
            }
            */
            
            line.AddLine(pieces);
            lines.Add(line);
        }
        return lines;
    }

    List<LinePieces> GetColumns()
    {
        List<LinePieces> lines = new List<LinePieces> ();
        LinePieces line = new LinePieces ();
        List<GamePiece> pieces = new List<GamePiece> ();
        for (int y = 0; y < 6; y++)
        {
            line = new LinePieces ();
            
            pieces = GamePieces.Where (z => z.transform.position.y == y).ToList();
            line.AddLine(pieces);
            lines.Add(line);
        }
        
        return lines;
    }

//	#region Events
//	public void OnGamePeiceMoved(object sender, MovingObjectArgs e)
//	{
//		MovingObjectArgs pieces = e;
//		int idxPiece1 = _gamePieces.IndexOf (e.Piece1);
//		int idxPiece2 = _gamePieces.IndexOf (e.Piece2);
//
//		Move (idxPiece1, idxPiece2);
//	}
//	#endregion Events

}