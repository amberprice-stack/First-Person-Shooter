using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {

    public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletObject = GameObject.Instantiate<GameObject>(bulletPrefab);
           

            BulletController bullet = bulletObject.GetComponent<BulletController>();
            bullet.angle = this.transform.localEulerAngles.y;

            bulletObject.transform.position = new Vector3
                (
                    this.transform.position.x + Mathf.Cos(-(bullet.angle - 90) * Mathf.Deg2Rad) * 3,
                    this.transform.position.y,
                    this.transform.position.z + Mathf.Sin(-(bullet.angle - 90) * Mathf.Deg2Rad) * 3
                );

        }
		
	}
}
