using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(CameraRaycaster))]
public class CursorAffendence : MonoBehaviour
{
	[SerializeField] Texture2D AttackCursor;
	[SerializeField] Texture2D WalkCursor;
	[SerializeField] Texture2D UnknownCursor;
	[SerializeField] Vector2 cursorHotspot = new Vector2 (0, 0);
	CameraRaycaster hit;

	// Use this for initialization
	void Start () 
	{
		hit = GetComponent<CameraRaycaster> ();
		hit.onLayerChange += OnLayerChange;
	}

	void Update()
	{

	}

	void OnLayerChange(Layer newLayer)
	{
		switch (newLayer) 
		{
			case Layer.Enemy:
			Cursor.SetCursor (AttackCursor, cursorHotspot, CursorMode.Auto);		
			break;
			
			case Layer.Walkable:
			Cursor.SetCursor (WalkCursor, cursorHotspot, CursorMode.Auto);		
			break;
			
			default:
			Cursor.SetCursor (UnknownCursor, cursorHotspot, CursorMode.Auto);	
			return;
		}

	}


	//TODO consider de-registering OnLayerChanged on leaving all game scenes
	/*
	void LateUpdate () 
	{
		switch (hit.currentLayerHit) 
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
	}*/

}
