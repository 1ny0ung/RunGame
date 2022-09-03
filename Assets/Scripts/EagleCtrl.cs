using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 상하로 이동을 반복하는 장애물 오브젝트 eagle 제어 스크립트
public class EagleCtrl : MonoBehaviour
{
    // eagle 오브젝트의 최초 위치 저장할 변수
    Vector3 initialPos;
    // eagle 오브젝트가 움직일 방향을 정하는 변수 dir (양이면 위로, 음이면 아래로)
    int dir = 1;
    // 오브젝트의 다중 피해를 막기 위한 변수 hasHit
    // 충돌로 플레이어의 체력을 감소시킨 적이 있는지를 저장
    public bool hasHit = false;

    // Start is called before the first frame update
    void Start()
    {
        // initialPos에 eagle 오브젝트의 게임 시작 시 최초 위치를 저장
        initialPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // eagle 오브젝트의 위치를 프레임마다 dir 변수 * 0.15f 만큼 이동시킴
        transform.localPosition += new Vector3(0, dir * 0.15f, 0);

        // 만약 eagle 오브젝트가 최초 위치에서 위로 y 축 기준 4 이상 이동하면 방향을 바꾸어 다시 아래로 이동 
        if ((this.transform.position.y - initialPos.y) >= 4)
        {
            // 이동 방향 음으로 변화
            dir = -1;
        }
        // 만약 eagle 오브젝트가 y 축 기준 최초 위치로 돌아오면 방향을 바꾸어 다시 위로 이동 
        if ((this.transform.position.y - initialPos.y) <= 0)
        {
            // 이동 방향 양으로 변화
            dir = 1;
        }
    }
}
