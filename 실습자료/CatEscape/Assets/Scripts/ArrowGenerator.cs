using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 화살을 생성하는 제너레이터 스크립트 */
public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    float span = 1.0f;
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update 메서드는 프레임마다 실행
        // 앞 프레임과 현재 프레임 사이의 시간 차이는 Time.deltaTime에 대입
        this.delta += Time.deltaTime;
        if (this.delta > this.span) {
            this.delta = 0;
            // Instantiate 메서드는 매개변수로 프리팹을 전달하면 반환값으로 프리팹 인스턴스를 돌려줌
            // Instantiate 메서드는 가장 기본적인 ‘Object형’을 반환
            // 캐스트라는 강제 형 변환을 사용해 Object형을 GameObject형으로 바꿀 수 있음
            GameObject go = Instantiate(arrowPrefab) as GameObject;
            // 화살의 X 좌표는 -6부터 6 사이에 불규칙하게 위치하도록 Random 클래스의 Range 메서드 사용
            // Range 메서드는 첫 번째 매개변수보다 크고 두 번째 매개변수보다 작은 범위에서 무작위 수를 정수로 반환
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);
        }
    }
}
