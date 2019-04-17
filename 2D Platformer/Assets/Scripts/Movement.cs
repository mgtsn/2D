using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speedx;
    public float speedy;
    public float maxtime = 6;
    private float timer = 0;
    private int reverse = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speedx * Time.deltaTime * reverse, speedy * Time.deltaTime * reverse, 0);
        timer += Time.deltaTime;
        if (timer >= maxtime)
        {
            reverse *= -1;
            timer = 0;
        }
    }
}
