using UnityEngine;
using System.Collections;

public class MouseTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // Code for OnMouseDown in the iPhone. Unquote to test.
        for (int i = 0; i < Input.touchCount; ++i)
        if (Input.GetTouch(i).phase.Equals(TouchPhase.Began)) {
            //      RaycastHit2D hit = Physics2D.Raycast (cldr.transform.position, new Vector2(0, -1), 1.2f);

            // Construct a ray from the current touch coordinates
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, new Vector2(0f, 0f));
            if (hit)
                hit.transform.gameObject.SendMessage("OnMouseDown");
        }
	}
}
