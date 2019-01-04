using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{

	[SerializeField] float walkMoveStopRadius = 0.2f;
	[SerializeField] float attackMoveStopRadius = 5f;

    ThirdPersonCharacter thirdPersonCamera;   // A reference to the ThirdPersonCharacter on the object
    CameraRaycaster cameraRaycaster;
	Vector3 currentDestination, clickPoint;
	bool isInDirectMode = false;

    private void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        thirdPersonCamera = GetComponent<ThirdPersonCharacter>();
        currentDestination = transform.position;
    }

    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
		//TODO: add to menu
		if (Input.GetKeyDown (KeyCode.G)) 
		{
			isInDirectMode = !isInDirectMode; //toogle mode
			currentDestination = transform.position; //clear target
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
			clickPoint = cameraRaycaster.hit.point;
			switch (cameraRaycaster.currentLayerHit)
			{
				
			case Layer.Walkable:
				currentDestination = ShortDestination(clickPoint,walkMoveStopRadius);//curent destination is some shorte distance of the clicked point by some range
				break;
				
			case Layer.Enemy:
				currentDestination = ShortDestination(clickPoint,attackMoveStopRadius);//curent destination is some shorte distance of the clicked point by some range
				break;
			default:
				Debug.Log("Should not be here");
				return;
			}
		}
		WalkToDestination ();
		
	}

	void WalkToDestination ()
	{
		var playerToClickPoint = currentDestination - transform.position;
		if (playerToClickPoint.magnitude >= 0) {
			thirdPersonCamera.Move (playerToClickPoint, false, false);
		}
		else {
			thirdPersonCamera.Move (Vector3.zero, false, false);
		}
	}

	Vector3 ShortDestination(Vector3 destination, float shortening)
	{
		Vector3 reductionVector = (destination - transform.position).normalized * shortening;
		return destination - reductionVector;
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.black;

		//Draw Line from player to position where he wants to go!
		Gizmos.DrawLine (transform.position, currentDestination);
		Gizmos.DrawSphere (currentDestination, 0.1f);

		//Visualize the click point
		Gizmos.DrawSphere(clickPoint, .15f);

		//Draw Attack sphere
	    Gizmos.color = new Color(255f,0f,0f, .5f);
		Gizmos.DrawWireSphere (transform.position, attackMoveStopRadius);
	}
}

