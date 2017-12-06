using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetPanel : HitObject     {

    Animator anim;
    public AudioSource m_HitAudio;
    public Action Over;

	Vector3 raycastHitPoint;
	bool isChooseRandomTarget = false;

	[SerializeField]
	ImpactWood hitEffect;

	// Use this for initialization
	void Start () {

        OVRHapticsClip clip = new OVRHapticsClip(1);

        anim = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool IsChooseRandomWake()
	{
		return isChooseRandomTarget;
	}

	public void WakeUp(bool random = false)
	{
		isChooseRandomTarget = random;
		anim.Play( "WakeUp" );
		Invoke( "ColliderOn", 0.25f );
	}

	void ColliderOn()
	{
		this.GetComponent<Collider>().enabled = true;
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

	public void FlipBackTarget()
	{
		if ( GetComponent<Collider>().enabled == false )
			return;

		this.GetComponent<Collider>().enabled = false;
		m_HitAudio.Play();
		anim.Play( "Hit" );
	}
}
