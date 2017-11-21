#define ParadoxWork
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Dongkey
{
	public class VRInput : MonoBehaviour
    {
        public event Action OnPress;
        public event Action OnDown;
        public event Action OnUp;
        public event Action OnClick;
        public event Action OnDoubleClick;

        [SerializeField]
        private float _DoubleClickTime = 0.3f;

        private float _LastUpTime;

#if ParadoxWork
		protected bool m_PressKey = false;
		protected bool m_KeyEventOn = false;
#endif

		// Use this for initialization
		void Start()
        {
            
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            CheckInput();
			ProcessInput();
		}

        protected virtual void CheckInput()
        {
#if ParadoxWork
			if ( OVRInput.GetDown( OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch ) || 
				OVRInput.GetDown( OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch ) ||
				Input.GetButtonDown("Fire1") )
			{
				m_PressKey = true;
				m_KeyEventOn = true;
			}
			if ( OVRInput.GetUp( OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch ) || 
				OVRInput.GetUp( OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch ) ||
				Input.GetButtonUp( "Fire1" ) )
			{
				m_PressKey = false;
				m_KeyEventOn = true;
			}
#else
			if ( OVRInput.GetDown( OVRInput.Button.PrimaryHandTrigger ) || OVRInput.GetDown( OVRInput.Button.SecondaryHandTrigger ) )
            {
                Debug.Log("Grab Down");

                if (OnDown != null)
                    OnDown();

            }

			if ( OVRInput.Get( OVRInput.Button.PrimaryHandTrigger ) || OVRInput.Get( OVRInput.Button.SecondaryHandTrigger ) )
			{
                Debug.Log("Grab Press");

                if (OnPress != null)
                    OnPress();
            }

			if ( OVRInput.GetUp( OVRInput.Button.PrimaryHandTrigger ) || OVRInput.GetUp( OVRInput.Button.SecondaryHandTrigger ) )
			{
                Debug.Log("Grab UP");

                if (OnUp != null)
                    OnUp();

                if (Time.time - _LastUpTime < _DoubleClickTime)
                {
                    // If anything has subscribed to OnDoubleClick call it.
                    if (OnDoubleClick != null)
                        OnDoubleClick();
                }
                else
                {
                    // If it's not a double click, it's a single click.
                    // If anything has subscribed to OnClick call it.
                    if (OnClick != null)
                        OnClick();
                }

                // Record the time when Fire1 is released.
                _LastUpTime = Time.time;
            }
#endif
		}

#if ParadoxWork
		private void ProcessInput()
		{
			if ( m_PressKey )
			{
				if ( m_KeyEventOn )
				{
					if ( OnDown != null )
						OnDown();
					m_KeyEventOn = false;
				}
				else
				{
					if ( OnPress != null )
						OnPress();
				}
			}
			else
			{
				if ( m_KeyEventOn )
				{
					if ( OnUp != null )
						OnUp();

					if ( Time.time - _LastUpTime < _DoubleClickTime )
					{
						// If anything has subscribed to OnDoubleClick call it.
						if ( OnDoubleClick != null )
							OnDoubleClick();
					}
					else
					{
						// If it's not a double click, it's a single click.
						// If anything has subscribed to OnClick call it.
						if ( OnClick != null )
							OnClick();
					}

					// Record the time when Fire1 is released.
					_LastUpTime = Time.time;
					m_KeyEventOn = false;
				}
			}
		}
#endif

		void OnDestroy()
        {
            OnDown = null;
            OnUp = null;
            OnPress = null;
            OnClick = null;
            OnDoubleClick = null;
        }
    }
}


