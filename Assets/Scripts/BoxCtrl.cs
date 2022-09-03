using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어가 일정 거리 안으로 다가오면 위에서 떨어지는 장애물 오브젝트 box 제어 스크립트
public class BoxCtrl : MonoBehaviour
{
    // 플레이어 오브젝트 저장할 변수
    GameObject player;
    // 플레이어 오브젝트와의 (x축 상의) 거리 저장할 변수 distance 선언
    Vector3 distance = new Vector3(0, 0, 0);
    // 오브젝트의 다중 피해를 막기 위한 변수 hasHit
    // 충돌로 플레이어의 체력을 감소시킨 적이 있는지를 저장
    public bool hasHit = false;
    // 박스 오브젝트의 종류 (사이즈 차이) 저장할 변수 boxSize 선언
    public size boxSize = size.big;

    // 박스 오브젝트의 크기를 저장하기 위한 자료형
    public enum size
    {
        big, // 큰 박스
        small // 작은 박스
    }

    // Start is called before the first frame update
    void Start()
    {
        // 게임 씬의 player 오브젝트를 player 변수에 저장
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        // distance의 x 좌표에 box 오브젝트와 player 오브젝트의 거리 벡터의 x 좌표 값을 정수로 변환하여 저장 
        distance.x = (int)(this.transform.position - player.transform.position).x;
        // 만약 distance 벡터의 길이가 5 이하가 되면 (플레이어가 x 축 기준 간격이 5가 될 만큼 가까워짐)
        // 그리고 y축 기준 - 0.5f에 다다르지 않는 동안 (박스가 지면에서 멈추도록 하기 위함)
        if ((distance.magnitude <= 5) && (transform.localPosition.y > -0.5f))
        {
            // 큰 박스인 경우
            if (boxSize == size.big)
            {
                // 프레임마다 y축 기준 3.5만큼 아래로 이동
                transform.localPosition -= new Vector3(0, 3.5f, 0);
            }
            // 작은 박스인 경우
            else if (boxSize == size.small)
            {
                // 프레임마다 y축 기준 0.7만큼 아래로 이동
                transform.localPosition -= new Vector3(0, 0.7f, 0);
            }
        }
    }
}
