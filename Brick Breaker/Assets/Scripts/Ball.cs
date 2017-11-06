using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private bool hasStarted = false;
    private Rigidbody2D ball;
    private Vector3 paddleToBallVector;

    private void Awake() {
        ball = GetComponent<Rigidbody2D>();
        paddle = GameObject.FindObjectOfType<Paddle>();
    }
    // Use this for initialization
    void Start () {
        paddleToBallVector = this.transform.position - paddle.transform.position;
        //print(paddleToBallVector);
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted) {
            this.transform.position = paddle.transform.position + paddleToBallVector;

            if (Input.GetMouseButtonDown(0)) {
                hasStarted = true;
                ball.velocity = new Vector2(2f, 10f);
                //this.rigidbody2D.velocity = new Vector2(2f, 10f);
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

        if (hasStarted) {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }
}
