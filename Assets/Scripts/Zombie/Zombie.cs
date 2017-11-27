using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Dongkey;

public class Zombie : HitObject {
    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    FSMStateMachine<Zombie> m_stateMachine;
    [HideInInspector]
    public NavMeshAgent m_navMeshAgent;
    [SerializeField]
    public Transform m_Target;

    int m_CurHp;
    public int m_MaxHp = 1;

	// Use this for initialization
	void Start () {
        m_CurHp = m_MaxHp;
        m_navMeshAgent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        m_stateMachine = new FSMStateMachine<Zombie>();
        m_stateMachine.InitialSetting(this, ZombieFSMTrace.Instance);
    }

	void OnDestroy()
	{
		m_stateMachine = null;
	}

	// Update is called once per frame
	void Update () {
        //m_navMeshAgent.SetDestination(m_Target.position);
        m_stateMachine.Update();
	}

    public override void Hit(float distance)
    {
        base.Hit(distance);
        m_CurHp--;

		if (m_CurHp <= 0)
        {
            m_stateMachine.ChangeState(ZombieFSMDeath.Instance);
        }
        else
        {
            m_stateMachine.ChangeState(ZombieFSMHit.Instance);
        }
    }

    public void ChangeState(FSMState<Zombie> state)
    {
        m_stateMachine.ChangeState(state);
    }

	public void KillHero()
	{
		m_Target.GetComponent<Hero>().Death();
	}
}
