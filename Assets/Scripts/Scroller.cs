using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾ �޸��� ��ó�� ���̱� ����
// �ٴ��� �������� �����̱� ���� ��ũ��Ʈ 
public class Scroller : MonoBehaviour
{
    // �ٴ��� �̵� �ӵ�
    // Stage 1������ 9.5f
    // Stage 2������ 9.95f ���
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �ٴ� ������Ʈ�� �� �����Ӹ��� �������� speed * ���� �ð���ŭ �̵���Ŵ
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
