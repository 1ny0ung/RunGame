using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 바닥이 좌측으로 움직이더라도 하늘과 풀 배경은 플레이어의 시선에서 벗어나지 않고 고정된 것처럼 두기 위함
// sky와 grass 오브젝트의 위치를 관리하는 스크립트
public class BackgroundCtrl : MonoBehaviour
{
    // player 오브젝트를 저장할 변수
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        // player 변수에 게임 씬의 player 오브젝트 배정
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        // player 오브젝트의 현 위치 playerPos 변수에 저장
        Vector3 playerPos = player.transform.position;

        // 하늘 오브젝트 - 태그가 sky
        // player가 바닥 위에서 이동하더라도 player의 x 좌표를 따라 이동해 좌우로는 움직이지 않도록 함 
        // 플레이어의 점프에 따라서는 변화하지 않음 , 오르막과 내리막에 따라서는 위아래로 보여지는 부분 다를 수  o)
        if (gameObject.tag == "sky")
        {
            // 하늘 오브젝트의 현 위치의 x 좌표는 플레이어의 좌우 이동을 따라 이동 (화면 상으로는 좌우 변화 없이 고정)
            // 점프했을 떄는 상하의 이동 보여짐
            transform.position = new Vector3(playerPos.x + 3f, transform.position.y, transform.position.z);
            // 만약 플레이어가 점프하지 않은 상태에서 y 좌표의 변화가 있다면 
            // 오르막길과 내리막길에 위치한 것이므로 하늘도 따라 위아래로 이동시켜 준다 (화면 상으로는 상하 변화 없이 고정)
            if (player.GetComponent<playerCtrl>().isJumping == false)
            {
                //  player의 y 좌표 변화에 맞추어 하늘 오브젝트의 y 좌표 이동 (화면 상으로는 상하 변화 없이 고정)
                transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
            }
        }

        // 풀밭 오브젝트 - 태그가 grass
        // player가 바닥 위에서 이동하더라도 player 의 x 좌표를 따라 이동해 좌우로는 움직이지 않도록 함 
        // 플레이어의 위아래 이동에 맞추어 이동하지 않음 (보여지는 부분 달라짐)
        else if (gameObject.tag == "grass")
        {
            // 풀밭 오브젝트의 현 위치의 x 좌표는 플레이어의 좌우 이동을 따라 이동 (화면 상으로는 좌우 변화 없이 고정)
            // 상하의 이동에 따라서는 플레이어를 따라가지 않으므로 화면의 변화 보여짐
            transform.position = new Vector3(playerPos.x + 2f, transform.position.y, transform.position.z);
        }
    }
}
