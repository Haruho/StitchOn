using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 轮盘的行为
/// </summary>
public class WheelBehaviour : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0,0,Time.deltaTime * speed);
	}
}
