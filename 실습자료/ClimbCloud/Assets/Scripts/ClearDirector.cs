using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// LoadScene() 메서드를 사용해야 하므로 SceneManagement 패키지를 임포트
using UnityEngine.SceneManagement; // 씬 전환 시 반드시 포함. 

/*  씬 전환시키기 */
public class ClearDirector : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            // 마우스가 클릭된 것을 감지했으면 SceneManager 클래스의 LoadScene() 메서드를 사용해 GameScene으로 전환
            // LoadScene은 매개변수로 받은 씬 이름의 씬을 로드하는 메서드
            SceneManager.LoadScene("GameScene");
        }
    }
}
