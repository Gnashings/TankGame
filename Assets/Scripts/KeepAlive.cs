using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepAlive : MonoBehaviour
{
    public bool thisData;
    public bool proceed;
    public bool readData;
    private bool levelMoved;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        PlayerProgress.TestingScript(thisData);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!levelMoved)
        {
            if (proceed == true)
            {
                levelMoved = true;
                SceneManager.LoadScene("TestingScene2");
            }
            if (proceed == false)
            {
                if (PlayerProgress.TestingScript(thisData) == true)
                {
                    Debug.Log("System saved, ready to proceed to scene 2");
                }
            }
        }
        if(readData)
        {
            PlayerProgress.ReadData();
            readData = false;
        }

    }
}
