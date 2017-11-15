using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Paradox
{
	public class ScreenOverayTime : MonoBehaviour
	{
		public event Action OnRunAllTime;

		[SerializeField]
		private Text _OverayTimeText;
		[SerializeField]
		private float _LimitTime = 300f;

		private int m_NowMinute = 0;
		private int m_NowSecond = 0;

		public bool countOn = false;

		// Use this for initialization
		void Start()
		{
		}

		// Update is called once per frame
		void Update()
		{
			if ( countOn == false )
				return;
			if ( _LimitTime <= 0 )
				return;

			_LimitTime -= Time.deltaTime;
			if ( _LimitTime <= 0 )
			{
				_LimitTime = 0;
				if ( OnRunAllTime != null )
					OnRunAllTime();
			}

			ConvertSecondToMinute();
			ShowTimeText();
		}

		private void ShowTimeText()
		{
			_OverayTimeText.text = string.Format( "{0}:{1}", m_NowMinute.ToString(), m_NowSecond.ToString( "D2" ) );
		}

		private void ConvertSecondToMinute()
		{
			int intTime = Convert.ToInt32( Math.Truncate( _LimitTime ) );
			m_NowSecond = intTime % 60;
			if ( m_NowSecond + 1 == 60 )
			{
				m_NowMinute = intTime / 60;
			}
		}
	}

}
