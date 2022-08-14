using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector3 startPos = new Vector3(0, 0, 0); // 기준점(0, 0, 0)
    Vector3 target = new Vector3(1, 1, 1); // 목표위치(1, 1, 1)

    // Start is called before the first frame update
    void Start()
    {
        // 1. MoveTowards : 등속 이동
        // 매개변수는 (현재위치, 목표위치, 속도)로 구성
        // 마지막 매개변수에 비례하여 속도 증가
        // Ball 오브젝트의 위치를 (1, 1, 1)로 위치 이동한다.
        transform.position = Vector3.MoveTowards(transform.position, target, 1f);  
        MoveBall("Ball"); // MoveBall 메소드를 호출한다.
    }

    // Update is called once per frame
    async void Update()
    {
        // Time.deltaTime : 이전 프레임의 완료까지 걸린 시간
        // deltaTime 값은 프레임이 적으면 크고, 프레임이 많으면 작음
        // 1) Translate : 백터에 곱하기
        //  transform.Translate(vec * Time.deltaTime);
        // 2) Vector 함수 : 시간 매개변수에 곱하기
        //  Vector3.Lerp(Vec1, Vec2, T * Time.deltaTime);
        Vector3 vec = new Vector3(
            Input.GetAxisRaw("Horizontal") * Time.deltaTime,
            Input.GetAxisRaw("Vertical") * Time.deltaTime);
        transform.Translate(vec);   

        target.x += 0.1f; // x 좌표를 매 프레임마다 0.1f 씩 옮겨간다. 
        // MoveTowards : 등속 이동
        // 매개변수는 (현재위치, 목표위치, 속도)로 구성
        // 마지막 매개변수에 비례하여 속도 증가
        transform.position = Vector3.MoveTowards(transform.position, target, 1f);                          
        MoveBall("Ball"); // MoveBall 메소드를 호출한다.
    }

    // MoveBall 메소드
    void MoveBall(string name)
    {
        // 기준점(0, 0, 0)에서 현재 "Ball"까지의 거리를 측정한다.
        float distance = Vector3.Distance(startPos, GameObject.Find(name).transform.position);
        Debug.Log("현재 Ball까지의 거리: " + distance); // 측정된 거리를 출력한다.
    }
}
