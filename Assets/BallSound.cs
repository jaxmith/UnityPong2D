using UnityEngine;
using System.Collections;

public class BallSound : MonoBehaviour {

	public AudioClip ping;
	public AudioClip point;
	public float volume = 0.5F;
	private AudioSource source;

	void Start(){
		source = GetComponent<AudioSource>();
	}

	void OnCollisionEnter2D(Collision2D col){

		if(col.gameObject.name != "RacketLeft" || col.gameObject.name != "RacketRight")
			source.PlayOneShot(ping, volume);

		if(col.gameObject.name == "WallRight" || col.gameObject.name == "WallLeft")
			source.PlayOneShot(point, volume);
	}
}
