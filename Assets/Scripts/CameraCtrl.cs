using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ٴ��� ���� �̵��� ������, ������ �̵����� ī�޶� �÷��̾ ����
// �÷��̾ ȭ�� ������ ����� �ʵ��� �ϱ� ���� ī�޶� �̵� ���� ��ũ��Ʈ
public class CameraCtrl : MonoBehaviour
{
    // player ������Ʈ�� ������ ���� player
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        // ���� ���� player ������Ʈ�� player ������ ����
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        // �÷��̾��� �� ��ġ�� playerPos ������ ���� 
        Vector3 playerPos = player.transform.position;
        // ī�޶� ������Ʈ�� ��ġ �� x ��ǥ�� �����Ӹ��� �÷��̾ ���� �̵���Ŵ
        transform.position = new Vector3(playerPos.x + 3f, transform.position.y, transform.position.z);
        // ���� ��Ȳ���� ī�޶� �̵� x
        // �������� �������� �̵��� ���� ī�޶��� y ��ǥ�� �÷��̾ ���� �̵� ��Ŵ
        // isJumping�� false -> �÷��̾ ���� ���� �ƴ� ���� �÷��̾��� y ��ǥ ���� ���� �̵�
        if (player.GetComponent<playerCtrl>().isJumping == false)
        {
            // ī�޶� ������Ʈ�� ��ġ �� y ��ǥ�� �����Ӹ��� �÷��̾ ���� �̵���Ŵ
            transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
        }
    }
}
