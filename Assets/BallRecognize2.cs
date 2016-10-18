using UnityEngine;
using System.Collections;

public class BallRecognize2 : MonoBehaviour {

	private static float ballgrey = 0f;
	private static float ballwhite = 0f;
	private static float ballorange = 0f;
	public ParticleSystem smoke;
	// Use this for initialization
	void Start () {
		 
	}

	// Update is called once per frame
	void Update () {

		if(ballgrey+ballorange+ballwhite == 10f){

			smoke.Play();
			GetComponent<AudioSource>().Play();
		}



	}

	void OnTriggerEnter (Collider other){

		if (other.gameObject.tag == "Bomb"){

			ballgrey += 3f;

			print ("ball added to trigger");


		}

		if (other.gameObject.tag == "Bomborange"){

			ballorange += 1.5f;


		}

		if (other.gameObject.tag == "Bombwhite"){

			ballwhite += 1f;


		}



	}
}
