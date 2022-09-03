using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���Ϸ� �̵��� �ݺ��ϴ� ��ֹ� ������Ʈ eagle ���� ��ũ��Ʈ
public class EagleCtrl : MonoBehaviour
{
    // eagle ������Ʈ�� ���� ��ġ ������ ����
    Vector3 initialPos;
    // eagle ������Ʈ�� ������ ������ ���ϴ� ���� dir (���̸� ����, ���̸� �Ʒ���)
    int dir = 1;
    // ������Ʈ�� ���� ���ظ� ���� ���� ���� hasHit
    // �浹�� �÷��̾��� ü���� ���ҽ�Ų ���� �ִ����� ����
    public bool hasHit = false;

    // Start is called before the first frame update
    void Start()
    {
        // initialPos�� eagle ������Ʈ�� ���� ���� �� ���� ��ġ�� ����
        initialPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // eagle ������Ʈ�� ��ġ�� �����Ӹ��� dir ���� * 0.15f ��ŭ �̵���Ŵ
        transform.localPosition += new Vector3(0, dir * 0.15f, 0);

        // ���� eagle ������Ʈ�� ���� ��ġ���� ���� y �� ���� 4 �̻� �̵��ϸ� ������ �ٲپ� �ٽ� �Ʒ��� �̵� 
        if ((this.transform.position.y - initialPos.y) >= 4)
        {
            // �̵� ���� ������ ��ȭ
            dir = -1;
        }
        // ���� eagle ������Ʈ�� y �� ���� ���� ��ġ�� ���ƿ��� ������ �ٲپ� �ٽ� ���� �̵� 
        if ((this.transform.position.y - initialPos.y) <= 0)
        {
            // �̵� ���� ������ ��ȭ
            dir = 1;
        }
    }
}
