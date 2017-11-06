using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;

    void Awake () {
        //Debug.Log("Music player Awake " + GetInstanceID());
        if (instance != null) {
            Destroy(gameObject);
            //print("Dupe music player self-destruct!");
        }
        else {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }   
	}
}
