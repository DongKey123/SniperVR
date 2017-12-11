using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paradox
{
	public class VRControllerInput : Dongkey.VRInput
	{
		enum ControllerType : int
		{
			LEFT,
			RIGHT
		}

		[SerializeField]
		private ControllerType _contollerInput;
		
		protected override void CheckInput()
		{
			if ( _contollerInput == ControllerType.LEFT )
			{
				if ( OVRInput.GetDown( OVRInput.Button.PrimaryIndexTrigger , OVRInput.Controller.LTouch))
				{
					m_PressKey = true;
					m_KeyEventOn = true;
				}
				if ( OVRInput.GetUp( OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch ) )
				{
					m_PressKey = false;
					m_KeyEventOn = true;
				}
			}
			else
			{
				if ( OVRInput.GetDown( OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch ) )
				{
					m_PressKey = true;
					m_KeyEventOn = true;
				}
				if ( OVRInput.GetUp( OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch ) )
				{
					m_PressKey = false;
					m_KeyEventOn = true;
				}
			}
		}
	}
}
