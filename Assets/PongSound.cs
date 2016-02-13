using UnityEngine;
using System.Collections;

public class PongSound : MonoBehaviour {

	public AudioClip ping;
	public float volume = 0.5F;
	private AudioSource source;

	void Start(){
		source = GetComponent<AudioSource>();
	}

	void OnCollisionEnter2D(Collision2D col){

		if(col.gameObject.name == "Ball")
			source.PlayOneShot(ping, volume);
	}
}
