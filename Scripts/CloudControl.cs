using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudControl : MonoBehaviour {


    public float speed = -2f;
    public float speed2 = 0;
   // float i;

    Vector3 cl;

	// Use this for initialization
	void Start () {

        cl = gameObject.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {

        if (this.transform.position.x < -488)
        {
            transform.Translate(700, 0, 0);
           // print(this.transform.position.x);
        }

        // i = Random.Range(0,100);
        // i = i / 100;

        //  print(i);
        //print(speed);

        //  speed2 = i * speed;
        speed2 = Time.deltaTime * speed * 10;
       // print(speed2);
        transform.Translate(speed2,0,0);
        
    }
}
