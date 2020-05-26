using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float angle;
    public float speed = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3
            (
            this.transform.position.x + Mathf.Cos(-(angle - 90) * Mathf.Deg2Rad) * speed,
            this.transform.position.y,
            this.transform.position.z + Mathf.Sin(-(angle - 90) * Mathf.Deg2Rad) * speed
            );
	}
}
