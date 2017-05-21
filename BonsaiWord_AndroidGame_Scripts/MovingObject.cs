using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MovingObject : MonoBehaviour {

	public float moveTime = 0.1f;			//Time it will take object to move, in seconds.
	private Vector2 origin = -Vector2.one;
	private Vector2 to = -Vector2.one;
	private float inverseMoveTime;			//Used to make movement more efficient.

	GameObject gameManager;
	BoardManager boardManager;
	Board board;
	GamePiece gamePiece;

	bool isFalling = false;
	
	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectWithTag ("GameController");
		boardManager = gameManager.GetComponent<BoardManager> ();
		board = gameManager.GetComponent<Board> ();
		gamePiece = GetComponent<GamePiece> ();

		//By storing the reciprocal of the move time we can use it by multiplying instead of dividing, this is more efficient.
		inverseMoveTime = 1f / moveTime;

		// IF newly generated piece - fall
		CheckForFloor ();
	}

//	void OnTriggerEnter2D(Collider2D other)
//	{
//		GamePiece otherPiece = other.GetComponent<GamePiece> ();
//
//		// Only act if instance of gamepiece is active
//		if (gamePiece.name == boardManager.ActivePieceName) 
//		{
//			float x = origin.x - gamePiece.transform.position.x;
//			float y = origin.y - gamePiece.transform.position.y;
//			int xDir = 0;
//			int yDir = 0;
//
//			if (Mathf.Abs (x) > Mathf.Abs (y))
//				xDir = x > 0 ? 1 : -1;
//			else
//				yDir = y > 0 ? 1 : -1;
//
//			Move (xDir, yDir, otherPiece);
//			Debug.Log (this.name.ToString () + " entered " + other.name.ToString ());
//		}
//	}

	public void Move(int xDir, int yDir, GamePiece piece)
	{
		Vector2 start = piece.transform.position;
		Vector2 end = (start + new Vector2 (xDir, yDir));

		StartCoroutine(SmoothMovement (end, piece));
	}
	
	private IEnumerator SmoothMovement(Vector3 end, GamePiece piece)
	{
		yield return StartCoroutine (FinishMovement (end, piece));

		// Recursive call; check all pieces whenever one piece falls to trigger cascade
		CheckForFloor ();
	}

	private IEnumerator FinishMovement(Vector3 end, GamePiece piece)
	{
		float sqrRemainingDistance = (piece.transform.position - end).sqrMagnitude;
		Rigidbody2D rb2D = piece.GetComponent<Rigidbody2D> ();

        //While that distance is greater than a very small amount (Epsilon, almost zero):
		while(sqrRemainingDistance > float.Epsilon)
		{
			//Find a new position proportionally closer to the end, based on the moveTime
			Vector3 newPostion = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);
			
			//Call MovePosition on attached Rigidbody2D and move it to the calculated position.
			rb2D.MovePosition (newPostion);
			
			//Recalculate the remaining distance after moving.
			sqrRemainingDistance = (piece.transform.position - end).sqrMagnitude;
			
			//Return and loop until sqrRemainingDistance is close enough to zero to end the function
            yield return null;
        }
	}

	// Update is called once per frame
	void Update () {

	}

	void CheckForFloor()
	{
		// Does game piece need to fall (empty space below)?
		BoxCollider2D cldr = gamePiece.GetComponent<BoxCollider2D> (); 
		RaycastHit2D hit = Physics2D.Raycast (cldr.transform.position, new Vector2(0, -1), 1.2f);
		
		if (hit.collider != null) 
		{
			MovingObject mo = hit.collider.GetComponentInParent<MovingObject>();
			if (mo.isFalling && mo.gamePiece.transform.position != gamePiece.transform.position && mo.gamePiece.transform.position.y >= 1)
			{
				isFalling = true;
			}
			else
			{
				isFalling = false;
			}
		}
		else if (hit.collider == null && gamePiece.transform.position.y == 0)
			isFalling = false;
		else
			isFalling = true;	// piece must fall - nothing under and not bottom piece
		
		if (isFalling) 
		{
			Move (0, -1, gamePiece);
		} 
		else 
		{
			board.FallingPieces--;
        }
    }
	

	#region Events
	public void OnWordRemoved(object sender, EventArgs e)
	{
		board.FallingPieces++;
        CheckForFloor ();
    }
    
    #endregion Events
}
