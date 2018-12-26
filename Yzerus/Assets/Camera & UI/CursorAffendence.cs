using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAffendence : MonoBehaviour
{
	[SerializeField] Texture2D AttackCursor;
	[SerializeField] Texture2D WalkCursor;
	[SerializeField] Texture2D UnknownCursor;
	[SerializeField] Vector2 cursorHotspot = new Vector2 (96, 96);
	CameraRaycaster hit;

	// Use this for initialization
	void Start () 
	{
		hit = GetComponent<CameraRaycaster> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		switch (hit.layerHit) 
		{
			case Layer.Enemy:
			Cursor.SetCursor (AttackCursor,cursorHotspot, CursorMode.Auto);		
			break;

			case Layer.Walkable:
			Cursor.SetCursor (WalkCursor,cursorHotspot, CursorMode.Auto);		
			break;

			default:
			Cursor.SetCursor (UnknownCursor,cursorHotspot, CursorMode.Auto);	
			return;
		}
	}
}
