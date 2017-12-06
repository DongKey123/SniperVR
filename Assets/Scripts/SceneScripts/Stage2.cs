using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2 : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
		_GUIText._Lock = true;
		_GUIText.LoadScript( "Texts/Stage2" );
		
		_maxMonsterAmount = _MonsterHaveTransform.childCount;
		_killMonsterAmount = 0;
		for ( int i = 0; i < _maxMonsterAmount; i++ )
		{
			_MonsterHaveTransform.GetChild( i ).GetComponent<Zombie>().OnDown += AddKillMonsterAmount;
		}

		StartCoroutine( "Game" );
	}

	IEnumerator Game()
	{
		while ( _GUIFrontScreen.IsFading )
		{
			yield return new WaitForEndOfFrame();
		}

		_GUIText.PageDown += CheckGameStart;
		_GUIText._Lock = false;
		_GUIText.gameObject.SetActive( true );

		while ( !_isStartShotRiffle )
		{
			yield return new WaitForEndOfFrame();
		}

		_SniperRifle.SetActive( true );

		for ( int i = 0; i < _maxMonsterAmount; i++ )
		{
			_MonsterHaveTransform.GetChild( i ).gameObject.SetActive(true);
		}

		while ( _killMonsterAmount < _maxMonsterAmount )
			yield return new WaitForEndOfFrame();

		_GUIText.PageDown += CheckBossStart;
		_GUIText._Lock = false;
		_GUIText.gameObject.SetActive( true );

		while ( !_isEnterBossRound )
			yield return new WaitForEndOfFrame();

		//boss
		_Boss.gameObject.SetActive( true );
		_Boss.OnDead += BossClear;
		//
		while ( !_isClearBoss )
			yield return new WaitForEndOfFrame();

		_GUIText._Lock = false;
		_GUIText.TextDone += GoNextLevel;
		_GUIText.gameObject.SetActive( true );
	}
	
	void AddKillMonsterAmount()
	{
		_killMonsterAmount++;
	}

	void CheckGameStart()
	{
		if ( _GUIText.GetCurrentScriptIndex() >= 5 )
		{
			_GUIText.PageDown -= CheckGameStart;
			_GUIText._Lock = true;
			_GUIText.gameObject.SetActive( false );
			_isStartShotRiffle = true;
		}
	}

	void CheckBossStart()
	{
		if ( _GUIText.GetCurrentScriptIndex() >= 7 )
		{
			_GUIText.PageDown -= CheckBossStart;
			_GUIText._Lock = true;
			_GUIText.gameObject.SetActive( false );
			_isEnterBossRound = true;
		}
	}

	void BossClear()
	{
		//보스의 개 초기화. 
		_Boss.AllKillSummons();
		_isClearBoss = true;
	}

	void GoNextLevel()
	{
		Debug.Log("good");
	}

	public Dongkey.CameraFade _GUIFrontScreen;
	public Paradox.ScreenOverayText _GUIText;

	public GameObject _SniperRifle;

	[SerializeField]
	private Transform _MonsterHaveTransform;

	[SerializeField]
	private Boss _Boss;

	bool _isStartShotRiffle = false;
	bool _isEnterBossRound = false;

	bool _isClearBoss = false;
	
	int _maxMonsterAmount;
	int _killMonsterAmount;
}
