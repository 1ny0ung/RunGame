using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ٴ��� �������� �����̴��� �ϴð� Ǯ ����� �÷��̾��� �ü����� ����� �ʰ� ������ ��ó�� �α� ����
// sky�� grass ������Ʈ�� ��ġ�� �����ϴ� ��ũ��Ʈ
public class BackgroundCtrl : MonoBehaviour
{
    // player ������Ʈ�� ������ ����
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        // player ������ ���� ���� player ������Ʈ ����
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        // player ������Ʈ�� �� ��ġ playerPos ������ ����
        Vector3 playerPos = player.transform.position;

        // �ϴ� ������Ʈ - �±װ� sky
        // player�� �ٴ� ������ �̵��ϴ��� player�� x ��ǥ�� ���� �̵��� �¿�δ� �������� �ʵ��� �� 
        // �÷��̾��� ������ ���󼭴� ��ȭ���� ���� , �������� �������� ���󼭴� ���Ʒ��� �������� �κ� �ٸ� ��  o)
        if (gameObject.tag == "sky")
        {
            // �ϴ� ������Ʈ�� �� ��ġ�� x ��ǥ�� �÷��̾��� �¿� �̵��� ���� �̵� (ȭ�� �����δ� �¿� ��ȭ ���� ����)
            // �������� ���� ������ �̵� ������
            transform.position = new Vector3(playerPos.x + 3f, transform.position.y, transform.position.z);
            // ���� �÷��̾ �������� ���� ���¿��� y ��ǥ�� ��ȭ�� �ִٸ� 
            // ��������� �������濡 ��ġ�� ���̹Ƿ� �ϴõ� ���� ���Ʒ��� �̵����� �ش� (ȭ�� �����δ� ���� ��ȭ ���� ����)
            if (player.GetComponent<playerCtrl>().isJumping == false)
            {
                //  player�� y ��ǥ ��ȭ�� ���߾� �ϴ� ������Ʈ�� y ��ǥ �̵� (ȭ�� �����δ� ���� ��ȭ ���� ����)
                transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
            }
        }

        // Ǯ�� ������Ʈ - �±װ� grass
        // player�� �ٴ� ������ �̵��ϴ��� player �� x ��ǥ�� ���� �̵��� �¿�δ� �������� �ʵ��� �� 
        // �÷��̾��� ���Ʒ� �̵��� ���߾� �̵����� ���� (�������� �κ� �޶���)
        else if (gameObject.tag == "grass")
        {
            // Ǯ�� ������Ʈ�� �� ��ġ�� x ��ǥ�� �÷��̾��� �¿� �̵��� ���� �̵� (ȭ�� �����δ� �¿� ��ȭ ���� ����)
            // ������ �̵��� ���󼭴� �÷��̾ ������ �����Ƿ� ȭ���� ��ȭ ������
            transform.position = new Vector3(playerPos.x + 2f, transform.position.y, transform.position.z);
        }
    }
}
