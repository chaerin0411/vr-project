using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
/*
    float yNewPositions = 0.0f;
    float xNewPositions = 0.0f;
*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 상하좌우로 움직이는 "CubeController" 스크립트

        // 벡터 : 방향과 그에 대한 크기 값
        // GetAxis : 수평, 수직 버튼 입력을 받으면 float
        Vector3 vec = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        // Transform : 오브젝트 형태에 대한 기본 컴포넌트
        // 오브젝트는 변수 transform을 항상 가지고 있음
        // Translate : 벡터 값을 현재 위치에 더하는 함수
        transform.Translate(vec);

        if (Input.GetButton("Horizontal"))
            Debug.Log("횡 이동 중..." + Input.GetAxis("Horizontal"));
        else if (Input.GetButton("Vertical"))
            Debug.Log("종 이동 중..." + Input.GetAxis("Vertical"));



        /*
                // 1. Translate 활용
                // 왼쪽 화살표 키를 누르면, 큐브가 왼쪽으로 이동
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Translate(new Vector3(-0.1f, transform.position.y, transform.position.z));
                }
                // 오른쪽 화살표 키를 누르면, 큐브가 오른쪽으로 이동
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.Translate(new Vector3(0.1f, transform.position.y, transform.position.z));
                }
                // 아래쪽 화살표 키를 누르면, 큐브가 위쪽으로 이동
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.Translate(new Vector3(transform.position.x, -0.1f, transform.position.z));
                }
                // 위쪽 화살표 키를 누르면, 큐브가 아래쪽으로 이동
                else if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.Translate(new Vector3(transform.position.x, 0.1f, transform.position.z));
                }


                // 2. position 활용
                // 왼쪽 화살표 키를 누르면, 큐브가 왼쪽으로 이동
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    xNewPositions -= 0.1f;
                    transform.position = new Vector3(transform.position.x, xNewPositions, transform.position.z);
                }
                // 오른쪽 화살표 키를 누르면, 큐브가 오른쪽으로 이동
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    xNewPositions += 0.1f;
                    transform.position = new Vector3(transform.position.x, xNewPositions, transform.position.z);
                }
                // 위쪽 화살표 키를 누르면, 큐브가 위쪽으로 이동
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    yNewPositions += 0.1f;
                    transform.position = new Vector3(transform.position.x, yNewPositions, transform.position.z);
                }
                // 아래쪽 화살표 키를 누르면, 큐브가 아래쪽으로 이동
                else if (Input.GetKey(KeyCode.UpArrow))
                {
                    yNewPositions -= 0.1f;
                    transform.position = new Vector3(transform.position.x, yNewPositions, transform.position.z);
                }
        */
    }
}
