using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class LinePiecesArgs : EventArgs {
	
	private LinePieces _line;
	public LinePieces Line
	{
		get { return _line; }
		set { _line = value; }
	}

	// Use this for initialization
	void Start () {
		_line = new LinePieces ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
