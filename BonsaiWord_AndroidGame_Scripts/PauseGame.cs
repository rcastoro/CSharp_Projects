using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseGame : MonoBehaviour {

    private Button unpauseButton;

	void Start () {
        Time.timeScale = 0;
        unpauseButton = gameObject.GetComponentInChildren<Button>();
        unpauseButton.onClick.AddListener(() => {
            UnpauseGame();
        });
	}

    void UnpauseGame()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
