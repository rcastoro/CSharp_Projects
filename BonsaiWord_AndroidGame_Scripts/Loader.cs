using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Loader : MonoBehaviour {

    public GameManager gameManager;
    private GameManager _gameManagerInstance;

	// Use this for initialization
	void Awake () {
        if (GameManager.instance == null)
        {
            _gameManagerInstance = Instantiate(gameManager) as GameManager;
        }
	}
}
