using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    // Use this for initialization
    public GameObject selectedZombie;
    public List<GameObject> zombies;

    public Vector3 selectedSize;
    public Vector3 defaultSize;

    public Text scoreText;
    public GameObject pauseButton;

    public GameObject gameOverPanel;
    public AudioClip gameOverSound;
    public Text gameOverText;

    public GameObject pausePanel; 

    private int selectedZombieIndex;
    private int score;

    private AudioSource source; 

    void Start() {
        SelectZombie(selectedZombie);
        selectedZombieIndex = zombies.IndexOf(selectedZombie);
        scoreText.text = "Score: " + score;

        source = GetComponent<AudioSource>();
        Time.timeScale = 1; 
	}
	
	// Update is called once per frame
	void Update () {
        onKeyPressed(); 
	}

    void InitializeZombies()
    {
        System.Random random = new System.Random();
        for(int i = 0; i < zombies.Count; i++)
        {
            int y = random.Next(4, 11);
            int z = random.Next(0, 9);
            Rigidbody zombieRigidBody = zombies[i].GetComponent<Rigidbody>();

            zombies[i].transform.position = new Vector3(zombies[i].transform.position.x, y, z);
            zombieRigidBody.drag = (float)((random.NextDouble() + PlayerPrefs.GetInt("Difficulty")) + 2);
        }
    }

    void SelectZombie(GameObject newZombie)
    {
        selectedZombie.transform.localScale = defaultSize;
        newZombie.transform.localScale = selectedSize;
        selectedZombie = newZombie; 
    }

    void onKeyPressed()
    {
        if (zombies.Count > 0)
        {
            if (Input.GetKeyDown("left"))
                GetZombieLeft();
            if (Input.GetKeyDown("right"))
                GetZombieRight();
            if (Input.GetKeyDown("up"))
                PushZombie();
            if (Input.GetKeyDown("escape"))
            {
                if (!pausePanel.activeSelf)
                    Pause();
                else
                    UnPause(); 
            }
        }
    }

    void GetZombieLeft()
    {
        if (selectedZombieIndex == 0)
            selectedZombieIndex = zombies.Count - 1;
        else
            if(zombies.Count > 1)
                selectedZombieIndex -= 1;

        GameObject newZombie = zombies[selectedZombieIndex];
        SelectZombie(newZombie);
    }
    
    void GetZombieRight()
    {
        if (selectedZombieIndex == zombies.Count - 1)
            selectedZombieIndex = 0;
        else
            if (zombies.Count > 1)
                selectedZombieIndex += 1;

        GameObject newZombie = zombies[selectedZombieIndex];
        SelectZombie(newZombie);
    }

    void PushZombie()
    {
        Rigidbody zombie = selectedZombie.GetComponent<Rigidbody>();
        zombie.AddForce(0, 0, 10, ForceMode.Impulse); 
    }

    public void AddScore()
    {
        score += 1;
        scoreText.text = "Score: " + score;
    }

    public void KillZombie(GameObject zombie)
    {
        zombies.Remove(zombie);
        if (zombies.Count == 0)
            GameOver(); 
    }

    void GameOver()
    {
        source.PlayOneShot(gameOverSound);
        gameOverText.text = score.ToString(); 
        gameOverPanel.SetActive(true);
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1; 
    }
}
