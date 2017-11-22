using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dongkey;

public class ZombieFSMTrace : FSMState<Zombie> {


    static readonly ZombieFSMTrace instance = new ZombieFSMTrace();

    public static ZombieFSMTrace Instance
    {
        get
        {
            return instance;
        }
    }

    static ZombieFSMTrace() { }
    private ZombieFSMTrace() { }

    public override void EnterState(Zombie owner)
    {
        Debug.Log("Enter");
        owner.anim.Play("Walk");
    }

    public override void UpdateState(Zombie owner)
    {
        Debug.Log("Enter");
        Debug.Log(Camera.main.transform.position);
        owner.m_navMeshAgent.SetDestination(Camera.main.transform.position);

        if(Vector3.Distance(owner.transform.position,Camera.main.transform.position) < 10f)
        {
            owner.ChangeState(ZombieFSMAttack.Instance);
        }
    }

    public override void ExitState(Zombie owner)
    {

    }
}
