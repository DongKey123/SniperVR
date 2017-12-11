    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFSMLanding : Dongkey.FSMState<Boss>
{

    static readonly BossFSMLanding instance = new BossFSMLanding();

    public static BossFSMLanding Instance
    {
        get
        {
            return instance;
        }
    }

    static BossFSMLanding() { }
    private BossFSMLanding() { }

    float maxSpeed = 3.5f;
    float time = 0f;

    public override void EnterState(Boss owner)
    {
        time = 0f;
		owner.EnterStateMacineChanged( this );
	}

    public override void UpdateState(Boss owner)
    {
        if(owner.transform.position.y < 3.0f)
        {
            owner.anim.Play("Landing");
            time += Time.deltaTime;
            GameObject.Destroy(owner.GetComponent<Rigidbody>());
        }

        if(time > 1f)
        {
            owner.ChangeState(BossFSMShouting.Instance);
        }
    }

    public override void ExitState(Boss owner)
    {

    }
}
