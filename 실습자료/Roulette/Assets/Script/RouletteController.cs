using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{

    float rotSpeed = 0; // 회전 속도

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 클릭하면 회전 속도를 설정한다.
        if(Input.GetMouseButtonDown(0)) {
            this.rotSpeed = 100;

            // 효과음을 재생한다.
            GetComponent<AudioSource>().Play();

            // 파티클을 표시한다.
            GetComponent<ParticleSystem>().Play();
        }

        // 회전 속도만큼 룰렛을 회전시킨다.
        transform.Rotate(0, 0, this.rotSpeed);
        
        // 룰렛을 감소시킨다.
        this.rotSpeed *= 0.98f; 
    }
}
