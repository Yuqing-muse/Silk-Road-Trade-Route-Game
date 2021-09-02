using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duihua : MonoBehaviour {
    public GameObject g;
    private image c;
    public AudioSource a;
    public npc animc;
    // Use this for initialization
    void Start () {
        a = this.GetComponent<AudioSource>();
        animc=this.GetComponent<npc>();
        c = g.GetComponent<image>();
	}

    // Update is called once per frame
    public void OnMouseDown()
    {
        animc.state = 2;
        c.onShow();
        a.Play();
    }
}
