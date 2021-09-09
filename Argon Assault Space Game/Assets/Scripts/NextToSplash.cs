using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextToSplash : MonoBehaviour
{
    void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<NextToSplash>().Length;
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadLevelOne", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadLevelOne()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(1);
    }
}
