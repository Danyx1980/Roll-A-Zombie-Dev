using UnityEngine;

public class WorldLimit : MonoBehaviour {

    // Use this for initialization

    public Game game;
    public AudioClip death;

    AudioSource source;

    void Start () {
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        game.KillZombie(other.gameObject);
        source.PlayOneShot(death); 
    }
}
