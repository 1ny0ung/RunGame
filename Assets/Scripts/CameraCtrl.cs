using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 바닥의 좌측 이동과 오르막, 내리막 이동에도 카메라가 플레이어를 따라가
// 플레이어가 화면 밖으로 벗어나지 않도록 하기 위한 카메라 이동 제어 스크립트
public class CameraCtrl : MonoBehaviour
{
    // player 오브젝트를 저장할 변수 player
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        // 게임 씬의 player 오브젝트를 player 변수에 배정
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어의 현 위치를 playerPos 변수에 저장 
        Vector3 playerPos = player.transform.position;
        // 카메라 오브젝트의 위치 중 x 좌표를 프레임마다 플레이어를 따라 이동시킴
        transform.position = new Vector3(playerPos.x + 3f, transform.position.y, transform.position.z);
        // 점프 상황에는 카메라 이동 x
        // 오르막과 내리막을 이동할 떄만 카메라의 y 좌표를 플레이어를 따라 이동 시킴
        // isJumping이 false -> 플레이어가 점프 중이 아닐 때만 플레이어의 y 좌표 따라 상하 이동
        if (player.GetComponent<playerCtrl>().isJumping == false)
        {
            // 카메라 오브젝트의 위치 중 y 좌표를 프레임마다 플레이어를 따라 이동시킴
            transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
        }
    }
}
