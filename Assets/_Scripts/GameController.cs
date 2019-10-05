using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Scene Game Objects")]
    public GameObject Enemy1;
    public GameObject Enemy2;
    public int noOfEnemy1;
    public int noOfEnemy2;
    public List<GameObject> enemy1;
    public List<GameObject> enemy2;

    [Header("Audio Sources")]
    public SoundClip activeSoundClip; 
    public AudioSource[] audioSources;

    // Start is called before the first frame update
    void Start()
    {
        enemy2 = new List<GameObject>();
        for (int en2num = 0; en2num < noOfEnemy2; en2num++)
        {
            enemy2.Add(Instantiate(Enemy2));
        }
        for (int en1num = 0; en1num < noOfEnemy1; en1num++)
        {
            enemy1.Add(Instantiate(Enemy1));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
