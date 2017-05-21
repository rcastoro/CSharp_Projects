using UnityEngine;
using System.Collections;

public class Themes : MonoBehaviour {
   
    public enum Setting
    {
        Beach,
        Grass,
        Wood
    }

    private Setting _theme;
    public Setting Theme
    {
        get{ return _theme;}
        set{ _theme = value;}
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
