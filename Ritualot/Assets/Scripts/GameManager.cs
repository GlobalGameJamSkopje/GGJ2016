using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager GM;

    public float GameSpeed = 20;
	// Use this for initialization
	void Awake() {

        if (GM == null) GM = this;
        else if(GM != this) Destroy(this);
        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
