using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 화살 떨어트리기
   충돌 판정 추가히기
   DecreaseHP 메서드를 호출하는 처리 추가하기 */
public class ArrowController : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        // 프레임마다 등속으로 낙하시킨다.
        transform.Translate(0, -0.1f, 0);

        // 화면 밖으로 나오면 오브젝트를 소멸시킨다.
        if (transform.position.y < -5.0f) {
            Destroy(gameObject);
        }

        // 충돌 판정 (추가)
        Vector2 p1 = transform.position; // 화살 중심 좌표
        Vector2 p2 = this.player.transform.position; // 플레이어 중심 좌표
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f; // 화살 반경
        float r2 = 1.0f; // 플레이어 반경

        if (d < r1 + r2) {
            // 감독 스크립트에 플레이어와 화살이 충돌했다고 전달한다.
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHP();

            // 효과음을 재생한다.
            GetComponent<AudioSource>().Play();

            // 충돌한 경우는 화살을 지운다.
            Destroy(gameObject);
        }
    }
}
