using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 플레이어의 체력을 나타내는 체력바를 관리하기 위한 오브젝트
public class HeartsCtrl : MonoBehaviour
{
    // 플레이어의 체력만큼 개수로 나타내기 위한 하트 오브젝트들을 저장할 변수
    // 하트의 최대 개수는 6
    // 좌측부터 heart 1부터 6으로, 체력의 변화를 나타내기 위해 1부터 순서대로 비활성화되게 됨
    GameObject heart1; GameObject heart2; GameObject heart3; 
    GameObject heart4; GameObject heart5; GameObject heart6;
    // 플레이어 오브젝트를 저장할 변수
    GameObject player;
    // 플레이어의 체력을 저장할 변수
    int playerHp = 6;
    // Start is called before the first frame update
    void Start()
    {
        // 게임 씬의 player 오브젝트를 player 변수와 연결
        this.player = GameObject.Find("player");
        // 하트 오브젝트들을 각 변수와 연결 
        heart1 = GameObject.Find("Heart 1"); heart2 = GameObject.Find("Heart 2"); heart3 = GameObject.Find("Heart 3"); 
        heart4 = GameObject.Find("Heart 4"); heart5 = GameObject.Find("Heart 5"); heart6 = GameObject.Find("Heart 6");
    }

    // Update is called once per frame
    void Update()
    {
        // playerHp 변수에 플레이어 오브젝트의 hp 변수 값을 프레임마다 업데이트해 가져옴
        playerHp = player.GetComponent<playerCtrl>().hp;

        // playerPos 변수에 플레이어 오브젝트의 현재 위치를 프레임마다 업데이트해 가져옴
        Vector3 playerPos = player.transform.position;
        // 하트 오브젝트들의 위치가 변화하지 않는 것처럼 보이기 위해서 메인 카메라의 움직임과 똑같이 고정시키기 위함 
        // 플레이어 오브젝트의 x 축 기준의 좌우 움직임을 따라 하트 오브젝트들의 x 좌표 이동
        transform.position = new Vector3(playerPos.x + 3f, transform.position.y, transform.position.z);
        // 점프 상황을 제외한 상황에서
        if (player.GetComponent<playerCtrl>().isJumping == false)
        {
            // player의 y축 기준 상하 움직임을 따라 하트 오브젝트들의 y 좌표 이동
            transform.position = new Vector3(transform.position.x, playerPos.y + 0.1f, transform.position.z);
        }

        // playerHp 변수의 값에 따라 표시되는 하트 오브젝트의 개수가 달라져야 함
        // switch 문으로 처리해 개수마다 하트 오브젝트들 각각의 활성 / 비활성 상태 바꾸어 줌
        switch (playerHp)
        {
            // 플레이어의 체력이 6인 경우
            case 6:
                // 1, 2, 3, 4, 5, 6 번 하트 모두 활성화
                heart1.SetActive(true); heart2.SetActive(true); heart3.SetActive(true);
                heart4.SetActive(true); heart5.SetActive(true); heart6.SetActive(true);
                break;
            // 플레이어의 체력이 5인 경우
            case 5:
                // 1 번 하트 비활성화
                heart1.SetActive(false);
                // 2, 3, 4, 5, 6 번 하트 활성화
                heart2.SetActive(true); heart3.SetActive(true); heart4.SetActive(true);
                heart5.SetActive(true); heart6.SetActive(true);
                break;
            // 플레이어의 체력이 4인 경우
            case 4:
                // 1, 2 번 하트 비활성화
                heart1.SetActive(false); heart2.SetActive(false);
                // 3, 4, 5, 6 번 하트 활성화
                heart3.SetActive(true); heart4.SetActive(true); heart5.SetActive(true);
                heart6.SetActive(true);
                break;
            // 플레이어의 체력이 3인 경우
            case 3:
                // 1, 2, 3 번 하트 비활성화
                heart1.SetActive(false); heart2.SetActive(false); heart3.SetActive(false);
                // 4, 5, 6 번 하트 활성화
                heart4.SetActive(true); heart5.SetActive(true); heart6.SetActive(true);
                break;
            // 플레이어의 체력이 2인 경우
            case 2:
                // 1, 2, 3, 4 번 하트 비활성화
                heart1.SetActive(false); heart2.SetActive(false); heart3.SetActive(false);
                heart4.SetActive(false);
                // 5, 6 번 하트 활성화
                heart5.SetActive(true); heart6.SetActive(true);
                break;
            // 플레이어의 체력이 1인 경우
            case 1:
                // 1, 2, 3, 4, 5 번 하트 비활성화
                heart1.SetActive(false); heart2.SetActive(false); heart3.SetActive(false);
                heart4.SetActive(false); heart5.SetActive(false);
                // 6 번 하트 활성화
                heart6.SetActive(true);
                break;
            // 플레이어의 체력이 0인 경우
            case 0:
                // 1, 2, 3, 4, 5, 6 번 하트 모두 비활성화
                heart1.SetActive(false); heart2.SetActive(false); heart3.SetActive(false);
                heart4.SetActive(false); heart5.SetActive(false); heart6.SetActive(false);
                // 플레이어의 체력이 0이 되었으므로 gameover 씬으로 이동
                SceneManager.LoadScene("gameover");
                break;
        }
    }
}
