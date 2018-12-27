using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{

	[SerializeField] float walkMoveStopRadius = 0.2f;

    ThirdPersonCharacter thirdPersonCamera;   // A reference to the ThirdPersonCharacter on the object
    CameraRaycaster cameraRaycaster;
    Vector3 currentClickTarget;
	bool isInDirectMode = false;

    private void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        thirdPersonCamera = GetComponent<ThirdPersonCharacter>();
        currentClickTarget = transform.position;
    }

    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
		//TODO: add to menu
		if (Input.GetKeyDown (KeyCode.G)) 
		{
			isInDirectMode = !isInDirectMode; //toogle mode
			currentClickTarget = transform.position; //clear target
		}

		if (isInDirectMode) 
		{
			ProcessDirectMovement();
		} 
		else 
		{
			ProcessMouseMovement (); 
		}


	}

	private void ProcessDirectMovement()
	{

			float h = Input.GetAxis("Horizontal");
			float v = Input.GetAxis("Vertical");
			
			// calculate camera relative direction to move:
			 
			Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
			Vector3 movement = v*cameraForward + h*Camera.main.transform.right;
			
			thirdPersonCamera.Move (movement, false, false);
	}


	public void ProcessMouseMovement()
	{
		if (Input.GetMouseButton(0))
		{
			print("Cursor raycast hit" + cameraRaycaster.hit.collider.gameObject.name.ToString());
			switch (cameraRaycaster.currentLayerHit)
			{
			case Layer.Walkable:
				currentClickTarget = cameraRaycaster.hit.point;
				break;
				
			case Layer.Enemy:
				Debug.Log("Not moving to enemy");
				break;
			default:
				Debug.Log("Should not be here");
				return;
			}
		}
		var playerToClickPoint = currentClickTarget - transform.position;
		
		if (playerToClickPoint.magnitude >= walkMoveStopRadius) {
			thirdPersonCamera.Move (playerToClickPoint, false, false);
		} else 
		{
			thirdPersonCamera.Move (Vector3.zero, false, false);
		}
	}
}

