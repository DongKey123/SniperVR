﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dongkey;
using UnityEngine.AI;

public class Boss : MonoBehaviour {

    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    public FSMStateMachine<Boss> m_stateMachine;
    [HideInInspector]
    public NavMeshAgent m_navMeshAgent;

    [SerializeField]
    public Transform m_target;
    [SerializeField]
    private ImpactBlood _bloodFX;

    public GameObject m_SummonPrefab;
    public Transform[] m_SummonTR;

    public List<Zombie> m_Summons;

    int m_CurHp;
    public int m_MaxHP = 5;

	// Use this for initialization
	void Start () {
        if (_bloodFX == null)
        {
            GameObject loadFrefab = Resources.Load("FX/ImpactBlood") as GameObject;
            GameObject obj = Instantiate(loadFrefab);
            obj.transform.SetParent(transform);
            obj.transform.localPosition = Vector3.zero;
            _bloodFX = obj.GetComponent<ImpactBlood>();
        }

        m_CurHp = m_MaxHP;
        m_navMeshAgent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        m_stateMachine = new FSMStateMachine<Boss>();
        m_stateMachine.InitialSetting(this, BossFSMLanding.Instance);
    }
	
	// Update is called once per frame
	void Update () {
        m_stateMachine.Update();
	}

    private void OnDestroy()
    {
        m_stateMachine = null;
    }

    public void Hit()
    {
        if (m_CurHp <= 0)
            return;

        m_CurHp--;

        if(m_CurHp <= 0)
        {
            ChangeState(BossFSMDeath.Instance);
        }
        else
        {
            ChangeState(BossFSMHit.Instance);
        }
    }

    public void ChangeState(FSMState<Boss> state)
    {
        m_stateMachine.ChangeState(state);
    }

    public void AllKillSummons()
    {
        foreach(Zombie monster in m_Summons)
        {
            monster.ChangeState(ZombieFSMDeath.Instance);
        }
    }
}
