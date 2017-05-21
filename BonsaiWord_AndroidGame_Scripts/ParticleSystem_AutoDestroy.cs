using UnityEngine;
using System.Collections;

public class ParticleSystem_AutoDestroy : MonoBehaviour {

	private ParticleSystem _ps;

	// Use this for initialization
	void Start () {
		_ps = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_ps) 
		{
			if (!_ps.IsAlive())
			{
				Destroy (gameObject);
			}
		}
	}
}
