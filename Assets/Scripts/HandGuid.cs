using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paradox
{
	public class HandGuid : MonoBehaviour
	{
		public event Action OnCollideEnter;

		[SerializeField]
		private HandAnimator _HandGuidAnimator;
		[SerializeField]
		private Transform _EyeTrackedCamera;

		private Transform m_HandGuidTransform;

		void Awake()
		{
			m_HandGuidTransform = transform;
			
		}
		void Update()
		{
			m_HandGuidTransform.position = _EyeTrackedCamera.transform.position;
		}

		private void OnTriggerEnter( Collider other )
		{
			if ( OnCollideEnter != null )
				OnCollideEnter();
		}

		public void DoGrabAnimation()
		{
			StartCoroutine( "GrabAnimationForever" );
		}

		public void StopGrabAnimation()
		{
			StopAllCoroutines();
			_HandGuidAnimator.Put();
			//_HandGuidAnimator.SetBool( "Grab", false );
		}

		IEnumerator GrabAnimationForever()
		{
			while ( true )
			{
				yield return new WaitForSeconds( 0.5f );
				_HandGuidAnimator.Grab( InteractiveModelData.InteractiveObjectType.NONE );
				yield return new WaitForSeconds( 0.5f );
				_HandGuidAnimator.Put();
			}
		}
	}
}
