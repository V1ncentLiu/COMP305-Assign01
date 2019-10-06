using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Scene Game Objects")]
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject PowerUp;    

    public int noOfEnemy1;
    public int noOfEnemy2;
    public int noOfPwUp;
    public List<GameObject> enemy1;
    public List<GameObject> enemy2;
    public List<GameObject> pwup;

    [Header("Audio Sources")]
    public SoundClip activeSoundClip; 
    public AudioSource[] audioSources;

    [Header("Scoreboard")]
    [SerializeField]
    private int _lives;
    [SerializeField]
    private int _score;

    public Text livesLabel;
    public Text scoreLabel;

    public int Lives
    {
        get
        {
            return _lives;
        }
        set
        {
            _lives = value;
            livesLabel.text = "Lives: " + _lives.ToString();
        }
    }

    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            scoreLabel.text = "Score: " + _score.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Lives = 100;
        Score = 0;


        if ((activeSoundClip != SoundClip.NONE) && (activeSoundClip != SoundClip.NUM_OF_CLIPS))
        {
            AudioSource activeAudioSource = audioSources[(int)activeSoundClip];
            activeAudioSource.playOnAwake = true;
            activeAudioSource.loop = true;
            activeAudioSource.volume = 0.1f;
            activeAudioSource.Play();
        }        

        enemy2 = new List<GameObject>();
        for (int en2num = 0; en2num < noOfEnemy2; en2num++)
        {
            enemy2.Add(Instantiate(Enemy2));
        }
        for (int en1num = 0; en1num < noOfEnemy1; en1num++)
        {
            enemy1.Add(Instantiate(Enemy1));
        }
        for (int pwupnum = 0; pwupnum < noOfPwUp; pwupnum++)
        {
            pwup.Add(Instantiate(PowerUp));
        }        
    }

    // Update is called once per frame
    void Update()
    {
        if (Lives < 0)
        {
            SceneManager.LoadScene(2);
        }
        PlayerPrefs.SetInt("FScore", Score);
    }
}
