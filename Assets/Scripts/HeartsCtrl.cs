using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// �÷��̾��� ü���� ��Ÿ���� ü�¹ٸ� �����ϱ� ���� ������Ʈ
public class HeartsCtrl : MonoBehaviour
{
    // �÷��̾��� ü�¸�ŭ ������ ��Ÿ���� ���� ��Ʈ ������Ʈ���� ������ ����
    // ��Ʈ�� �ִ� ������ 6
    // �������� heart 1���� 6����, ü���� ��ȭ�� ��Ÿ���� ���� 1���� ������� ��Ȱ��ȭ�ǰ� ��
    GameObject heart1; GameObject heart2; GameObject heart3; 
    GameObject heart4; GameObject heart5; GameObject heart6;
    // �÷��̾� ������Ʈ�� ������ ����
    GameObject player;
    // �÷��̾��� ü���� ������ ����
    int playerHp = 6;
    // Start is called before the first frame update
    void Start()
    {
        // ���� ���� player ������Ʈ�� player ������ ����
        this.player = GameObject.Find("player");
        // ��Ʈ ������Ʈ���� �� ������ ���� 
        heart1 = GameObject.Find("Heart 1"); heart2 = GameObject.Find("Heart 2"); heart3 = GameObject.Find("Heart 3"); 
        heart4 = GameObject.Find("Heart 4"); heart5 = GameObject.Find("Heart 5"); heart6 = GameObject.Find("Heart 6");
    }

    // Update is called once per frame
    void Update()
    {
        // playerHp ������ �÷��̾� ������Ʈ�� hp ���� ���� �����Ӹ��� ������Ʈ�� ������
        playerHp = player.GetComponent<playerCtrl>().hp;

        // playerPos ������ �÷��̾� ������Ʈ�� ���� ��ġ�� �����Ӹ��� ������Ʈ�� ������
        Vector3 playerPos = player.transform.position;
        // ��Ʈ ������Ʈ���� ��ġ�� ��ȭ���� �ʴ� ��ó�� ���̱� ���ؼ� ���� ī�޶��� �����Ӱ� �Ȱ��� ������Ű�� ���� 
        // �÷��̾� ������Ʈ�� x �� ������ �¿� �������� ���� ��Ʈ ������Ʈ���� x ��ǥ �̵�
        transform.position = new Vector3(playerPos.x + 3f, transform.position.y, transform.position.z);
        // ���� ��Ȳ�� ������ ��Ȳ����
        if (player.GetComponent<playerCtrl>().isJumping == false)
        {
            // player�� y�� ���� ���� �������� ���� ��Ʈ ������Ʈ���� y ��ǥ �̵�
            transform.position = new Vector3(transform.position.x, playerPos.y + 0.1f, transform.position.z);
        }

        // playerHp ������ ���� ���� ǥ�õǴ� ��Ʈ ������Ʈ�� ������ �޶����� ��
        // switch ������ ó���� �������� ��Ʈ ������Ʈ�� ������ Ȱ�� / ��Ȱ�� ���� �ٲپ� ��
        switch (playerHp)
        {
            // �÷��̾��� ü���� 6�� ���
            case 6:
                // 1, 2, 3, 4, 5, 6 �� ��Ʈ ��� Ȱ��ȭ
                heart1.SetActive(true); heart2.SetActive(true); heart3.SetActive(true);
                heart4.SetActive(true); heart5.SetActive(true); heart6.SetActive(true);
                break;
            // �÷��̾��� ü���� 5�� ���
            case 5:
                // 1 �� ��Ʈ ��Ȱ��ȭ
                heart1.SetActive(false);
                // 2, 3, 4, 5, 6 �� ��Ʈ Ȱ��ȭ
                heart2.SetActive(true); heart3.SetActive(true); heart4.SetActive(true);
                heart5.SetActive(true); heart6.SetActive(true);
                break;
            // �÷��̾��� ü���� 4�� ���
            case 4:
                // 1, 2 �� ��Ʈ ��Ȱ��ȭ
                heart1.SetActive(false); heart2.SetActive(false);
                // 3, 4, 5, 6 �� ��Ʈ Ȱ��ȭ
                heart3.SetActive(true); heart4.SetActive(true); heart5.SetActive(true);
                heart6.SetActive(true);
                break;
            // �÷��̾��� ü���� 3�� ���
            case 3:
                // 1, 2, 3 �� ��Ʈ ��Ȱ��ȭ
                heart1.SetActive(false); heart2.SetActive(false); heart3.SetActive(false);
                // 4, 5, 6 �� ��Ʈ Ȱ��ȭ
                heart4.SetActive(true); heart5.SetActive(true); heart6.SetActive(true);
                break;
            // �÷��̾��� ü���� 2�� ���
            case 2:
                // 1, 2, 3, 4 �� ��Ʈ ��Ȱ��ȭ
                heart1.SetActive(false); heart2.SetActive(false); heart3.SetActive(false);
                heart4.SetActive(false);
                // 5, 6 �� ��Ʈ Ȱ��ȭ
                heart5.SetActive(true); heart6.SetActive(true);
                break;
            // �÷��̾��� ü���� 1�� ���
            case 1:
                // 1, 2, 3, 4, 5 �� ��Ʈ ��Ȱ��ȭ
                heart1.SetActive(false); heart2.SetActive(false); heart3.SetActive(false);
                heart4.SetActive(false); heart5.SetActive(false);
                // 6 �� ��Ʈ Ȱ��ȭ
                heart6.SetActive(true);
                break;
            // �÷��̾��� ü���� 0�� ���
            case 0:
                // 1, 2, 3, 4, 5, 6 �� ��Ʈ ��� ��Ȱ��ȭ
                heart1.SetActive(false); heart2.SetActive(false); heart3.SetActive(false);
                heart4.SetActive(false); heart5.SetActive(false); heart6.SetActive(false);
                // �÷��̾��� ü���� 0�� �Ǿ����Ƿ� gameover ������ �̵�
                SceneManager.LoadScene("gameover");
                break;
        }
    }
}
