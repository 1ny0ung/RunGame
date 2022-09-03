using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾ ���� �Ÿ� ������ �ٰ����� ������ �������� ��ֹ� ������Ʈ box ���� ��ũ��Ʈ
public class BoxCtrl : MonoBehaviour
{
    // �÷��̾� ������Ʈ ������ ����
    GameObject player;
    // �÷��̾� ������Ʈ���� (x�� ����) �Ÿ� ������ ���� distance ����
    Vector3 distance = new Vector3(0, 0, 0);
    // ������Ʈ�� ���� ���ظ� ���� ���� ���� hasHit
    // �浹�� �÷��̾��� ü���� ���ҽ�Ų ���� �ִ����� ����
    public bool hasHit = false;
    // �ڽ� ������Ʈ�� ���� (������ ����) ������ ���� boxSize ����
    public size boxSize = size.big;

    // �ڽ� ������Ʈ�� ũ�⸦ �����ϱ� ���� �ڷ���
    public enum size
    {
        big, // ū �ڽ�
        small // ���� �ڽ�
    }

    // Start is called before the first frame update
    void Start()
    {
        // ���� ���� player ������Ʈ�� player ������ ����
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        // distance�� x ��ǥ�� box ������Ʈ�� player ������Ʈ�� �Ÿ� ������ x ��ǥ ���� ������ ��ȯ�Ͽ� ���� 
        distance.x = (int)(this.transform.position - player.transform.position).x;
        // ���� distance ������ ���̰� 5 ���ϰ� �Ǹ� (�÷��̾ x �� ���� ������ 5�� �� ��ŭ �������)
        // �׸��� y�� ���� - 0.5f�� �ٴٸ��� �ʴ� ���� (�ڽ��� ���鿡�� ���ߵ��� �ϱ� ����)
        if ((distance.magnitude <= 5) && (transform.localPosition.y > -0.5f))
        {
            // ū �ڽ��� ���
            if (boxSize == size.big)
            {
                // �����Ӹ��� y�� ���� 3.5��ŭ �Ʒ��� �̵�
                transform.localPosition -= new Vector3(0, 3.5f, 0);
            }
            // ���� �ڽ��� ���
            else if (boxSize == size.small)
            {
                // �����Ӹ��� y�� ���� 0.7��ŭ �Ʒ��� �̵�
                transform.localPosition -= new Vector3(0, 0.7f, 0);
            }
        }
    }
}
