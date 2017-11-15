using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleVRObject : MonoBehaviour
{
	// Use this for initialization
	void Start () {
		_handArray = new bool[2];
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ( _handArray[0] )
		{
			if ( OVRInput.GetDown( OVRInput.Button.PrimaryIndexTrigger , OVRInput.Controller.LTouch) )
			{
				GetComponent<VRInteraction>().InteractionForHand( OVRInput.Controller.LTouch );
			}
		}
		else if(_handArray[1])
		{
			if ( OVRInput.GetDown( OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch ) )
			{
				GetComponent<VRInteraction>().InteractionForHand( OVRInput.Controller.RTouch );
			}
		}
	}

	private void OnTriggerEnter( Collider other )
	{
		if ( other.tag != "GameController" )
			return;

		if ( other.GetComponent<TouchControllerAnimation>()._activeContoller == OVRInput.Controller.LTouch )
		{
			_handArray[0] = true;
		}
		else
		{
			_handArray[1] = true;
		}

		GetComponent<VRInteraction>().ControllerIn( other.GetComponent<TouchControllerAnimation>()._activeContoller );
	}

	private void OnTriggerExit( Collider other )
	{
		if ( other.tag != "GameController" )
			return;

		if ( other.GetComponent<TouchControllerAnimation>()._activeContoller == OVRInput.Controller.LTouch )
		{
			_handArray[0] = false;
		}
		else
		{
			_handArray[1] = false;
		}

		GetComponent<VRInteraction>().ContollerOut( other.GetComponent<TouchControllerAnimation>()._activeContoller );
	}

	public bool[] _handArray;
}
