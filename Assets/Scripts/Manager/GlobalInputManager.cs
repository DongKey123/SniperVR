using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VR;

/**
* 
*  @brief 전역적으로 인풋을 받아서 처리해야할 경우 이용하는 싱글톤. 
*  @author kjban
*  @date 2017.10.11
*  @version 1.0
*  
*/
public class GlobalInputManager : Singleton<GlobalInputManager>
{	
	// Update is called once per frame
	void Update ()
    {
	    if (OVRInput.GetDown(OVRInput.RawButton.Y) // Y 버튼 다운.
            || Input.GetKeyDown(KeyCode.Escape) // 키보드 ESC 버튼 다운
            )
        {   // 타이틀 씬으로 돌아가기
            if (SceneManager.GetActiveScene().name.Equals("Title"))
            {   // 타이틀 씬일 경우 그냥 리턴
                return;
            }
			
			if (Application.HasProLicense())
            {
				SceneManager.LoadSceneAsync("Title");
            }
            else
            {
                SceneManager.LoadScene("Title");
            }
        }

        /// 키보드의 스페이스 키를 누르거나 컨트롤러의 X버튼을 눌렀을때
        /// 씬 전체를 해드마운트를 기준으로 재정렬한다.
        if (Input.GetKeyDown(KeyCode.Space)
            || OVRInput.GetDown(OVRInput.RawButton.X))
        {
            InputTracking.Recenter();
        }
    }

    public void Initialized()
    {
    }
}
