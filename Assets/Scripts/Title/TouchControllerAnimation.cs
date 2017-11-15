using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControllerAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {

		_activeModel = false;

		_button1OffYPos = _button1.localPosition.y;
		_button2OffYPos = _button2.localPosition.y;
		_button3OffYPos = _button3.localPosition.y;

		_primaryOffRotDegree = _primary.localEulerAngles.x;
		_primaryOffPos = _primary.localPosition;

		_handOffPos = _hand.localPosition;

		StartCoroutine( "ControllerOnCheck" );
	}
	
	// Update is called once per frame
	void Update ()
	{
		AnimateButtons();
		AnimatePrimary();
		AnimateHand();
		AnimateTumbstick();
	}

	IEnumerator ControllerOnCheck()
	{
		while ( true )
		{
			if ( OVRInput.IsControllerConnected( _activeContoller ) )
			{
				break;
			}
			yield return new WaitForEndOfFrame();
		}
		
		for ( int i = 0; i < transform.childCount; i++ )
		{
			transform.GetChild( i ).gameObject.SetActive(true);
		}
		_activeModel = true;
	}

	void AnimateButtons()
	{
		Vector3 pos; 
		if ( OVRInput.Get( OVRInput.Button.One, _activeContoller ) )
		{
			pos = _button1.localPosition;
			_button1.localPosition = new Vector3( pos.x, _button1PushYPos, pos.z);
		}
		else
		{
			pos = _button1.localPosition;
			_button1.localPosition = new Vector3( pos.x, _button1OffYPos, pos.z );
		}

		if ( OVRInput.Get( OVRInput.Button.Two, _activeContoller ) )
		{
			pos = _button2.localPosition;
			_button2.localPosition = new Vector3( pos.x, _button2PushYPos, pos.z );
		}
		else
		{
			pos = _button2.localPosition;
			_button2.localPosition = new Vector3( pos.x, _button2OffYPos, pos.z );
		}

		if ( OVRInput.Get( OVRInput.Button.Start, _activeContoller ) )
		{
			pos = _button3.localPosition;
			_button3.localPosition = new Vector3( pos.x, _button3PushYPos, pos.z );
		}
		else
		{
			pos = _button3.localPosition;
			_button3.localPosition = new Vector3( pos.x, _button3OffYPos, pos.z );
		}
	}

	void AnimatePrimary()
	{
		if ( OVRInput.Get( OVRInput.Button.PrimaryIndexTrigger, _activeContoller ) )
		{
			_primary.localEulerAngles = new Vector3( _primaryRotDegree, _primary.localEulerAngles.y, _primary.localEulerAngles.z );
			_primary.localPosition = _primaryPushPos;
		}
		else
		{
			_primary.localEulerAngles = new Vector3( _primaryOffRotDegree, _primary.localEulerAngles.y, _primary.localEulerAngles.z );
			_primary.localPosition = _primaryOffPos;
		}
	}

	void AnimateHand()
	{
		if ( OVRInput.Get( OVRInput.Button.PrimaryHandTrigger, _activeContoller ) )
		{
			_hand.localPosition = _handPushPos;
		}
		else
		{
			_hand.localPosition = _handOffPos;
		}
	}

	void AnimateTumbstick()
	{
		Vector3 axis = OVRInput.Get( OVRInput.Axis2D.PrimaryThumbstick, _activeContoller );

		axis *= _stickRotDegree;

		axis.z = axis.x * -1;
		axis.x = axis.y;
		axis.y = 0;

		_stick.localEulerAngles = axis;
	}
	
	public OVRInput.Controller _activeContoller;

	public Transform _button1;
	public float _button1PushYPos;
	float _button1OffYPos;

	public Transform _button2;
	public float _button2PushYPos;
	float _button2OffYPos;

	public Transform _button3;
	public float _button3PushYPos;
	float _button3OffYPos;

	public Transform _primary;
	public float _primaryRotDegree;
	public Vector3 _primaryPushPos;
	float _primaryOffRotDegree;
	Vector3 _primaryOffPos;

	public Transform _hand;
	public Vector3 _handPushPos;
	Vector3 _handOffPos;

	public Transform _stick;
	public float _stickRotDegree;

	bool _activeModel;
}
