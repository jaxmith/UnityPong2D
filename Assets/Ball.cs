using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
	public float speed = 30;
	private int p1score = 0, p2score = 0;
	private bool gameOver;
	public Text p1text, p2text, game;
	// Use this for initialization
	void Start() {
		//Initial Velocity
		GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
		gameOver = false;
		p1text.text = "Score: " + p1score.ToString();
		p2text.text = "Score: " + p2score.ToString();
	}

	void Update(){

		if(p1score >= 5){
			p1text.text = "Player 1 Wins!";
			gameOver = true;
			game.text = "Game Over! Press Spacebar to restart!";
		}else if(p2score >= 5){
			p2text.text = "Player 2 Wins!";
			gameOver = true;
			game.text = "Game Over! Press Spacebar to restart!";
		}
		if(gameOver){
			if(Input.GetKeyDown(KeyCode.Space)){
				Application.LoadLevel(0);
			}
		}

	}


	void OnCollisionEnter2D(Collision2D col){
		if(!gameOver){
		if(col.gameObject.name == "RacketLeft"){
			float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
			Vector2 dir = new Vector2(1, y).normalized;
			GetComponent<Rigidbody2D>().velocity = dir * speed;
		}

		if(col.gameObject.name == "RacketRight"){
			float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
			Vector2 dir = new Vector2(-1, y).normalized;
			GetComponent<Rigidbody2D>().velocity = dir * speed;
		}

		if(col.gameObject.name == "WallRight"){
			p1score++;
			speed += 3;
			p1text.text = "Score: " + p1score.ToString();
		}

		if(col.gameObject.name == "WallLeft"){
			p2score++;
			speed += 3;
			p2text.text = "Score: " + p2score.ToString();
		}
		}
	}

	float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight) {
		return (ballPos.y - racketPos.y) / racketHeight;
	}

}