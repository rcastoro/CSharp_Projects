using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LinePieces : IEnumerable<GamePiece> {

	private List<GamePiece> _line = new List<GamePiece>();
	public List<GamePiece> Line
	{
		get { return _line;}
	}
	
	public int Count
	{
		get { return _line.Count;}
	}

	public void AddLine(List<GamePiece> pieces)
	{
		_line.AddRange (pieces);
	}

	public void AddPiece(GamePiece piece)
	{
		_line.Add (piece);
	}

	public IEnumerator<GamePiece> GetEnumerator()
	{
		foreach (GamePiece piece in _line)
		{
			yield return piece;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
