using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어와 일정 거리 이상 가까워지면 위로 점프하는 오브젝트 frog 제어하기 위한 스크립트
public class FrogCtrl : MonoBehaviour
{
    // 플레이어 오브젝트 저장할 변수
    GameObject player;
    // frog 오브젝트의 animator 저장할 변수
    Animator animator;
    // 플레이어 오브젝트와의 (x축 상의) 거리 저장할 변수 distance 선언
    Vector3 distance = new Vector3(0, 0, 0);

    // 오브젝트의 다중 피해를 막기 위한 변수 hasHit
    // 충돌로 플레이어의 체력을 감소시킨 적이 있는지를 저장
    public bool hasHit = false;
    // Start is called before the first frame update
    void Start()
    {
        // 게임 씬의 player 오브젝트를 player 변수에 저장
        player = GameObject.Find("player");
        // frog 오브젝트의 Animator 컴포넌트 가져와 animator 변수에 저장
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // distance의 x 좌표에 frog 오브젝트와 player 오브젝트의 거리 벡터의 x 좌표 값을 정수로 변환하여 저장 
        distance.x = (int)(this.transform.position - player.transform.position).x;
        // frog 와 플레이어가 y축만으로 6만큼의 거리가 되는 경우
        if (distance.magnitude == 6)
        {
            // jumptrigger 발생시킴으로써 개구리의 Animator가 점프 애니메이션을 재생하게 됨
            animator.SetTrigger("jumptrigger");
        }
        // frog와 플레이어가 y축만으로 6 미만의 거리만큼을 남겨두는 경우
        else if(distance.magnitude <= 5)
        {
            // forg 오브젝트는 프레임당 0.4씩 y축 기준으로 위로 이동
            transform.localPosition += new Vector3(0, 0.4f, 0);
        }
    }
}
