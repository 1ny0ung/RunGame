using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어가 일정 거리 안으로 다가오면 앞으로 다가오는 장애물 오브젝트 opossum 제어 스크립트
public class OpossumCtrl : MonoBehaviour
{
    // 플레이어 오브젝트 저장할 변수
    GameObject player;
    // 플레이어 오브젝트와의 (x축 상의) 거리 저장할 변수 distance 선언
    Vector3 distance = new Vector3(0, 0, 0);

    // 오브젝트의 다중 피해를 막기 위한 변수 hasHit
    // 충돌로 플레이어의 체력을 감소시킨 적이 있는지를 저장
    public bool hasHit = false;

    // Start is called before the first frame update
    void Start()
    {
        // 게임 씬의 player 오브젝트를 player 변수에 저장
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        // distance의 x 좌표에 opossum 오브젝트와 player 오브젝트의 거리 벡터의 x 좌표 값을 정수로 변환하여 저장 
        distance.x = (int)(this.transform.position - player.transform.position).x;
        // 만약 distance 벡터의 길이가 3 이상 11 이하이면 (플레이어가 11 안으로 들어오면 움직이기 시작, 3 떨어질 떄까지 다가옴)
        if ((distance.magnitude >= 3) && (distance.magnitude <= 11))
        {
            // opossum 오브젝트를 프레임당 x축으로 0.3씩 좌측으로 이동
            transform.position -= new Vector3(0.3f, 0, 0);
        }
    }
}
