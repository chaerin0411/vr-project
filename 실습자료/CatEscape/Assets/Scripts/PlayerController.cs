using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 키를 조작해 플레이어 움직이기
   버튼을 누르면 움직이도록 추가하기 */
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UButtonDown()
    {
        transform.Translate(0, 3, 0); // 위쪽으로 [3] 움직인다.
    }

    public void DButtonDown()
    {
        transform.Translate(0, -3, 0); // 아래쪽으로 [3] 움직인다.
    }
    
    public void LButtonDown()
    {
        transform.Translate(-3, 0, 0); // 왼쪽으로 [3] 움직인다.
    }

    public void RButtonDown()
    {
        transform.Translate(3, 0, 0); // 오른쪽으로 [3] 움직인다.
    }

    // Update is called once per frame
    void Update()
    {
        // 위쪽 화살표가 눌렸을 때
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            transform.Translate(0, 3, 0); // 위쪽으로 [3] 움직인다.
        }

        // 아래쪽 화살표가 눌렸을 때
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            transform.Translate(0, -3, 0); // 아래쪽으로 [3] 움직인다.
        }

        // 왼쪽 화살표가 눌렸을 때
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.Translate(-3, 0, 0); // 왼쪽으로 [3] 움직인다.
        }

        // 오른쪽 화살표가 눌렸을 때
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.Translate(3, 0, 0); // 오른쪽으로 [3] 움직인다.
        }
    }
}
