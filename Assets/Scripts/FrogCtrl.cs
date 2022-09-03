using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾�� ���� �Ÿ� �̻� ��������� ���� �����ϴ� ������Ʈ frog �����ϱ� ���� ��ũ��Ʈ
public class FrogCtrl : MonoBehaviour
{
    // �÷��̾� ������Ʈ ������ ����
    GameObject player;
    // frog ������Ʈ�� animator ������ ����
    Animator animator;
    // �÷��̾� ������Ʈ���� (x�� ����) �Ÿ� ������ ���� distance ����
    Vector3 distance = new Vector3(0, 0, 0);

    // ������Ʈ�� ���� ���ظ� ���� ���� ���� hasHit
    // �浹�� �÷��̾��� ü���� ���ҽ�Ų ���� �ִ����� ����
    public bool hasHit = false;
    // Start is called before the first frame update
    void Start()
    {
        // ���� ���� player ������Ʈ�� player ������ ����
        player = GameObject.Find("player");
        // frog ������Ʈ�� Animator ������Ʈ ������ animator ������ ����
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // distance�� x ��ǥ�� frog ������Ʈ�� player ������Ʈ�� �Ÿ� ������ x ��ǥ ���� ������ ��ȯ�Ͽ� ���� 
        distance.x = (int)(this.transform.position - player.transform.position).x;
        // frog �� �÷��̾ y�ุ���� 6��ŭ�� �Ÿ��� �Ǵ� ���
        if (distance.magnitude == 6)
        {
            // jumptrigger �߻���Ŵ���ν� �������� Animator�� ���� �ִϸ��̼��� ����ϰ� ��
            animator.SetTrigger("jumptrigger");
        }
        // frog�� �÷��̾ y�ุ���� 6 �̸��� �Ÿ���ŭ�� ���ܵδ� ���
        else if(distance.magnitude <= 5)
        {
            // forg ������Ʈ�� �����Ӵ� 0.4�� y�� �������� ���� �̵�
            transform.localPosition += new Vector3(0, 0.4f, 0);
        }
    }
}
