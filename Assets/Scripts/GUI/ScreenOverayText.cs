using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Paradox
{
	//csv 를 index 방식이 아닌 등록된 텍스트 방식으로 로드하는 것으로 변경 해야한다. 
	public class ScreenOverayText : MonoBehaviour
	{
		public event Action PageDown;
		public event Action TextDone;

		private List<Dictionary<string, object>> m_LoadTextMessage;
		private int m_CurrentIndex;

		[SerializeField]
		private Dongkey.VRInput _Controller;

		[SerializeField]
		private Text _ScreenText;

		[SerializeField]
		private float _SkipNextPageTime = 30f;
		private float m_NowTime = 0;
			 
		public bool _Lock = false;

		void OnEnable()
		{
			if(_Controller)
				_Controller.OnDown += NextText;
		}

		void OnDisable()
		{
			if ( _Controller )
				_Controller.OnDown -= NextText;
		}

		// Use this for initialization
		void Start()
		{
			m_NowTime = _SkipNextPageTime;
		}

		// Update is called once per frame
		void Update()
		{
			CheckAutoNextText();
		}

		public int GetCurrentScriptIndex()
		{
			return m_CurrentIndex;
		}

		public int GetMaxScript()
		{
			if ( m_LoadTextMessage == null )
				return -1;
			return m_LoadTextMessage.Count;
		}

		public void LoadScript(string csvFilePath)
		{
			m_LoadTextMessage = CSVReader.Read( csvFilePath );

			m_CurrentIndex = 0;
			_ScreenText.text = m_LoadTextMessage[m_CurrentIndex]["Text"].ToString();
		}

		private void NextText()
		{
			NextTextFromAcessText();
		}

		public void NextTextFromAcessText( bool beForced = false)
		{
			if (!beForced && _Lock )
				return;
			if ( m_CurrentIndex >= m_LoadTextMessage.Count )
				return;

			m_NowTime = _SkipNextPageTime;
			m_CurrentIndex++;

			if ( PageDown != null )
				PageDown();

			if ( m_CurrentIndex >= m_LoadTextMessage.Count )
			{
				if ( TextDone != null )
					TextDone();
				return;
			}
			_ScreenText.text = m_LoadTextMessage[m_CurrentIndex]["Text"].ToString();
		}

		private void CheckAutoNextText()
		{
			if ( _Lock == true )
				return;

			if ( m_NowTime < 0 )
				return;

			m_NowTime -= Time.deltaTime;

			if ( m_NowTime < 0 )
				NextText();


		}
	} 
}
