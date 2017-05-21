using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using Facebook.Unity;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using System;

public class BoardManager : MonoBehaviour {

	#region Events
	public event EventHandler<EventArgs> OnWordRemoved;
	public event EventHandler<EventArgs> OnNewLetters;
	#endregion Events

	public GamePiece _gamePiece;
	public GameObject _movingObject;
    public GameObject _dataPersistPrefab;

    public int _bigBonusThreshold;
    public int _bigBonusMultiplier;
	public int _rows;
	public int _columns;
	public float _secondsLeft;
	public float _bgSwitchInterval;
	public Text _textPrefab;
	public Text _multiplierTextPrefab;
    public Text _shufflePenaltyTextPrefab;
	public Text _secondsLeftTextPrefab;
	public Text _spelledWordPointsTextPrefab;
	public int _multi_01_Thres;
	public AudioSource _wordRemoved_SoundPrefab;
    public AudioSource _multiplierRemoved_SoundPrefab;
    public GameObject _leaderBoardPrefab;
    public GameObject _scoreAndTimePrefab;
    public GameObject _submenuPrefab;
    public GameObject _shufflePrefab;
    public GameObject _gamePlayMenuPrefab;
    public GameObject _challengePanelPrefab;
    public GameObject _timePanelPrefab;
    public Button _pauseButtonPrefab;
    public Button _backButtonPrefab;
    public Text _finalHeaderPointsTextPrefab;
    public Text _finalPointsTextPrefab;
    public GameObject _pauseMenuPrefab;
    public float _challengeTimerThreshold;

    [HideInInspector]
    public bool destroyArrows = false;
    [HideInInspector]
    public List<GameObject> _swipArrows = new List<GameObject>();
	
    private DataPersist _dataPersistInstance;
	private Camera _camera;
	private float _timer;
	private int _points;
	private int _secondsLeftInt;
    private float _totalTimeFloat = 0f;
	private Text _pointsText;
	private Text _timeText;
	private float _listWordsYCord = 285f;
	private Text _multiplier;
	private Color _multiplierColor = new Color (.48f, .87f, .91f);
    private Text _shufflePenalty;
    private Color _shufflePenaltyColor = new Color (.48f, .87f, .91f);
	private int _pointMuiltiplier = 1000;
    private float _secondsLeftPreserve;
	private ScrollRect _scrollView;
	private RectTransform _viewportTransform;
	private Vector2 _scrollPosition;
	private Scrollbar _scrollBar;
	private RectTransform _content;
    private GameObject _pauseMenu;
	private GameObject _gameDetails_Panel;
	private RectTransform _gameDetails_RectTransform;
	private GameObject _time_Panel;
	private RectTransform _time_RectTransform;
    private bool initialized = false;
    private GameObject _submenuInstance;
    private GameObject _shuffleInstance;
    private GameObject _challengeInstance;
    private Button _shuffleButton;
    private Button _pauseButton;
    private Button _backButton;
    private Themes _themes;
    private AudioSource _removeSound;
    private AudioSource _multiplierRemoveSound;
    private int _multiplierCount;
    private List<int> _challengeTimes = new List<int>();
    private string _challengeString;
    private int _challengePoints = 0;
    private bool _challengeStarted = false;
    private float _challengeTimer;

    // Bonuses
    private int _bigBonusCount = 0;
    private float _bigBonusTimer = 0f;
    private float _bigBonusTimerThreshold = 25.0f;
    private bool _bigBonusIsActive = false;

    //Tropy thresholds
    private int _thresholdZenPlaceTrophy = 5;

	private Canvas _canvas = new Canvas();
	public Canvas Canvas
	{
		get{ return _canvas;}
	}

	private WordGen _wordGen;
	public WordGen WordGen
	{
		get{ return _wordGen;}
	}
	private Board _board;
	private GameManager _gameManager;
    private List<Vector3> _gridPositions = new List<Vector3>();
	private List<Vector3> _newPositions;

	private List<string> _activeWords = new List<string>();
    private Transform _boardHolder;
	private int _level;
	private bool _piecesPendingPlacement;
	
	private List<GamePiece> _activePieces;
	public List<GamePiece> ActivePieces
	{
		get { return _activePieces; }
		set { _activePieces = value; }
	}

	private bool isMouseDown;
	public bool IsMouseDown
	{
		get { return isMouseDown; }
		set { isMouseDown = value; }
    }

	private bool wordFound;
	public bool WordFound
	{
		get { return wordFound; }
		set { wordFound = value; }
	}

    public void Awake()
    {
        _secondsLeftPreserve = _secondsLeft;
    }
    
    public void SetupScene(int level, WordGen wordGen, Board board, Themes themes, GameManager gameManager)
    {
		// Properties
		_wordGen = wordGen;
		_level = level;
		_board = board;
		_gameManager = gameManager;
		_camera = Camera.main;
		_points = 0;
		_timer = 0f;
        _themes = themes;

        int challenge1StartTime = 0;
        int challenge1EndTime = (int)(_secondsLeft * .333);

        int challenge2StartTime = challenge1EndTime;
        int challenge2EndTime = (int)(_secondsLeft * .665);

        int challenge3StartTime = challenge2EndTime;
        int challenge3EndTime = (int)_secondsLeft;

        _challengeTimes.Add(UnityEngine.Random.Range(challenge1StartTime, challenge1EndTime));
        _challengeTimes.Add(UnityEngine.Random.Range(challenge2StartTime, challenge2EndTime));
        _challengeTimes.Add(UnityEngine.Random.Range(challenge3StartTime, challenge3EndTime));

        //Bug timer.... fix here patch
        _totalTimeFloat = 0f;
        _secondsLeft = _secondsLeftPreserve;

		//Display Points
		_canvas = GameObject.FindGameObjectWithTag ("Canvas").GetComponent<Canvas>();
        _dataPersistInstance = Instantiate(_dataPersistPrefab).GetComponent<DataPersist>();

        GameObject scoreTimeInstance = Instantiate(_scoreAndTimePrefab) as GameObject;
        scoreTimeInstance.transform.SetParent(_canvas.transform, false);

        _pauseButton = Instantiate(_pauseButtonPrefab) as Button;
        _pauseButton.transform.SetParent(_canvas.transform, false);
        _pauseButton.onClick.AddListener(() => {
            PauseGame();
        });

        _backButton = Instantiate(_backButtonPrefab) as Button;
        _backButton.transform.SetParent(_canvas.transform, false);
        _backButton.onClick.AddListener(() => {
            _gameManager.RestartGame();
        });

        _shuffleInstance = Instantiate(_shufflePrefab) as GameObject;
        _shuffleInstance.transform.SetParent(_canvas.transform, false);
        _shuffleButton = _shuffleInstance.GetComponentInChildren<Button>();
        _shuffleButton.onClick.AddListener(() => {
            ShuffleBoard();
        });

        _scrollView = _canvas.GetComponentInChildren<ScrollRect> ();
		_scrollBar = _canvas.GetComponentInChildren<Scrollbar> ();
		_content = _scrollView.content;

		_gameDetails_Panel = GameObject.FindGameObjectWithTag ("PointsPanel");
		_gameDetails_RectTransform = _gameDetails_Panel.GetComponent<RectTransform> ();

        GameObject timePanel = Instantiate(_timePanelPrefab);
        timePanel.transform.SetParent(_canvas.transform, false);

		_time_Panel = GameObject.FindGameObjectWithTag ("TimePanel");
		_time_RectTransform = _time_Panel.GetComponent<RectTransform> ();

		// Points display
		_pointsText = Instantiate (_textPrefab, new Vector3 (0f, -6f, 0f), Quaternion.identity) as Text;
		_pointsText.text = "Points: " + _points.ToString ();
		_pointsText.transform.SetParent (_gameDetails_RectTransform.transform, false);

		// Timer display
		_timeText = Instantiate (_secondsLeftTextPrefab, new Vector3 (0f, 0f, 0f), Quaternion.identity) as Text;
		_secondsLeftInt = (int)_secondsLeft;
		_timeText.text = _secondsLeftInt.ToString ();
		_timeText.transform.SetParent (_time_Panel.transform, false);

		//Theme related UI changes
        switch (_themes.Theme)
        {
            case Themes.Setting.Wood:
                _content.GetComponent<Image>().color = new Color(1f, 0.973f, 0.522f, .5f);
                _gameDetails_Panel.GetComponent<Image>().color = new Color(1f, 0.973f, 0.522f, .5f);
                break;
            case Themes.Setting.Beach:
                _content.GetComponent<Image>().color = new Color(0.65f, 0.72f, 0.8f, .5f);
                _gameDetails_Panel.GetComponent<Image>().color = new Color(0.65f, 0.72f, 0.8f, .5f);
                break;
            case Themes.Setting.Grass:
                _content.GetComponent<Image>().color = new Color(0.4f, 0.82f, 0.8f, 0.5f);
                _gameDetails_Panel.GetComponent<Image>().color = new Color(0.4f, 0.82f, 0.8f, 0.5f);
                break;
            default:
                break;
        }

        _removeSound = Instantiate(_wordRemoved_SoundPrefab) as AudioSource;
        _multiplierRemoveSound = Instantiate(_multiplierRemoved_SoundPrefab) as AudioSource;

        // Get Started with board definition and setup
		_activePieces = new List<GamePiece> ();
		_boardHolder = new GameObject("Board").transform;

		InitializeList();
        BoardSetup(_gridPositions, false);
        initialized = true;
    }

    void InitializeList()
    {
        for (float x = 1.5f; x < _columns + 1.5f; x++)
        {
            for (float y = 0; y < _rows; y++)
            {
                _gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

	void BoardSetup(List<Vector3> gridPositions, bool NewPieces)
    {
		List<char> letters = GetLetters (NewPieces);
		int letterIndex = 0;
		MovingObject movingObjectScript;

		GamePiece instance;
		foreach (Vector3 vector in gridPositions)
		{
			instance = Instantiate(_gamePiece, vector, Quaternion.identity) as GamePiece;
			instance.name = letters[letterIndex].ToString();
			_board.AddPiece(instance);

			GamePiece pieceScript = instance.GetComponent<GamePiece>();
			pieceScript.alphaCharacter = letters[letterIndex].ToString();
            instance.transform.SetParent(_boardHolder);
			movingObjectScript = instance.GetComponent<MovingObject>();
				
			//Subscribe other classes to events
			OnWordRemoved += new EventHandler<EventArgs> (movingObjectScript.OnWordRemoved);

			letterIndex++;
        }
		Debug.Log ("----------");
    }
	
    List<char> GetLetters(bool newPieces)
	{
        List<string> vowels = new List<string>() {"a", "e", "i", "o", "u", "y"};
        int vowelsOnBoard = 4;
        _wordGen.GenerateWords (_level, _rows, _columns, newPieces);
        return _wordGen.ExtractLetters (vowelsOnBoard);
	}

	bool GetAllActiveWords()
	{
		//Properties
        int bonusAmount = 0;
		_board.ActiveLine = GetLine ();
		bool match = false;
        int timeBonusInt = 0;
        int scopePoints = 0;

        string displayBonus = "";
		string wordString = string.Empty;
		string reversedWord = string.Empty;

		foreach(GamePiece piece in _board.ActiveLine)
		{
			wordString += piece.alphaCharacter;
		}

		if (_board.ActiveLine.Count > 2)
        {
            // Use hashset to speed up operation/reduce data set to search by up to 95% compared to List
            match = _wordGen.Dictionary.Contains(wordString);
            if (match)
            {
                _activeWords.Add(wordString);

                // Handle preliminary point and bonuses
                if (_bigBonusIsActive)
                {
                    bonusAmount = _bigBonusMultiplier;
                    timeBonusInt = wordString.Length >= _multi_01_Thres ? (3 * wordString.Length) : _bigBonusMultiplier;
                } else
                {
                    bonusAmount = 1;
                    timeBonusInt = wordString.Length >= _multi_01_Thres ? (3 * wordString.Length) : 2;
                }

                if (wordString == _challengeString && _challengeStarted)
                {
                    _points += _challengePoints;
                    scopePoints += _challengePoints;
                }

                _points += (wordString.Length * _pointMuiltiplier) * bonusAmount;
                scopePoints += (wordString.Length * _pointMuiltiplier) * bonusAmount;

                foreach (GamePiece piece in _board.ActiveLine)
                {
                    _board.RemovePiece(piece);
                    piece.DestroyPiece(_bigBonusIsActive);
                    _removeSound.Play();
                }

                RaiseOnWordRemoved();
                _newPositions = CalculateNewPieceLocations();
                _piecesPendingPlacement = true;

                // Display words found in scrollView
                Text spelledWord = Instantiate(_spelledWordPointsTextPrefab, new Vector3(5f, _listWordsYCord, 0f), Quaternion.identity) as Text;

                if (wordString.Length >= _multi_01_Thres)
                {
                    displayBonus = " x" + wordString.Length.ToString();
                } else if (_bigBonusIsActive)
                {
                    displayBonus = " x" + _bigBonusMultiplier.ToString();
                }

                if (wordString.Length >= _multi_01_Thres)
                {
                    _multiplierRemoveSound.Play();
                    _multiplier = Instantiate(_multiplierTextPrefab) as Text;
                    _multiplier.transform.SetParent(_canvas.transform, false);
                    _multiplier.color = _multiplierColor;
                    _multiplier.fontStyle = FontStyle.Bold;
                    _multiplier.text = wordString.Length.ToString() + "x Multiplier";

                    _points += (wordString.Length * _pointMuiltiplier) * wordString.Length;
                    scopePoints += (wordString.Length * _pointMuiltiplier) * wordString.Length;
                    MutliplierEffects(_multiplier);

                    // Setup big bonuses
                    _multiplierCount++;
                    _bigBonusCount++;
                } else
                {
                    _bigBonusCount = 0;
                }

                spelledWord.text = _activeWords [_activeWords.Count - 1].ToString() + "   +" + scopePoints.ToString();
                spelledWord.transform.SetParent(_content.transform, false);
                _listWordsYCord -= 20;
                Text timeBonus = Instantiate(_spelledWordPointsTextPrefab, new Vector3(5f, _listWordsYCord, 0f), Quaternion.identity) as Text;
                timeBonus.text = "        +" + timeBonusInt.ToString() + " sec";
                timeBonus.transform.SetParent(_content.transform, false);
                _secondsLeft += timeBonusInt;
                _totalTimeFloat += timeBonusInt;
                
                _listWordsYCord -= 20;
                scopePoints = 0;
            }

            wordString = string.Empty;
            _pointsText.text = "Points: " + _points.ToString();
        }
		return match;
	}

	List<Vector3> CalculateNewPieceLocations()
	{
		List<Vector3> newVectors = new List<Vector3> ();
		int columnCount = 0;
		int prevMultiXCount = 0;
		foreach (GamePiece piece in _activePieces) 
		{

			// if (prevX == piece.transform.position.x)
			// OR

			// int count = _activePieces.Count(n => n.transform.position.x == piece.transform.position.x);
			// if (_activePieces.Count(n => n.transform.position.x == piece.transform.position.x) > 1)

			int count = _activePieces.Count(n => n.transform.position.x == piece.transform.position.x);
			if (_activePieces.Count(n => n.transform.position.x == piece.transform.position.x) > 1)
			{
				columnCount++;
				columnCount += prevMultiXCount;
				prevMultiXCount = columnCount;
			}
			else
			{
				columnCount = 0;
			}

			newVectors.Add (new Vector3(piece.transform.position.x, _columns + columnCount, 0f));
			columnCount = 0;
		}
		return newVectors;
	}

	void MutliplierEffects(Text text)
	{
		StartCoroutine (MutliplierEffectsCoRo(text));
	}

    void DisplayFinalPoints()
    {
        Text finalPointsHeaderText = Instantiate(_finalHeaderPointsTextPrefab) as Text;
        finalPointsHeaderText.transform.SetParent(_canvas.transform, false);

        Text finalPointsText = Instantiate(_finalPointsTextPrefab) as Text;
        finalPointsText.transform.SetParent(_canvas.transform, false);

        string headerText = "";

        if (_points < 100000)
        {
            headerText = "NICE TRY";
        } 
        else if (_points >= 100000 && _points < 200000)
        {
            headerText = "GOOD";
        }
        else if (_points >= 200000 && _points < 400000)
        {
            headerText = "BETTER";
        }
        else if (_points >= 400000 && _points < 700000)
        {
            headerText = "OUTSTANDING";
        }
        else if (_points >= 700000 && _points < 1000000)
        {
            headerText = "ZEN PLACE";
        }
        else if (_points >= 1000000)
        {
            headerText = "GRAND MASTER";
        }

        finalPointsHeaderText.text = headerText;
        finalPointsText.text = _points.ToString("N0") + " Points";

        StartCoroutine (FinalPointsEffects(finalPointsHeaderText, true));
        StartCoroutine (FinalPointsEffects(finalPointsText, false));
    }

    IEnumerator FinalPointsEffects(Text text, bool isHeader)
    {
        float duration = 5f; //0.5 secs
        float currentTime = 0f;
        int finalSize = 0;

        if (isHeader)
            finalSize = 75;
        else
            finalSize = 35;

        while(currentTime < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, currentTime/duration);
            float size = Mathf.Lerp (text.fontSize, finalSize, currentTime/duration);
            text.fontSize = (int)size;
            currentTime += Time.deltaTime;
            yield return null;
        }
        
        GameObject obj = text.gameObject;
        Destroy (obj);
        Scores(_points, (int)_totalTimeFloat);
        yield break;
    }

    IEnumerator ChallengeEffectsFadeIn(GameObject challengePanel)
    {
        float duration = 2.5f; //0.5 secs
        float currentTime = 0f;
        Image pnlImage = challengePanel.GetComponent<Image>();
        
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(0f, 1f, currentTime / duration);
            pnlImage.color = new Color(pnlImage.color.r, pnlImage.color.g, pnlImage.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(ChallengeEffectsFadeOut(challengePanel));
        yield break;
    }

    IEnumerator ChallengeEffectsFadeOut(GameObject challengePanel)
    {
        float duration = 2.5f; //0.5 secs
        float currentTime = 0f;
        Image pnlImage = challengePanel.GetComponent<Image>();

        while(currentTime < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, currentTime/duration);
            pnlImage.color = new Color(pnlImage.color.r, pnlImage.color.g, pnlImage.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }

        Destroy (challengePanel.gameObject);
        yield break;
    }

	IEnumerator MutliplierEffectsCoRo(Text text)
	{
		float duration = 1f; //0.5 secs
		float currentTime = 0f;
		int finalSize = 200;
		while(currentTime < duration)
		{
			float alpha = Mathf.Lerp(1f, 0f, currentTime/duration);
			float size = Mathf.Lerp (text.fontSize, finalSize, currentTime/duration);
			text.fontSize = (int)size;
			text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
			currentTime += Time.deltaTime;
			yield return null;
		}

        GameObject obj = text.gameObject;
		Destroy (obj);
		yield break;
	}

    void PauseGame()
    {
        _pauseMenu = Instantiate(_pauseMenuPrefab) as GameObject;
        _pauseMenu.transform.SetParent(_canvas.transform, false);
    }

	void EndGame()
	{
        DestroyBoard();

        _board.ResetBoard();
        Destroy (_scrollBar.gameObject);
		Destroy (_scrollView.gameObject);
		Destroy (_pointsText.gameObject);
		Destroy (_timeText.gameObject);
		Destroy (_gameDetails_Panel.gameObject);
		Destroy (_time_Panel.gameObject);
        Destroy (_shuffleInstance.gameObject);
        Destroy (_pauseButton.gameObject);
        Destroy (_backButton.gameObject);
        ShowFinalUIFragments();
//		_gameManager.RestartGame ();
	}

    void DestroyBoard()
    {
        foreach (GamePiece piece in _board) 
        {
            piece.DestroyPiece(_bigBonusIsActive);
        }
    }

    void ShowFinalUIFragments()
    {
        DisplayFinalPoints();
    }

    public void Scores(int score, int time)
    {
        GameObject apiMangager = GameObject.FindGameObjectWithTag("ApiManager");
        LoginManager lMang = apiMangager.GetComponent<LoginManager>();
        if (lMang.loginType == 2)
        {
            try
            {
                new GameSparks.Api.Requests.LogEventRequest_postScore().Set_score(score).Set_time(time).Send((response) =>
                {
                    if (response.HasErrors)
                    {
                        Debug.Log("Failed");
                    } else
                    {
                        Debug.Log("Successful");
                    }
                });
                ShowLeaderboard(true);
                ShowSubMenu();
            } 
            catch
            {
                _dataPersistInstance.writeStringToFile("Player," + score.ToString() + "," + time.ToString(), "scores");
                ShowLeaderboard(false); 
                ShowSubMenu();            
            }
        } 
        else if (lMang.loginType == 1)
        {
            // Report Google Play Score to Leaderboard
            Social.ReportScore(score, "CgkI7eKGgfsHEAIQAA", (bool success) => {
                if (success)
                {
                    //empty
                }
            });
            Social.ShowLeaderboardUI();
            ShowSubMenu();
        }
        else
        {
            _dataPersistInstance.writeStringToFile("Player,"+score.ToString()+","+time.ToString(), "scores");
            ShowLeaderboard(false); 
            ShowSubMenu();
        }
    }
    public void ShowSubMenu()
    {
        _submenuInstance = Instantiate(_submenuPrefab) as GameObject;
        _submenuInstance.transform.SetParent(_canvas.transform, false);

        // Buttons
        Button[] buttons = _submenuInstance.GetComponentsInChildren<Button>();
        
        Button mainmenuButton = buttons [0];
        mainmenuButton.onClick.AddListener(() => {
            SubmenuManager("1"); });
    }

    public void SubmenuManager(string button)
    {
        int buttonInt = int.Parse(button);
        switch (buttonInt)
        {
            case 1:
                _gameManager.RestartGame();
                break;
            default:
                break;
        }
    }

    void ShuffleBoard()
    {
        OnWordRemoved = null;
        DestroyBoard();
        _board.ResetBoard();
        BoardSetup(_gridPositions, false);
        _activeWords.Clear();
        _activePieces.Clear();
        RemoveShufflePoints();
    }

    void RemoveShufflePoints()
    {
        _secondsLeft -= 15f;

        _shufflePenalty = Instantiate(_shufflePenaltyTextPrefab) as Text;
        _shufflePenalty.transform.SetParent (_canvas.transform, false);
        _shufflePenalty.color = _shufflePenaltyColor;
        _shufflePenalty.fontStyle = FontStyle.Bold;

        MutliplierEffects(_shufflePenalty);
    }
    
    public void ShowLeaderboard(bool loggedIn)
    {
        GameObject leaderboard = Instantiate(_leaderBoardPrefab) as GameObject;
        Leaderboard instance = leaderboard.GetComponent<Leaderboard>();
        instance.GetLeaderboard(loggedIn, _dataPersistInstance);
        leaderboard.transform.SetParent(_canvas.transform, false);
    }

    LinePieces GetLine()
	{
		LinePieces line = new LinePieces ();
		line.AddLine(_activePieces);
		return line;
	}
	    
	void Update()
	{
        if (initialized)
        {
            _timer += Time.deltaTime;

            _secondsLeft -= Time.deltaTime;
            _secondsLeftInt = (int)_secondsLeft;

            if (_timeText != null)
            {
                _timeText.text = _secondsLeftInt.ToString();
            }

            if (_secondsLeft <= 0f)
            {
                EndGame();
            } else
            {
                _totalTimeFloat += Time.deltaTime;
            }

            // Bonuses
            if (_bigBonusIsActive)
            {
                _bigBonusTimer += Time.deltaTime;

                if (_bigBonusTimer < _bigBonusTimerThreshold)
                {
                    _timeText.color = Color.red;
                }
                else
                {
                    _timeText.color = Color.white;
                    _bigBonusIsActive = false;
                    // Reset so multiple bonuses per game
                     _bigBonusCount = 0;
                    _bigBonusTimer = 0f;
                }
            }

            // Challenges
            int _timeInteger = (int)_timer;
            if (_challengeTimes.Contains(_timeInteger))
            {
                _challengeTimes.Remove(_timeInteger);
                List<string> words = new List<string>();
                if (_challengeInstance == null)
                {
                    words = _board.GetWordsOnBoard();
                    if (words.Count > 0)    // Do we atleast have one freggin word?
                    {
                        var sorted = from s in words
                            orderby s.Length ascending
                                select s;
                        _challengeString = sorted.ElementAt(0);

                        _challengePoints = (_challengeString.Length * _pointMuiltiplier) * (_challengeString.Length + 1);
                        _challengeTimer = 0f;
                        _challengeInstance = Instantiate(_challengePanelPrefab);
                        _challengeInstance.transform.SetParent(_canvas.transform, false);
                        _challengeStarted = true;

                        Text[] texts = _challengeInstance.GetComponentsInChildren<Text>();
                        foreach (Text txt in texts)
                        {
                            if (txt.text == "challengetext")
                            {
                                txt.text = "FIND \"" + _challengeString + "\" IN " + _challengeTimerThreshold.ToString() + " SECONDS";
                            }
                            else if (txt.text == "challengepoints")
                            {
                                txt.text = _challengePoints.ToString() + " POINTS";
                            }
                        }
                        StartCoroutine (ChallengeEffectsFadeIn(_challengeInstance));
                    }
                }
                _challengeTimer += Time.deltaTime;
                if (_challengeTimer >= _challengeTimerThreshold)
                {
                    _challengeStarted = false;
                }
            }

            //BACKGROUND COLOR SWITCH EFFECT

            //		if (_timer >= _bgSwitchInterval) 
            //		{
            //			_camera.backgroundColor = _colors[UnityEngine.Random.Range(0, _colors.Count - 1)];
            //			_timer = 0f;
            //		}
        }

		// Wait until pieces have fallen to generate new pieces
		if (_piecesPendingPlacement) 
		{
			if (_board.FallingPieces <= 0)
			{
				BoardSetup (_newPositions, true);
				_piecesPendingPlacement = false;
			}
		}

        if (destroyArrows)
        {
            foreach (GameObject arrow in _swipArrows)
            {
                Destroy(arrow);
            }
            destroyArrows = false;
        }
    }
    
	#region Events
	public void OnWordHighlighted(object sender, EventArgs e)
	{
		if (GetAllActiveWords())
        {
            // Trophy
            if(PlayGamesPlatform.Instance.IsAuthenticated() && _multiplierCount == _thresholdZenPlaceTrophy)
            {
                Social.ReportProgress("CgkI7eKGgfsHEAIQCA", 100.0f, (bool success) => {
                    // empty
                });
            }

            // In Game Point Bonus - Big Bonus if 3 mutlipliers found, increase all word finds by 5X for 25 seconds
            if (_bigBonusCount == _bigBonusThreshold)
            {
                _bigBonusIsActive = true;
            }
        }
	}

	void RaiseOnWordRemoved ()
	{
		foreach (GamePiece piece in _board.ActiveLine) {
			MovingObject mo = piece.GetComponent<MovingObject>();
			OnWordRemoved -= mo.OnWordRemoved;
		}

		EventHandler<EventArgs> handler = OnWordRemoved;
		if (handler != null) 
		{
			handler(null, EventArgs.Empty);
		}
	}

	void RaiseOnNewLetters (MovingObject mo)
	{		
		EventHandler<EventArgs> handler = OnNewLetters;
		if (handler != null) 
        {
            handler(null, EventArgs.Empty);
        }

    }
	#endregion Events
}