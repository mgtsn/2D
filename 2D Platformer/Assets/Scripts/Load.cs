using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{

    public void load(string s)
    {
        SceneManager.LoadScene(s);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}