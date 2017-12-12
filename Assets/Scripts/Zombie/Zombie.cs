using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Dongkey;
using System;

public class Zombie : HitObject
{
	public event Action OnDown;
    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    FSMStateMachine<Zombie> m_stateMachine;
    [HideInInspector]
    public NavMeshAgent m_navMeshAgent;
    [SerializeField]
    public Transform m_Target;

	[SerializeField]
	private ImpactBlood _bloodFX;
	[SerializeField]
	private SoundAppear _soundAppear;
	[SerializeField]
	private float _minGlowlTime = 3f;
	[SerializeField]
	private float _maxGlowlTime = 5f;
	[SerializeField]
	private Transform _leftFoot;
	[SerializeField]
	private Transform _rightFoot;

	int m_CurHp;
    public int m_MaxHp = 1;

	Vector3 m_RaycastHitPoint;


	// Use this for initialization
	void Start ()
	{
		if ( _bloodFX == null )
		{
			GameObject loadFrefab = Resources.Load( "FX/ImpactBlood" ) as GameObject;
			GameObject obj = Instantiate( loadFrefab );
			obj.transform.SetParent( transform );
			obj.transform.localPosition = Vector3.zero;
			_bloodFX = obj.GetComponent<ImpactBlood>();
		}
		
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

    public override void Hit(Vector3 hitPoint, float distance)
    {
        base.Hit(hitPoint, distance);

        if (m_CurHp <= 0)
            return;

        m_CurHp--;

		if ( _bloodFX != null )
		{
			_bloodFX.transform.position = hitPoint;
			_bloodFX.Play();
		}

		if (m_CurHp <= 0)
        {
			if ( OnDown != null )
				OnDown();
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

	public void EnterStateMacineChanged( FSMState<Zombie> eventState )
	{
		StopCoroutine( "GlowlTrace" );
		if ( eventState == ZombieFSMAttack.Instance )
		{
			_soundAppear.Play(SoundAppear.SoundType.ATTACK);
			KillHero();
		}
		else if ( eventState == ZombieFSMDeath.Instance)
		{
			_soundAppear.Play( SoundAppear.SoundType.DEATH );
			Destroy( gameObject, 2f );
		}
		else if ( eventState == ZombieFSMTrace.Instance )
		{
			StartCoroutine( "GlowlTrace" );
		}
	}

	public void KillHero()
	{
		m_Target.GetComponent<Hero>().Death();
	}

	IEnumerator GlowlTrace()
	{
		while ( true )
		{
			yield return new WaitForSeconds( UnityEngine.Random.Range(_minGlowlTime, _maxGlowlTime));
			_soundAppear.Play(SoundAppear.SoundType.IDLE);
		}
	}

	//외부 애니메이션에서 이벤트로 호출.
	//왼발 : 0 오른발 : 1
	void FootStep( int footType )
	{
		Vector3 footPos = Vector3.zero; ;
		switch ( footType )
		{
			case 0:
				footPos = _leftFoot.transform.position;
				break;
			case 1:
				footPos = _rightFoot.transform.position;
				break;
			default:
				return;
		}

		FootStepManager.Instance.PlayParticle( footPos, footType );
	}
}
