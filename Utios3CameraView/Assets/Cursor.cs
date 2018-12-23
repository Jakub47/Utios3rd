using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
	CameraRaycaster hit;

	// Use this for initialization
	void Start () 
	{
		hit = GetComponent<CameraRaycaster> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log (hit.layerHit);	
	}
}
