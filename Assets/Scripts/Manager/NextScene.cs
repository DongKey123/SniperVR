using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string nextSceneName;
    public float delayTime;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(MoveScene());
	}

    IEnumerator MoveScene()
    {
        yield return new WaitForSeconds(delayTime);

        SceneManager.LoadScene(nextSceneName);
    }
		
}
