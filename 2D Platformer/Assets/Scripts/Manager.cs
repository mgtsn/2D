using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    private float timer = -1;
    public float maxTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 0)
        {
            timer += Time.deltaTime;
        }

        if(timer >= maxTime)
        {
            Scene s = SceneManager.GetActiveScene();
            SceneManager.LoadScene(s.name);
        }
    }

    public void restartLevel()
    {
        timer = 0;
        
    }


}
