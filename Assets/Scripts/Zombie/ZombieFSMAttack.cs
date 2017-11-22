using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFSMAttack : Dongkey.FSMState<Zombie> {

    static readonly ZombieFSMAttack instance = new ZombieFSMAttack();

    public static ZombieFSMAttack Instance
    {
        get
        {
            return instance;
        }
    }

    static ZombieFSMAttack() { }
    private ZombieFSMAttack() { }

    public override void EnterState(Zombie owner)
    {
        owner.anim.Play("Atack (1)");
    }

    public override void UpdateState(Zombie owner)
    {

    }

    public override void ExitState(Zombie owner)
    {

    }
}
