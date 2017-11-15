using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paradox
{
	//홈 작업을 위한 디버그 컨트롤러
	public class DebugController : Dongkey.VRInput
	{
		[SerializeField]
		private Transform _RotateTarget;
		[SerializeField]
		private float _RotateSpeed = 20f;

		// Update is called once per frame
		protected override void Update()
		{
			base.Update();
			if ( Input.GetKeyDown( KeyCode.P ) )
			{
				Debug.Break();
			}

			if ( Input.GetKey( KeyCode.A ) )
			{
				_RotateTarget.Rotate( Vector3.up * Time.deltaTime * _RotateSpeed * -1 );
			}
			if ( Input.GetKey( KeyCode.D ) )
			{
				_RotateTarget.Rotate( Vector3.up * Time.deltaTime * _RotateSpeed );
			}
			if ( Input.GetKey( KeyCode.W ) )
			{
				_RotateTarget.Rotate( Vector3.right * Time.deltaTime * _RotateSpeed );
			}
			if ( Input.GetKey( KeyCode.S ) )
			{
				_RotateTarget.Rotate( Vector3.right * Time.deltaTime * _RotateSpeed * -1 );
			}

			if ( Input.GetKey( KeyCode.Keypad4 ) )
			{
				_RotateTarget.Translate( Vector3.right * Time.deltaTime * _RotateSpeed * -1 );
			}
			if ( Input.GetKey( KeyCode.Keypad6 ) )
			{
				_RotateTarget.Translate( Vector3.right * Time.deltaTime * _RotateSpeed);
			}
			if ( Input.GetKey( KeyCode.Keypad8 ) )
			{
				_RotateTarget.Translate( Vector3.up * Time.deltaTime * _RotateSpeed );
			}
			if ( Input.GetKey( KeyCode.Keypad5 ) )
			{
				_RotateTarget.Translate( Vector3.up * Time.deltaTime * _RotateSpeed * -1);
			}
		}
	}
}
