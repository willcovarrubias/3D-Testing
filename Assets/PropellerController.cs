﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerController : MonoBehaviour {

    public float speed;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
            transform.Rotate(Vector3.up, speed * Time.deltaTime);

    }
}
