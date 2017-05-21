using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class GamePiece : MonoBehaviour {

	public GameObject letter;
	public string alphaCharacter;
	public Sprite piece_spt;
	public Sprite highlightedPiece_spt;
	public bool active;
	public bool isNew = false;
	public ParticleSystem _wordDust;
    public ParticleSystem _wordFire;
    public GameObject _swipeArrowObj;
    
	MovingObject movingObjectScript;
	Vector3 position;
	GameObject gameManager;
	BoardManager boardManager;
	List<Color> colors = new List<Color>();
    
	public float maxRotation = 10f;
	public float minRotation = -10;

	private TextMesh letterMesh;
    private Color letterColor;
    private Color letterColorHgl;

    enum Direction
    {
        Up,
        UpLeft,
        UpRight,
        Down,
        DownLeft,
        DownRight,
        Left,
        Right
    }

	#region Events
	public event EventHandler<EventArgs> OnWordHighlighted;
	#endregion Events

	// Use this for initialization
	void Start () {
        
        gameManager = GameObject.FindGameObjectWithTag ("GameController");
		boardManager = gameManager.GetComponent<BoardManager> ();

        switch(gameManager.GetComponent<GameManager>().Theme.Theme)
        {
            case Themes.Setting.Wood:
                letterColor = new Color(1f, 0.973f, 0.522f, 1f);
                letterColorHgl = new Color(1f, 1f, 1f, 1f);
                break;
            case Themes.Setting.Beach:
                letterColor = new Color(0.941f, 1f, 0.537f, 1f);
                letterColorHgl = new Color(1f, 1f, 1f, 1f);
                break;
            case Themes.Setting.Grass:
                letterColor = new Color(0.361f, 1f, 0.616f, 1f);
                letterColorHgl = new Color(1f, 1f, 1f, 1f);
                break;
            default:
                break;
        } 

		float randomPieceQuaternion = UnityEngine.Random.Range (minRotation, maxRotation);
		movingObjectScript = GetComponent<MovingObject> ();
		position = gameObject.transform.position;

		Vector3 letterPosition = new Vector3 (position.x, position.y -.05f, 0);
		GameObject instance = Instantiate(letter, letterPosition, Quaternion.Euler(0, 0, randomPieceQuaternion)) as GameObject;
		letterMesh = instance.transform.GetComponent<TextMesh>();
		letterMesh.GetComponent<MeshRenderer> ().sortingOrder = 1;
        letterMesh.fontSize = 150;
		letterMesh.color = letterColor;
		letterMesh.text = alphaCharacter.ToUpper();
		letterMesh.transform.SetParent (this.transform);

		active = false;

//		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer> ();
//		sr.sprite = piece_spt;

		//Subscribe other classes to events
		OnWordHighlighted += new EventHandler<EventArgs> (boardManager.OnWordHighlighted);
	}

	void OnMouseDown()
	{
        // PIECE BG
//		gameObject.GetComponent<SpriteRenderer>().sprite = highlightedPiece_spt;

		letterMesh.color = letterColorHgl;
        boardManager.IsMouseDown = true;
		boardManager.ActivePieces.Add(this);
	}
	
	void OnMouseUp()
	{
		boardManager.IsMouseDown = false;
		RaiseOnWordHighlighted ();

		if (!boardManager.WordFound) 
		{
			RollbackPieces();
			boardManager.ActivePieces = new List<GamePiece> ();
		}
    }

	void RollbackPieces()
	{
		foreach (GamePiece piece in boardManager.ActivePieces) 
		{
            boardManager.destroyArrows = true;
			piece.letterMesh.color = letterColor;
//            piece.GetComponent<SpriteRenderer>().sprite = piece_spt;
        }
	}

	void OnMouseEnter()
	{
		if (boardManager.IsMouseDown && boardManager.ActivePieces[0] != this) {

			if (!boardManager.ActivePieces.Contains(this))
			{
                bool _arrowAlready = false;
				Transform transform = boardManager.ActivePieces [boardManager.ActivePieces.Count - 1].transform;
                Direction moveDirection = Direction.Up;

				float prevX = transform.position.x;
				float prevY = transform.position.y;

				float thisX = gameObject.transform.position.x;
				float thisY = gameObject.transform.position.y;
				
				bool touching = (
								(prevY+1 == thisY && (prevX == thisX || prevX+1 == thisX || prevX-1 == thisX)) // Up or up and diag
					                 || 
					                 (prevY-1 == thisY && (prevX == thisX || prevX-1 == thisX || prevX+1 == thisX)) // Down or down and diag
										||
										((prevX+1 == thisX || prevX-1 == thisX) && Math.Abs(prevY - thisY) < 2) // Left or right & touching
				                 );

                bool moveUp = false;
                bool moveDown = false;
                bool moveLeft = false;
                bool moveRight = false;

                if(prevX+1 == thisX)    // Right
                {
                    moveRight = true;
                }
                else if (prevX-1 == thisX) // Left
                {
                    moveLeft = true;
                }

                if(prevY+1 == thisY)  // ..and up
                {
                    moveUp = true;
                }
                else if (prevY-1 == thisY)
                {
                    moveDown = true;
                }

                if (moveUp)
                {
                    if (moveLeft)
                    {
                        moveDirection = Direction.UpLeft;
                    }
                    else if (moveRight)
                    {
                        moveDirection = Direction.UpRight;
                    }
                    else
                    {
                        moveDirection = Direction.Up;
                    }
                }
                else if (moveDown)
                {
                    if (moveLeft)
                    {
                        moveDirection = Direction.DownLeft;
                    }
                    else if (moveRight)
                    {
                        moveDirection = Direction.DownRight;
                    }
                    else
                    {
                        moveDirection = Direction.Down;
                    }
                }
                else if (moveLeft && !moveUp && !moveDown)
                {
                    moveDirection = Direction.Left;
                }
                else if (moveRight && !moveUp && !moveDown)
                {
                    moveDirection = Direction.Right;
                }

				if(touching)
				{
					boardManager.ActivePieces.Add(this);
//					gameObject.GetComponent<SpriteRenderer>().sprite = highlightedPiece_spt;
					letterMesh.color = letterColorHgl;

                    int rotateDegrees = 0;
                    float offsetX = 0f;
                    float offsetY = 0f;
                    switch(moveDirection)
                    {
                        case Direction.Up:
                            rotateDegrees = 0;
                            offsetY = .5f;
                            break;
                        case Direction.UpRight:
                            rotateDegrees = -45;
                            offsetY = .5f;
                            offsetX = .5f;
                            break;
                        case Direction.UpLeft:
                            rotateDegrees = -315;
                            offsetY = .5f;
                            offsetX = -.5f;
                            break;
                        case Direction.Down:
                            rotateDegrees = 180;
                            offsetY = -.5f;
                            break;
                        case Direction.DownRight:
                            rotateDegrees = -135;
                            offsetY = -.5f;
                            offsetX = .5f;
                            break;
                        case Direction.DownLeft:
                            rotateDegrees = 135;
                            offsetY = -.5f;
                            offsetX = -.5f;
                            break;
                        case Direction.Right:
                            rotateDegrees = -90;
                            offsetX = .5f;
                            break;
                        case Direction.Left:
                            rotateDegrees = 90;
                            offsetX = -.5f;
                            break;
                        default:
                            rotateDegrees = 0;
                            break;
                    }

                    GameObject swipeArrow = Instantiate(_swipeArrowObj, new Vector3(prevX + offsetX, prevY + offsetY, 0f), Quaternion.Euler(0, 0, rotateDegrees)) as GameObject;
                    _arrowAlready = true;
                    boardManager._swipArrows.Add(swipeArrow);
                }
			}
			else
			{
				boardManager.ActivePieces.Remove(this);
//				gameObject.GetComponent<SpriteRenderer>().sprite = piece_spt;
				letterMesh.color = letterColor;
			}
		}
	}

	public void DestroyPiece(bool isBonus)
	{
        Vector3 newPosition;
        ParticleSystem wordEffectPrefab;
        if (isBonus)
        {
            wordEffectPrefab = _wordFire;
            newPosition = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y + .40f, -4f);
        }
        else
        {
            wordEffectPrefab = _wordDust;
            newPosition = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, -4f);
        }

        ParticleSystem wordDust = Instantiate (wordEffectPrefab, newPosition, Quaternion.identity) as ParticleSystem;
		Destroy(movingObjectScript);	//this should be destroyed before OnWordRemoved is called, why null ref?
		Destroy(gameObject);
	}
    
    // Update is called once per frame
	void Update () {

    }

	void RaiseOnWordHighlighted ()
	{
		EventHandler<EventArgs> handler = OnWordHighlighted;
		if (handler != null) 
		{
			handler(null, null);
		}
	}

}