﻿using UnityEngine;

public class CameraRaycaster : MonoBehaviour
{
	//Get Our 
    public Layer[] layerPriorities = 
	{
        Layer.Enemy,
        Layer.Walkable
    };

    [SerializeField] float distanceToBackground = 100f;
    Camera viewCamera;

    RaycastHit raycastHit;
	public RaycastHit hit
    {
        get { return raycastHit; }
    }

    Layer layerHit;
	public Layer currentLayerHit
    {
        get { return layerHit; }
    }


	public delegate void OnLayerChange(Layer newLayer); //decrale new delegate type
	public event OnLayerChange onLayerChange; //instantiatia an observer set!


    void Start() 
    {
        viewCamera = Camera.main;
    }

	void LateUpdate()
    {
        // Look for and return priority layer hit
        foreach (Layer layer in layerPriorities)
        {
            var hit = RaycastForLayer(layer);
            if (hit.HasValue)
            {
                raycastHit = hit.Value;

				//if layer has changed!
				if(layerHit != layer)
				{
					layerHit = layer;
					onLayerChange(layer);
				}
				//layerHit = layer;
                return;
            }
        }

        // Otherwise return background hit
        raycastHit.distance = distanceToBackground;
        layerHit = Layer.RaycastEndStop;
    }

    RaycastHit? RaycastForLayer(Layer layer)
    {
        int layerMask = 1 << (int)layer; // See Unity docs for mask formation
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition); //turn camera point to a ray!

        RaycastHit hit; // used as an out parameter
        bool hasHit = Physics.Raycast(ray, out hit, distanceToBackground, layerMask);
        if (hasHit)
        {
            return hit;
        }
        return null;
    }
}
