using UnityEngine;
using System.Collections;

public class PickupObject : MonoBehaviour {
	GameObject mainCamera;
	public bool carrying;
	GameObject carriedObject;
	public float distance;
	GameObject throwableBomb;
	GameObject findBomb;
	 
	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		if (carrying){

			carry(carriedObject); 
			checkDrop();
		}
			else
		
		{
			pickup();
		
		}
	}

	void carry (GameObject o){ 
	
	o.transform.position = mainCamera.transform.position + mainCamera.transform.forward * distance;

	}

	void pickup(){

		if (Input.GetMouseButton (0))				//Pick up Object with Mouse Button Right

		{
			int x = Screen.width /2;
			int y = Screen.height /2;

			Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit))

			{
				Pickupable p = hit.collider.GetComponent<Pickupable>();
				if (p != null){

					carrying = true;
					carriedObject = p.gameObject;
					p.gameObject.GetComponent<Rigidbody>().isKinematic = true;
				}
			}
		}
	}

	void checkDrop(){

		if (Input.GetMouseButtonUp (0)){

			dropObject();
		}
	}

	void dropObject(){

		carrying = false;
		carriedObject.GetComponent<Rigidbody>().isKinematic = false;
		carriedObject = null;

	}
	//Throw the ball

	void throwing(){

		findBomb = GameObject.FindGameObjectWithTag("Bomb");
		//throwableBomb = gameObject.GetComponent<Bomb>().Rigidbody();
		if (Input.GetMouseButtonDown (0) && carrying == true){

		gameObject.GetComponent<Rigidbody> ().AddForce (0f, 0f, 12f);
	}

 }

}
