﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontWallMovement : MonoBehaviour {
    public float moveSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
    }
}
