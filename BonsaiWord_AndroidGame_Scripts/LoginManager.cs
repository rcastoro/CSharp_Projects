using UnityEngine;
using System.Collections;
using Facebook.Unity;
using Facebook;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GameSparks.Api.Requests;
using System.Collections.Generic;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour {

    public GameObject _loginWelcomePrefab;
    public GameObject _loginTypeSelectPrefab;
    public int loginType;
    public GameManager _gameManager;

    private float _loginWelcomeTimer = 0f;
    private Canvas _canvas;
    private bool destroyedAlready = false;
    private GameObject _loginWelcome;
    private GameObject _loginSelect;
    private bool _showLoginWelcome = false;

    // Use this for initialization
    void Awake () {
        _canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        if (FB.IsLoggedIn)
        {
            BeginGame(2);
        } 
        else if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            BeginGame(1);
        }
        else
        {
            loginType = 0;
            InitializeLogin();
        }
    }

    public void InitializeLogin()
    {
        loginType = 0;
        _loginSelect = Instantiate(_loginTypeSelectPrefab) as GameObject;
        _loginSelect.transform.SetParent(_canvas.transform, false);
        InitializeLoginButtons();
    }

    private void InitializeLoginButtons()
    {
        Button[] buttons = _loginSelect.GetComponentsInChildren<Button>();
        foreach (Button btn in buttons)
        {
            Text txt = btn.GetComponentInChildren<Text>();

            if (txt.text == "Google+")
            {
                btn.onClick.AddListener(() => {
                    GooglePlayLogin();
                });
            }
            else if (txt.text == "Facebook")
            {
                btn.onClick.AddListener(() => {
                    InitializeFacebook();
                });
            }
            else if (txt.text == "X")
            {
                btn.onClick.AddListener(() => {
                    GoLocal();
                });
            }
        }
    }

    private void GoLocal()
    {
        Destroy(_loginSelect);
        BeginGame(0);
    }

    private void InitializeFacebook()
    {
        Destroy(_loginSelect);
        //If facebook is not Initialized
        if (!FB.IsInitialized)
        {
            //Call FB.Init and once that's complete we'll call 
            //Facebook Login
            FB.Init(FacebookLogin);
        }
        //Otherwise if we already initialized call Facebook Login
        else
        {
            FacebookLogin();
        }
    }

    private void FacebookLogin()
    {
        //Call FB.Login, tell it to call GameSparksLogin
        //when done
        FB.LogInWithReadPermissions(new List<string>() {}, GameSparksLogin);
    }

    void GooglePlayLogin()
    {
        Destroy(_loginSelect);
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) => {
            if (success)
            {
                BeginGame(1);
            }
            else
            {
                BeginGame(0);
            }
        });
    }

    private void BeginGame(int loggedInAs)
    {
        loginType = loggedInAs;
//        if (loginType == 1)
//        {
//            try
//            {
//                GoogleGameSparksLogin();
//            }
//            catch
//            {
//                Debug.Log("Google Sparks Login failed and is in a catch");
//            }
//        }
        ShowWelcomePanel(loggedInAs);
        ShowStartMenu();
    }

    private void GoogleGameSparksLogin()
    {
        //We set the access token to the newly added built in funtion in Google Play Games to get our token
        new GooglePlusConnectRequest().SetAccessToken(PlayGamesPlatform.Instance.GetAccessToken()).Send((googleAuthResponse) =>
        {
            if (googleAuthResponse.HasErrors)
            {
                Debug.Log("Something failed with connecting with google+");
            }
            else
            {
                Debug.Log("Successfully logged into google+");
            }
        });
    }
    
    //GameSparksLogin takes FBResult from FB.Login but we don't use it 
    //for anything
    public void GameSparksLogin(ILoginResult result) 
    {
        //It never hurts to double check it you are logged into Facebook                
        //before trying to log into GameSparks with Facebook
        if (FB.IsLoggedIn)
        {
            //This is the standard FacebookConnectRequest. This will                        
            //log into GameSparks with your Facebook Profile.
            new FacebookConnectRequest().SetAccessToken(AccessToken.CurrentAccessToken.TokenString).Send((response) =>
            {
                if (response.HasErrors)
                {
                    Debug.Log("Something failed with connecting with Facebook");
                    BeginGame(0);
                } 
                else
                {
                    Debug.Log("Successfully logged into facebook");
                    BeginGame(2);
                }
            });
        } 
    }

    public void LogOut()
    {
        PlayGamesPlatform.Instance.SignOut();
        if (FB.IsInitialized)
        {
            FB.LogOut();
        }
    }

    void ShowWelcomePanel(int type)
    {
        _loginWelcome = Instantiate(_loginWelcomePrefab);
        _loginWelcome.transform.SetParent(_canvas.transform, false);
        Text txt = _loginWelcome.GetComponentInChildren<Text>();

        if (type == 0)
        {
            txt.text = "Local scoring only";
        } else if (type == 1)
        {
            txt.text = "Logged into Google+";
        } else if (type == 2)
        {
            txt.text = "Logged into Facebook";
        }

        _showLoginWelcome = true;
    }

    
    private void ShowStartMenu()
    {
        _gameManager.SetupStartMenu();
    }
    
    void Update()
    {
        if (_loginWelcomeTimer <= 2 && !destroyedAlready && _showLoginWelcome)
        {
            _loginWelcomeTimer += Time.deltaTime;
        } 
        else if (_loginWelcomeTimer > 2 && _showLoginWelcome)
        {
            if (!destroyedAlready)
                Destroy(_loginWelcome);

            destroyedAlready = true;
        }
    }
}