using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dongkey;

public class Zombie : HitObject {

    Animator anim;
    [HideInInspector]
    FSMStateMachine<Zombie> m_stateMachine;

	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
        m_stateMachine = new FSMStateMachine<Zombie>();
        m_stateMachine.InitialSetting(this, ZombieFSMIdle.Instance);
    }
	
	// Update is called once per frame
	void Update () {
        m_stateMachine.Update();
	}

    public override void Hit()
    {
        base.Hit(); 
    }
}
