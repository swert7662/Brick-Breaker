using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public GameObject smoke;

    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;
    // Use this for initialization
    void Start () {
        isBreakable = (this.tag == "Breakable");
        if(isBreakable) {
            breakableCount++;
        }
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
    void OnCollisionExit2D(Collision2D collision) {
        if (isBreakable) {
            AudioSource.PlayClipAtPoint(crack, transform.position);
            HandleHits();
        }
    }

    void HandleHits() {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits) {
            breakableCount--;
            levelManager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);
        }
        else {
            LoadSprites();
        }
    }
    void PuffSmoke() {
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        ParticleSystem ps = smokePuff.GetComponent<ParticleSystem>();
        ParticleSystem.MainModule psmain = ps.main;
        psmain.startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }
    void LoadSprites() {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex]) {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else {
            Debug.LogError("Missing Brick Sprite");
        }
    }
}
