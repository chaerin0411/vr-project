using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  밤송이를 날리는 스크립트, 
    밤송이를 과녁에 꽂기,
    과녁에 닿는 순간에 이펙트 발생시키기 */
public class BamsongiController : MonoBehaviour
{
    GameObject target;
    GameObject director;

    void Start()
    {
        this.target = GameObject.Find("target");
        this.director = GameObject.Find("GameDirector");
    }

    // 매개변수에서 지정한 방향으로 힘을 가할 수 있는 Shoot() 메서드
    // AddForce 메서드를 사용해 매개변수 방향으로 힘을 가하고 있음
    // 밤송이가 화면 안쪽으로 날아가도록 +Z축 방향의 벡터를 매개변수로 전달하고 Shoot 메서드를 호출
    // Y축 방향으로도 힘을 200 가하는 이유는 밤송이가 과녁에 닿기 전에 중력의 영향을 받아 지면으로 낙하하는 것을 막기 위해
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    // 충돌을 감지할 수 있는 OnCollisionEnter() 메서드
    // 밤송이가 과녁에 닿는 순간 밤송이 움직임이 멈추므로 이 메서드에서 Rigidbody 컴포넌트의 isKinematic을 true로 설정
    // isKinematic을 true로 하면 오브젝트에 작용하는 힘을 무시하고 밤송이를 정지
    void OnCollisionEnter(Collision other)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();

        // 밤송이와 과녁이 충돌했을 때
        if(other.gameObject == target) {
            // 감독 스크립트에 밤송이와 과녁이 충돌했다고 전달한다.
            director.GetComponent<GameDirector>().IncreaseScore();
        }
        
    }
}
