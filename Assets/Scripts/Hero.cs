using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {

	[SerializeField]
	GameObject _sniperRifle;

	[SerializeField]
	BloodSplatRender _bloodRenderer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    

	public void Death()
	{
		Debug.Log("Call");
        Invoke("DeathDelay", 0.3f);
		//_sniperRifle.SetActive( false );
		//_bloodRenderer.Play();
	}

    void DeathDelay()
    {
        _sniperRifle.SetActive(false);
        _bloodRenderer.Play();
    }
}
