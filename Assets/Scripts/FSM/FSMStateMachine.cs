using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dongkey
{

    public class FSMStateMachine<T> {

        private T _Owner;
        private FSMState<T> _CurrentState;
        private FSMState<T> _PreviousState;

        //초기 설정 & 초기화
        public void InitialSetting(T owner,FSMState<T> _InitialState)
        {
            Init();
            _Owner = owner;
            ChangeState(_InitialState);
        }

        //초기화
        public void Init()
        {
            _CurrentState = null;
            _PreviousState = null;
        }
    
        public void ChangeState(FSMState<T> newState)
        {
            //같은 상태일시 리턴
            if(newState == _CurrentState)
            {
                return;
            }

            _PreviousState = _CurrentState;

            //현재 상태 존재시 상태빠져나오기
            if(_CurrentState != null)
            {
                _CurrentState.ExitState(_Owner);
            }

            _CurrentState = newState;

            if(_CurrentState != null)
            {
                _CurrentState.EnterState(_Owner);
            }
        }

        public void Update()
        {
            if(_CurrentState != null)
            {
                _CurrentState.UpdateState(_Owner);
            }
        }

        public void StateRevert()
        {
            if(_PreviousState != null)
            {
                ChangeState(_PreviousState);
            }
        }
    }
}
