using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public string nextScene;

    private float timer = -1;
    public float winTimer = -1;
    public float maxTime = 3;

    public bool wl = false;

    public float fadeSpeed = .5f;

    public CanvasGroup cg;

    // Start is called before the first frame update
    void Start()
    {
        cg = GetComponent<CanvasGroup>();
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

        if (winTimer >= 0)
        {
            winTimer += Time.deltaTime;
        }

        if (winTimer >= maxTime)
        {
            SceneManager.LoadScene(nextScene);
        }

        if(winTimer > 1 || timer > 1)
        {
            cg.alpha += Time.fixedDeltaTime * fadeSpeed;
        }
    }

    public void restartLevel()
    {
        timer = 0;
        
    }

    public void endLevel()
    {
        winTimer = 0;

    }


}
