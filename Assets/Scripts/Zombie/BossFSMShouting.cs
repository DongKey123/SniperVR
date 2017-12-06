using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFSMShouting : Dongkey.FSMState<Boss>
{

    static readonly BossFSMShouting instance = new BossFSMShouting();

    public static BossFSMShouting Instance
    {
        get
        {
            return instance;
        }
    }

    static BossFSMShouting() { }
    private BossFSMShouting() { }

    float time = 0;

    public override void EnterState(Boss owner)
    {
        time = 0;
        owner.anim.SetBool("Shoutting",true);
    }

    public override void UpdateState(Boss owner)
    {
        time += Time.deltaTime;
        if(time >= 2.3f)
        {
            SummonMonster(owner);
            owner.ChangeState(BossFSMIdle.Instance);
        }
    }

    public override void ExitState(Boss owner)
    {

    }

    void SummonMonster(Boss owner)
    {
        GameObject obj1 = GameObject.Instantiate(owner.m_SummonPrefab, owner.m_SummonTR[0]);
        GameObject obj2 = GameObject.Instantiate(owner.m_SummonPrefab, owner.m_SummonTR[1]);
        obj1.GetComponent<Zombie>().m_Target = owner.m_target;
        obj2.GetComponent<Zombie>().m_Target = owner.m_target;
        owner.m_Summons.Add(obj1.GetComponent<Zombie>());
        owner.m_Summons.Add(obj2.GetComponent<Zombie>());
    }
}
