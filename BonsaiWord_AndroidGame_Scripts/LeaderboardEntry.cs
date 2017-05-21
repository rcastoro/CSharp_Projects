using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeaderboardEntry : MonoBehaviour {

    public string rankString, usernameString, scoreString;
    public Text rank, username, score;

	// Use this for initialization
	void Start () 
    {
        rank.text = rankString;
        username.text = usernameString;
        score.text = scoreString;	}

    public void UpdateText()
    {
        rank.text = rankString;
        username.text = usernameString;
        score.text = scoreString;
    }
}
