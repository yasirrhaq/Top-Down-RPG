﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTimer : MonoBehaviour
{
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer>0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer <=0)
        {
            Destroy(gameObject);
        }
    }
}
