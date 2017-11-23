using UnityEngine;

public class Tile : MonoBehaviour {

    // Use this for initialization

    public Game game;
    public AudioClip hit;

    AudioSource source; 

	void Start () {
        source = GetComponent<AudioSource> (); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        game.AddScore();
        source.PlayOneShot(hit); 
    }
}
