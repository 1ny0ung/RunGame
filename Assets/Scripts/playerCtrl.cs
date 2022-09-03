using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 플레이어 오브젝트를 관리하기 위한 스크립트
public class playerCtrl : MonoBehaviour
{
    // 플레이어 오브젝트의 애니메이터 컴포넌트 변수 animator
    Animator animator;
    // 플레이어 오브젝트의 rigidbody 오브젝트 변수 rb2d
    Rigidbody2D rb2d;
    // 플레이어 hp 저장할 변수 hp (stage 1에서는 6, stage 2에서는 4로 설정)
    public int hp = 6;
    // 플레이어가 점프할 때 위로 뛰어오르는 힘 저장할 변수 jumpforce
    float jumpforce = 730.0f;
    // 플레이어의 연속 점프 횟수를 세는 변수 jumpcount -> 이단 점프 이상을 막기 위함
    float jumpcount = 0;
    // 플레이어가 현재 뛰고 있는 상태인지 체크하는 변수 isJumping 
    // -> 플레이어의 점프 이외의 경우에 플레이어의 y 좌표가 변화한다면 바닥의 오르막길과 내리막길 때문으로 배경을 고정시키기 위함
    public bool isJumping = false;

    // 아이템 (체리, 버섯)을 먹을 때 재생되는 소리 
    public AudioSource itemSound;
    // 플레이어가 점프할 때 재생되는 소리
    public AudioSource jumpSound;
    // 플레이어가 장애물과 충돌할 때 재생되는 소리
    public AudioSource crashSound;
    // 플레이어가 목표지점에 도달했을 때 재생되는 소리
    public AudioSource endSound;

    // Start is called before the first frame update
    void Start()
    { 
        // rb2d 변수에 플레이어 컴포넌트의 rigidbody 배정
        this.rb2d = this.GetComponent<Rigidbody2D>();
        // animator 변수에 플레이어 컴포넌트의 animator 배정
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // 화살표 위아래로 누르는 경우 climb 애니메이션으로 전환
        if ((Input.GetKeyDown(KeyCode.UpArrow)) || (Input.GetKeyDown(KeyCode.DownArrow)))
        {
            // 애니메이터에서 climb 용 트리거 발생시킴
            this.animator.SetTrigger("climbtrigger");
        }
        */

        // 위아래 화살표에서 손 떼는 경우 다시 run 애니메이션으로 전환
        if ((Input.GetKeyUp(KeyCode.UpArrow)) || (Input.GetKeyUp(KeyCode.DownArrow)))
        {
            // 애니메이터에서 climb 용 트리거 다시 리셋시켜 run으로 전환
            this.animator.ResetTrigger("climbtrigger");
        }

        // 스페이스 키를 눌렀을 때, 연속 점프 횟수가 1회 이하이면 점프 실행 
        if ((Input.GetKeyDown(KeyCode.Space)) && jumpcount <= 1)
        {
            // 점프 효과음 재생
            jumpSound.Play();
            // 플레이어가 점프 중임을 isJumping에 저장
            isJumping = true;
            // 플레이어의 animator가 jumptrigger로 점프 애니메이션 재생하도록 함 
            this.animator.SetTrigger("jumptrigger");
            // 플레이어의 rigidbody에 위쪽 방향으로 jumpforce만큼의 힘ㅇ르 가함
            this.rb2d.AddForce(transform.up * jumpforce);
            // 점프 횟수 1 회 추가
            jumpcount++;
        }

        // 연속 점프 후 지상에 닿았을 때
        // jumpcount 1회 상태에서 점프 시행 후 jumpcount가 2이며, 점프 완료 상태
        if ((rb2d.velocity.y == 0) && (jumpcount == 2))
        {
            // jumpcount를 다시 0으로 초기화 해 일반 / 이단 점프 가능하도록 함 
            jumpcount = 0;
        }
    }

    // 플레이어 컴포넌트와의 충돌을 감지하는 함수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 만약 플레이어와 충돌한 오브젝트의 태그가 'obstacle'이며 (돌, 세로로 쌓인 박스) 
        // 이미 충돌을 감지한 적이 있는 오브젝트가 아니라면
        // hp를 1 감소시키고 부가적인 충돌 효과 발생시킴
        if ((collision.tag == "obstacle") && (collision.GetComponent<ObstacleCtrl>().hasHit == false))
        {
            // 충돌 효과음 재생
            crashSound.Play();
            // 플레이어 hp 1 감소
            hp--;
            // 충돌한 오브젝트의 스크립트 변수 hasHit에 접근해 이미 충돌한 적이 있음을 저장 
            // 하나의 오브젝트가 다중 피해를 주는 것을 막기 위함
            collision.GetComponent<ObstacleCtrl>().hasHit = true;
            // 플레이어 오브젝트의 animator가 hurttrigger를 발생시켜 다친 애니메이션을 재생하도록 함
            this.animator.SetTrigger("hurttrigger");
        }

        // 만약 플레이어와 충돌한 오브젝트의 태그가 'eagle'이며
        // 이미 충돌을 감지한 적이 있는 오브젝트가 아니라면
        // hp를 1 감소시키고 부가적인 충돌 효과 발생시킴
        else if ((collision.tag == "eagle") && (collision.GetComponent<EagleCtrl>().hasHit == false))
        {
            // 충돌 효과음 재생
            crashSound.Play();
            // 플레이어 hp 1 감소
            hp--;
            // 충돌한 오브젝트의 스크립트 변수 hasHit에 접근해 이미 충돌한 적이 있음을 저장 
            // 하나의 오브젝트가 다중 피해를 주는 것을 막기 위함
            collision.GetComponent<EagleCtrl>().hasHit = true;
            // 플레이어 오브젝트의 animator가 hurttrigger를 발생시켜 다친 애니메이션을 재생하도록 함
            this.animator.SetTrigger("hurttrigger");
        }

        // 만약 플레이어와 충돌한 오브젝트의 태그가 'frog'이며
        // 이미 충돌을 감지한 적이 있는 오브젝트가 아니라면
        // hp를 1 감소시키고 부가적인 충돌 효과 발생시킴
        else if ((collision.tag == "frog") && (collision.GetComponent<FrogCtrl>().hasHit == false))
        {
            // 충돌 효과음 재생
            crashSound.Play();
            // 플레이어 hp 1 감소
            hp--;
            // 충돌한 오브젝트의 스크립트 변수 hasHit에 접근해 이미 충돌한 적이 있음을 저장 
            // 하나의 오브젝트가 다중 피해를 주는 것을 막기 위함
            collision.GetComponent<FrogCtrl>().hasHit = true;
            // 플레이어 오브젝트의 animator가 hurttrigger를 발생시켜 다친 애니메이션을 재생하도록 함
            this.animator.SetTrigger("hurttrigger");
        }

        // 만약 플레이어와 충돌한 오브젝트의 태그가 'opossum'이며
        // 이미 충돌을 감지한 적이 있는 오브젝트가 아니라면
        // hp를 1 감소시키고 부가적인 충돌 효과 발생시킴
        else if ((collision.tag == "opossum") && (collision.GetComponent<OpossumCtrl>().hasHit == false))
        {
            // 충돌 효과음 재생
            crashSound.Play();
            // 플레이어 hp 1 감소
            hp--;
            // 충돌한 오브젝트의 스크립트 변수 hasHit에 접근해 이미 충돌한 적이 있음을 저장 
            // 하나의 오브젝트가 다중 피해를 주는 것을 막기 위함
            collision.GetComponent<OpossumCtrl>().hasHit = true;
            // 플레이어 오브젝트의 animator가 hurttrigger를 발생시켜 다친 애니메이션을 재생하도록 함
            this.animator.SetTrigger("hurttrigger");
        }

        // 만약 플레이어와 충돌한 오브젝트의 태그가 'box'이며
        // 이미 충돌을 감지한 적이 있는 오브젝트가 아니라면
        // hp를 1 감소시키고 부가적인 충돌 효과 발생시킴
        else if ((collision.tag == "box") && (collision.GetComponent<BoxCtrl>().hasHit == false))
        {
            // 충돌 효과음 재생
            crashSound.Play();
            // 플레이어 hp 1 감소
            hp--;
            // 충돌한 오브젝트의 스크립트 변수 hasHit에 접근해 이미 충돌한 적이 있음을 저장 
            // 하나의 오브젝트가 다중 피해를 주는 것을 막기 위함
            collision.GetComponent<BoxCtrl>().hasHit = true;
            // 플레이어 오브젝트의 animator가 hurttrigger를 발생시켜 다친 애니메이션을 재생하도록 함
            this.animator.SetTrigger("hurttrigger");
        }

        // 만약 플레이어와 충돌한 오브젝트의 태그가 'mushroom'이며
        // 이미 충돌을 감지한 적이 있는 오브젝트가 아니라면
        // hp를 1 감소시키고 부가적인 충돌 효과 발생시킴
        else if (collision.tag == "mushroom")
        {
            // 아이템 획득 효과음 재생
            itemSound.Play();
            // 플레이어 hp 1 감소
            hp--;
            // 플레이어 오브젝트의 animator가 hurttrigger를 발생시켜 다친 애니메이션을 재생하도록 함
            this.animator.SetTrigger("hurttrigger");
            // 버섯은 섭취되는 아이템이므로 충돌한 오브젝트를 소멸시킴
            // 다중 충돌 검사해주는 hasHit을 오브젝트 스크립트에 포함시킬 필요가 없는 이유
            Destroy(collision.gameObject);
        }

        // 만약 플레이어와 충돌한 오브젝트의 태그가 'cherry'이며
        // 플레이어의 hp가 이미 6 이상인 상태가 아니라면 (hp 최대치는 6이므로 5 미만일 때만 체리 섭취 가능)
        // hp를 1 증가시킴
        else if ((collision.tag == "cherry") && (hp < 6))
        {
            // 아이템 획득 효과음 재생
            itemSound.Play();
            // 플레이어 hp 1 증가
            hp++;
            // 층돌 오브젝트의 자식 오브젝트 중 첫 번쨰를 활성화시킴
            // 회복 아이템 습득을 보여 주기 위한 효과 (체리의 자식 오브젝트 애니메이션)를 활성화시킴
            collision.transform.GetChild(0).gameObject.SetActive(true);
            // 체리는 섭취되는 아이템이므로 충돌된 오브젝트 소멸
            // 다중 충돌 검사해주는 hasHit을 오브젝트 스크립트에 포함시킬 필요가 없는 이유
            Destroy(collision.gameObject, 0.5f);
        }

        // 만약 플레이어와 충돌한 오브젝트의 태그가 'flag'이라면
        // -> 스테이지 1 통과 깃발과 플레이어 충돌
        // 스테이지 1 -> 스테이지 2의 이동 단계를 보여 주는 씬 'nextStage'를 불러옴
        else if (collision.tag == "flag")
        {
            // 스테이지 통과 효과음 재생
            endSound.Play();
            // 플레이어 오브젝트가 달리는 애니메이션 멈추고 서 있는 애니메이션 재생하도록 함
            this.animator.Play("idle");
            // floor (좌측으로 움직이는 바닥 오브젝트들의 부모 오브젝트)의 속도를 0으로 설정해 게임의 움직임 멈춤
            GameObject.Find("floor").GetComponent<Scroller>().speed = 0;
            // nextStage 씬 불러옴
            SceneManager.LoadScene("nextStage");
        }

        // 만약 플레이어와 충돌한 오브젝트의 태그가 'flag2'이라면
        // -> 스테이지 2 통과 깃발과 플레이어 충돌
        // 게임 클리어를 보여 주는 씬 'gameclear'를 불러옴
        else if (collision.tag == "flag2")
        {
            // 스테이지 통과 효과음 재생
            endSound.Play();
            // 플레이어 오브젝트가 달리는 애니메이션 멈추고 서 있는 애니메이션 재생하도록 함
            this.animator.Play("idle");
            // floor (좌측으로 움직이는 바닥 오브젝트들의 부모 오브젝트)의 속도를 0으로 설정해 게임의 움직임 멈춤
            GameObject.Find("floor").GetComponent<Scroller>().speed = 0;
            // gameclear 씬 불러옴
            SceneManager.LoadScene("gameclear");
        }
    }

    // 플레이어 컴포넌트와의 충돌을 감지하는 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 플레이어 오브젝트와 충돌한 오브젝트의 태그가 'floor'라면
        // 플레이어 오브젝트가 바닥 오브젝트 floor와 붙어 있다는 의미
        if (collision.gameObject.tag == "floor")
        {
            // 점프 상태가 아니므로 isJumping에 반영해야 함 
            isJumping = false;
        }
    }
}
