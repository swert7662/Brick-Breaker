using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;
    void Awake() {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
    void OnTriggerEnter2D(Collider2D trigger) {
        //print("Trigger");
        levelManager.LoadLevel("Lose");
    }
}
