using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPanel : HitObject {

    Animator anim;
    public AudioSource m_HitAudio;

    // Use this for initialization
    void Start () {

        anim = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Hit()
    {
        Debug.Log("Panel Hit");
        this.GetComponent<Collider>().enabled = false;
        m_HitAudio.Play();
        anim.Play("Hit");
    }
}
