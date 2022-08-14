using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // LoadScene을 사용하는 데 필요

/* Spacebar로 플레이어 점프시키기
   플레이어를 좌우로 움직이는 처리 추가하기
   플레이어 이미지 반전 추가하기
   Physics를 사용한 충돌 판정하기
   씬을 전환하는 처리
   버튼에 맞춰 점프하기 */
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 점프한다.
        // Spacebar를 누르면 플레이어가 점프해야 하므로 GetKeyDown() 메서드를 사용해 Spacebar가 눌렸는지 판단
        // 점프 중인지 감지하기
        // 점프하는 도중에는 계속 점프하지 못하도록 'Y 방향의 속도가 0(정지하고 있다)일때만 점프한다'라는 조건 추가
        if(Input.GetKeyDown(KeyCode.Space)  && this.rigid2D.velocity.y == 0) { 
            // 점프 애니메이션
            // 애니메이터 컨트롤러에 설치된 점프 트리거(JumpTrigger)를 열려면 Animator 컴포넌트가 가진 SetTrigger() 메서드를 사용
            // SetTrigger() 메서드는 매개변수로 지정한 이름의 트리거(Trigger)를 열어 애니메이션을 전환 
            // JumpTrigger를 지정해 Walk에서 Jump로 애니메이션을 전환
            this.animator.SetTrigger("JumpTrigger");
            // 플레이어에 힘을 가하려면 Rigidbody2D 컴포넌트가 가진 AddForce() 메서드를 사용
            // Rigidbody2D 컴포넌트를 갖는 메서드를 사용하기 때문에 Start 메서드에서 GetComponent() 메서드를 사용해 Rigidbody2D 컴포넌트를 구해 멤버 변수에 저장
            // 위쪽 방향으로 가도록 오브젝트에 힘 가하기
            // 위쪽 방향의 힘에는 길이가 1인 위쪽 방향 벡터(transform.up)에 jumpForce 값을 곱한 값을 사용
            // transform.up = (0, 1, 0)
            // transform.rignt = (1, 0, 0)
            // transform.up * jumpForce = (0, jumpForce, 0)
            this.rigid2D.AddForce(transform.up * this.jumpForce); 
        }

        // 좌우 이동
        // ->(오른쪽 화살표 키)가 눌리면 key 변수에 1을 대입
        // <-(왼쪽 화살표 키)가 눌리면 key 변수에 -1을 대입
        // ->나 <-가 눌리지 않았을 때는 플레이어가 움직이지 않도록 key 변수를 0으로 유지
        int key = 0;
        if(Input.GetKey(KeyCode.RightArrow)) key = 1;
        if(Input.GetKey(KeyCode.LeftArrow)) key = -1;

        // 플레이어 속도
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // 스피드 제한
        // 자동차 운전과 마찬가지로 플레이어의 이동 속도가 지정한 최고 속도(maxWalkSpeed)보다 빠르다면 힘을 가하는 것을 멈추고 속도를 조절함
        if(speedx < this.maxWalkSpeed) {
            // AddForce() 메서드를 사용해 좌우로 힘을 가해서 플레이어를 움직임
            // 오른쪽으로 움직이려면 오른쪽 방향 힘(X 방향), 왼쪽으로 움직이려면 왼쪽 방향 힘(-X 방향)을 가해야 하므로 key 변수를 사용해 부호를 제어
            // key = 1이면 key * walkForce = 30
            // key = -1이면 key * walkForce = -30
            // 프레임마다 AddForce() 메서드를 사용해 힘을 계속해서 가하면 플레이어는 점점 가속함
            // 엑섹을 밟으면 차가 가속하는 것과 같음
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        // 움직이는 방향에 따라 플레이어 이미지 반전
        // 플레이어가 오른쪽으로 움직이면 스프라이트도 오른쪽으로 향함
        // 왼쪽으로 움직이면 왼쪽으로 향하도록 이미지를 반전시켜 표시
        // 플레이어의 스프라이트를 반전시키려면 스프라이트의 X 방향 배율을 -1배로 변경
        // 스크립트에서 스프라이트 배율을 바꾸려면 Transform 컴포넌트의 localScale 변수 값을 변경
        // key 변수를 사용하고 ->를 눌렀다면 X축 방향으로 1배, <-를 눌렀다면 X축 방향으로 -1배로 설정
        // 힘을 가한 후의 움직임은 유니티가 계산하기 때문에 Spacebar와 좌우 화살표 키(<- 또는 ->)를 동시에 누르면 사선 방향으로도 점프할 수 있음
        if(key != 0) {
            transform.localScale = new Vector3(key, 1, 1);
        }

        // 플레이어 속도에 맞춰 애니메이션 속도를 바꾼다.
        // 플레이어 이동 속도가 0이면 애니메이션 재생 속도도 0에서 정지
        // 이동 속도가 빨라질수록 애니메이션 속도도 빨라짐
        // 애니메이션 재생 속도를 바꾸려면 Animator 컴포넌트의 speed 변수를 변경
        // Start() 메서드에서 GetComponent() 메서드를 사용해 Animator 컴포넌트를 구함
        // speed 변수에 플레이어 이동 속도를 대입
        // 대입할 때 이동 속도를 애니메이션 속도로 맞추면 너무 빠르므로 2.0으로 나눠 애니메이션 속도를 조절
        // 플레이어의 Y 방향 이동 속도를 보고 점프 중이면 항상 애니메이션 속도를 1.0으로 지정
        // 점프 중이 아니면 이동 속도에 따라 애니메이션이 재생되도록 지정
        if(this.rigid2D.velocity.y == 0) {
            this.animator.speed = speedx / 2.0f;
        }
        else {
            this.animator.speed = 1.0f;
        }

        // 플레이어가 화면 밖으로 나갔다면 처음으로 돌아가기
        // 플레이어가 화면 밖으로 나가도 끝없이 떨어지는 것 방지
        if(transform.position.y < -10) {
            SceneManager.LoadScene("GameScene");
        }
        
    }

    // 목표지점 도착
    // 오브젝트들이 충돌한 순간에는 OnTriggerEnter2D 메서드가 한 번만 호출됨
    // OnTriggerEnter2D() 메서드의 매개변수에는 충돌 상대의 오브젝트에 적용한 Collider가 전달됨
    // OnTriggerEnter2D() 메서드에서 LoadScene() 메서드를 사용해 ClearScene으로 전환
    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("목표지점 도착!");
        SceneManager.LoadScene("ClearScene");
    }
}
