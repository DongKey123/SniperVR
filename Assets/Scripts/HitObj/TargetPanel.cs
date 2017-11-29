using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetPanel : HitObject     {

    Animator anim;
    public AudioSource m_HitAudio;
    public Action Over;

	Vector3 raycastHitPoint;

	[SerializeField]
	ImpactWood hitEffect;
	// Use this for initialization
	void Start () {

        anim = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Hit(Vector3 hitPosition, float distance)
    {
        if (Over != null)
            Over();

        float Delay = distance / 100;
		raycastHitPoint = hitPosition;
		Invoke("HitDelay", Delay);
        
    }

    void HitDelay()
    {
		hitEffect.transform.position = raycastHitPoint;
		hitEffect.Play();

		this.GetComponent<Collider>().enabled = false;
        m_HitAudio.Play();
        anim.Play("Hit");
    }
}
