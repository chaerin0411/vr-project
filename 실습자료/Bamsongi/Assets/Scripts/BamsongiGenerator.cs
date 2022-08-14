using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 밤송이를 생성하는 제너레이터 스크립트,
   탭한 곳으로 향하는 밤송이 날리기 */
public class BamsongiGenerator : MonoBehaviour
{
    // bamsongiPrefab 변수를 선언함
    // 단지 변수를 선언한 것이므로 뒤쪽에서 프리팹 실체를 대입해야 함
    // 아웃렛 접속을 사용해 대입할 수 있도록 public을 붙여 선언
    public GameObject bamsongiPrefab;

    void Update()
    {
        // GetMouseButtonDown(0)으로 화면이 클릭되었는지 확인
        if (Input.GetMouseButtonDown(0))
        {
            // Instantiate()로 bamsongi 인스턴스를 만듦
            GameObject bamsongi = Instantiate(bamsongiPrefab);

            // 밤송이 인스턴스를 날리는 방향을 지정
            // BamsongiController에 구현한 Shoot 메서드의 매개변수에 날리고자 하는 방향의 벡터를 전달
            // GetComponent 메서드를 사용해 BamsongiController 스크립트를 구함
            // Shoot 메서드의 매개변수에 화면 안쪽 방향으로 벡터를 지정

            // 탭한 곳을 향해 밤송이를 날리려면 탭한 좌표를 알아야 함
            // 탭한 좌표는 Input.mousePosition 메서드로 구할 수 있지만, 3D에서는 mousePosition 값을 그대로 사용할 수 없음
            // mousePosition 값이 월드 좌표계 값이 아닌 스크린 좌표계 값이기 때문
            // 월드 좌표계란 ‘게임 세계’에서 오브젝트가 어디에 있는지 나타내는 좌표계
            // 스크린 좌표계는 ‘게임 화면’의 좌표를 나타낼 때 사용하는 2D 좌표계
            // 월드 좌표계와 스크린 좌표계는 전혀 다른 척도(단위)를 사용
            // 월드 좌표계에서 고양이가 있는 좌표(2, 1, 2)와 스크린 좌표계에서 고양이가 있는 좌표(400, 150)는 전혀 관계가 없는 별개의 좌표
            // 지금까지 나온 ‘과녁’이나 ‘밤송이’ 좌표는 모두 월드 좌표계이므로 밤송이를 날리는 방향도 월드 좌표계로 계산해야 함
            // ScreenPointToRay() 메서드는 스크린 좌표를 전달하면 ‘카메라’에서 ‘스크린 좌표’로 향하는 월드 좌표계로 벡터를 구할 수 있음
            // 이 벡터를 사용해 밤송이를 탭한 방향으로 날림

            // ScreenPointToRay() 메서드에 탭 좌표를 전달
            // ScreenPointToRay() 메서드는 카메라에서 탭 좌표로 향하는 벡터에 따른 Ray(광선) 클래스를 반환
            // Ray 클래스를 간단히 설명하면 Ray(레이)는 이름 그대로 광선
            // 광원의 좌표(origin)와 광선의 방향(direction)을 멤버 변수로 갖음
            // Ray는 콜라이더가 적용된 오브젝트와 충돌을 감지하는 특징이 있음
            // 즉, 광선이 오브젝트로 가려지면 그것을 감지할 수 있음

            // ScreenPointToRay() 메서드의 반환값으로 얻을 수 있는 Ray는 origin이 Main Camera의 좌표
            // direction이 카메라에서 탭한 좌표로 향하는 벡터
            // 이 direction 방향으로 밤송이를 날리기 때문에 direction 벡터가 가진 normalized 변수를 사용해 길이가 1인 벡터로 만든 후 힘을 2000 곱함
            // 일단 길이를 1 벡터로 해서 direction 벡터크기에 관계없이 밤송이에 일정한 힘을 가할 수 있음
            // normalized은 10을 1로 압축
            // worldDir : (0, 5, 10)
            // worldDir.normalized : (0, 0.5, 1)
            // worldDir.normalized * 2000 : (0, 1000, 2000)
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;
            bamsongi.GetComponent<BamsongiController>().Shoot(worldDir.normalized * 2000);
        }
    }
}
