using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dongkey
{
    abstract public class FSMState <T>
    {

        abstract public void EnterState(T owner);

        abstract public void UpdateState(T owner);

        abstract public void ExitState(T owner);
    }
}
