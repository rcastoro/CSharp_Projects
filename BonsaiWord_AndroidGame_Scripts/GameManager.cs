using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Facebook.Unity;
using Facebook;
using GooglePlayGames;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
	public Board board;
    public DataPersist dataPersist;
    public GameObject _apiManagerPrefab;
    public AudioSource beachMusicLoopPrefab;
    public AudioSource grassMusicLoopPrefab;
    public AudioSource woodMusicLoopPrefab;
    public GameObject startMenuPrefab;
    public GameObject _backgroundPrefab;
    public Sprite _bgGrass;
    public Sprite _bgBeach;
    public Sprite _bgWood;
    public Themes theme;
    public GameObject _privacyDialogPrefab;

    private GameObject _apiManagerInstance;
    private Canvas canvas;
    private GameObject _instanceStartMenu;
    private AudioSource _instanceMusicLoop;
    private SpriteRenderer _bgInstanceSpriteRend;
    private GameObject _privacyDialog;

    [HideInInspector]
    public Themes Theme
    {
        get{ return theme;}
        set{ theme = value;}
    }

    private BoardManager boardScript;
	private WordGen wordGen;
    private int level = 1;

	// Use this for initialization
	void Awake () {

        //Singleton instantiation pattern
        if (instance == null)
            instance = this;
        else
            DestroyObject(instance);

        boardScript = GetComponent<BoardManager>();
		wordGen = GetComponent<WordGen>();
		board = GetComponent<Board> ();
        StartAPIManager();
    }

    private void StartAPIManager()
    {
        if (_apiManagerInstance == null)
        {
            _apiManagerInstance = Instantiate(_apiManagerPrefab);
        }
    }

    public void InitGame()
    {
        boardScript.SetupScene(level, wordGen, board, theme, this);
    }

    public void SetupStartMenu()
    {
        theme.Theme = Themes.Setting.Beach;
        GameObject bgInstance = Instantiate(_backgroundPrefab);
        _bgInstanceSpriteRend = bgInstance.GetComponent<SpriteRenderer>();
        _bgInstanceSpriteRend.sprite = _bgBeach;
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        _instanceStartMenu = Instantiate(startMenuPrefab) as GameObject;
        _instanceStartMenu.transform.SetParent(canvas.transform, false);
        _instanceMusicLoop = Instantiate(beachMusicLoopPrefab);
        
        // Buttons
        Button[] buttons = _instanceStartMenu.GetComponentsInChildren<Button>();
        
        Button startButton = buttons [0];
        startButton.onClick.AddListener(() => {
            SendMessage("1"); });
        
        Button themeButton = buttons [1];
        themeButton.onClick.AddListener(() => {
            SendMessage("2"); });
        
        Button muteButton = buttons [2];
        muteButton.onClick.AddListener(() => {
            SendMessage("3"); });

        Button logoutButton = buttons [3];
        logoutButton.onClick.AddListener(() => {
            SendMessage("5"); });

        Button policyButton = buttons[4];
        policyButton.onClick.AddListener(() => {
            SendMessage("6");
        });

        //        Button facebookButton = buttons [3];
        //        facebookButton.onClick.AddListener(() => {
        //            SendMessage("4"); });
    }

    public void InitializePrivacyPolicy()
    {
        _privacyDialog = Instantiate(_privacyDialogPrefab) as GameObject;
        _privacyDialog.transform.SetParent(canvas.transform, false);
        InitializeDialog();
    }

    private void InitializeDialog()
    {
        Button[] buttons = _privacyDialog.GetComponentsInChildren<Button>();
        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(() => {
                DestroyDialog();
            });
        }
    }

    private void DestroyDialog()
    {
        Destroy(_privacyDialog);

    }

    public void SendMessage(string button)
    {
        int buttonInt = int.Parse(button);
        switch (buttonInt)
        {
            case 1:
                Destroy(_instanceStartMenu);
                Theme = theme;
                InitGame();
                break;
            case 2:
                if (theme.Theme == Themes.Setting.Beach)
                {
                    theme.Theme = Themes.Setting.Grass;
                    _bgInstanceSpriteRend.sprite = _bgGrass;
                    Destroy(_instanceMusicLoop.gameObject);
                    _instanceMusicLoop = Instantiate(grassMusicLoopPrefab);
                    
                }
                else if (theme.Theme == Themes.Setting.Grass)
                {
                    theme.Theme = Themes.Setting.Wood;
                    _bgInstanceSpriteRend.sprite = _bgWood;
                    Destroy(_instanceMusicLoop.gameObject);
                    _instanceMusicLoop = Instantiate(woodMusicLoopPrefab);
                }
                else
                {
                    theme.Theme = Themes.Setting.Beach;
                    _bgInstanceSpriteRend.sprite = _bgBeach;
                    Destroy(_instanceMusicLoop.gameObject);
                    _instanceMusicLoop = Instantiate(beachMusicLoopPrefab);
                }
                break;
            case 3:
                if(_instanceMusicLoop.isPlaying)
                {
                    _instanceMusicLoop.Stop();
                }
                else
                {
                    _instanceMusicLoop.Play();
                }
                break;
            case 4:
                boardScript.ShowLeaderboard(true);
                break;
            case 5:
                _apiManagerInstance.GetComponent<LoginManager>().LogOut();
                RestartGame();
                break;
            case 6:
                InitializePrivacyPolicy();
                break;
            default:
                break;
        }
    }

    public void LogOut()
    {
        _apiManagerInstance.GetComponent<LoginManager>().LogOut();
    }

	public void RestartGame()
	{
        Destroy(_apiManagerInstance);
		Application.LoadLevel (0);
	}
}
