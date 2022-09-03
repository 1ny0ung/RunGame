using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾ ���� �Ÿ� ������ �ٰ����� ������ �ٰ����� ��ֹ� ������Ʈ opossum ���� ��ũ��Ʈ
public class OpossumCtrl : MonoBehaviour
{
    // �÷��̾� ������Ʈ ������ ����
    GameObject player;
    // �÷��̾� ������Ʈ���� (x�� ����) �Ÿ� ������ ���� distance ����
    Vector3 distance = new Vector3(0, 0, 0);

    // ������Ʈ�� ���� ���ظ� ���� ���� ���� hasHit
    // �浹�� �÷��̾��� ü���� ���ҽ�Ų ���� �ִ����� ����
    public bool hasHit = false;

    // Start is called before the first frame update
    void Start()
    {
        // ���� ���� player ������Ʈ�� player ������ ����
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        // distance�� x ��ǥ�� opossum ������Ʈ�� player ������Ʈ�� �Ÿ� ������ x ��ǥ ���� ������ ��ȯ�Ͽ� ���� 
        distance.x = (int)(this.transform.position - player.transform.position).x;
        // ���� distance ������ ���̰� 3 �̻� 11 �����̸� (�÷��̾ 11 ������ ������ �����̱� ����, 3 ������ ������ �ٰ���)
        if ((distance.magnitude >= 3) && (distance.magnitude <= 11))
        {
            // opossum ������Ʈ�� �����Ӵ� x������ 0.3�� �������� �̵�
            transform.position -= new Vector3(0.3f, 0, 0);
        }
    }
}
