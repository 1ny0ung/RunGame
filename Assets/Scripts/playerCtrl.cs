using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// �÷��̾� ������Ʈ�� �����ϱ� ���� ��ũ��Ʈ
public class playerCtrl : MonoBehaviour
{
    // �÷��̾� ������Ʈ�� �ִϸ����� ������Ʈ ���� animator
    Animator animator;
    // �÷��̾� ������Ʈ�� rigidbody ������Ʈ ���� rb2d
    Rigidbody2D rb2d;
    // �÷��̾� hp ������ ���� hp (stage 1������ 6, stage 2������ 4�� ����)
    public int hp = 6;
    // �÷��̾ ������ �� ���� �پ������ �� ������ ���� jumpforce
    float jumpforce = 730.0f;
    // �÷��̾��� ���� ���� Ƚ���� ���� ���� jumpcount -> �̴� ���� �̻��� ���� ����
    float jumpcount = 0;
    // �÷��̾ ���� �ٰ� �ִ� �������� üũ�ϴ� ���� isJumping 
    // -> �÷��̾��� ���� �̿��� ��쿡 �÷��̾��� y ��ǥ�� ��ȭ�Ѵٸ� �ٴ��� ��������� �������� �������� ����� ������Ű�� ����
    public bool isJumping = false;

    // ������ (ü��, ����)�� ���� �� ����Ǵ� �Ҹ� 
    public AudioSource itemSound;
    // �÷��̾ ������ �� ����Ǵ� �Ҹ�
    public AudioSource jumpSound;
    // �÷��̾ ��ֹ��� �浹�� �� ����Ǵ� �Ҹ�
    public AudioSource crashSound;
    // �÷��̾ ��ǥ������ �������� �� ����Ǵ� �Ҹ�
    public AudioSource endSound;

    // Start is called before the first frame update
    void Start()
    { 
        // rb2d ������ �÷��̾� ������Ʈ�� rigidbody ����
        this.rb2d = this.GetComponent<Rigidbody2D>();
        // animator ������ �÷��̾� ������Ʈ�� animator ����
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // ȭ��ǥ ���Ʒ��� ������ ��� climb �ִϸ��̼����� ��ȯ
        if ((Input.GetKeyDown(KeyCode.UpArrow)) || (Input.GetKeyDown(KeyCode.DownArrow)))
        {
            // �ִϸ����Ϳ��� climb �� Ʈ���� �߻���Ŵ
            this.animator.SetTrigger("climbtrigger");
        }
        */

        // ���Ʒ� ȭ��ǥ���� �� ���� ��� �ٽ� run �ִϸ��̼����� ��ȯ
        if ((Input.GetKeyUp(KeyCode.UpArrow)) || (Input.GetKeyUp(KeyCode.DownArrow)))
        {
            // �ִϸ����Ϳ��� climb �� Ʈ���� �ٽ� ���½��� run���� ��ȯ
            this.animator.ResetTrigger("climbtrigger");
        }

        // �����̽� Ű�� ������ ��, ���� ���� Ƚ���� 1ȸ �����̸� ���� ���� 
        if ((Input.GetKeyDown(KeyCode.Space)) && jumpcount <= 1)
        {
            // ���� ȿ���� ���
            jumpSound.Play();
            // �÷��̾ ���� ������ isJumping�� ����
            isJumping = true;
            // �÷��̾��� animator�� jumptrigger�� ���� �ִϸ��̼� ����ϵ��� �� 
            this.animator.SetTrigger("jumptrigger");
            // �÷��̾��� rigidbody�� ���� �������� jumpforce��ŭ�� ������ ����
            this.rb2d.AddForce(transform.up * jumpforce);
            // ���� Ƚ�� 1 ȸ �߰�
            jumpcount++;
        }

        // ���� ���� �� ���� ����� ��
        // jumpcount 1ȸ ���¿��� ���� ���� �� jumpcount�� 2�̸�, ���� �Ϸ� ����
        if ((rb2d.velocity.y == 0) && (jumpcount == 2))
        {
            // jumpcount�� �ٽ� 0���� �ʱ�ȭ �� �Ϲ� / �̴� ���� �����ϵ��� �� 
            jumpcount = 0;
        }
    }

    // �÷��̾� ������Ʈ���� �浹�� �����ϴ� �Լ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� �÷��̾�� �浹�� ������Ʈ�� �±װ� 'obstacle'�̸� (��, ���η� ���� �ڽ�) 
        // �̹� �浹�� ������ ���� �ִ� ������Ʈ�� �ƴ϶��
        // hp�� 1 ���ҽ�Ű�� �ΰ����� �浹 ȿ�� �߻���Ŵ
        if ((collision.tag == "obstacle") && (collision.GetComponent<ObstacleCtrl>().hasHit == false))
        {
            // �浹 ȿ���� ���
            crashSound.Play();
            // �÷��̾� hp 1 ����
            hp--;
            // �浹�� ������Ʈ�� ��ũ��Ʈ ���� hasHit�� ������ �̹� �浹�� ���� ������ ���� 
            // �ϳ��� ������Ʈ�� ���� ���ظ� �ִ� ���� ���� ����
            collision.GetComponent<ObstacleCtrl>().hasHit = true;
            // �÷��̾� ������Ʈ�� animator�� hurttrigger�� �߻����� ��ģ �ִϸ��̼��� ����ϵ��� ��
            this.animator.SetTrigger("hurttrigger");
        }

        // ���� �÷��̾�� �浹�� ������Ʈ�� �±װ� 'eagle'�̸�
        // �̹� �浹�� ������ ���� �ִ� ������Ʈ�� �ƴ϶��
        // hp�� 1 ���ҽ�Ű�� �ΰ����� �浹 ȿ�� �߻���Ŵ
        else if ((collision.tag == "eagle") && (collision.GetComponent<EagleCtrl>().hasHit == false))
        {
            // �浹 ȿ���� ���
            crashSound.Play();
            // �÷��̾� hp 1 ����
            hp--;
            // �浹�� ������Ʈ�� ��ũ��Ʈ ���� hasHit�� ������ �̹� �浹�� ���� ������ ���� 
            // �ϳ��� ������Ʈ�� ���� ���ظ� �ִ� ���� ���� ����
            collision.GetComponent<EagleCtrl>().hasHit = true;
            // �÷��̾� ������Ʈ�� animator�� hurttrigger�� �߻����� ��ģ �ִϸ��̼��� ����ϵ��� ��
            this.animator.SetTrigger("hurttrigger");
        }

        // ���� �÷��̾�� �浹�� ������Ʈ�� �±װ� 'frog'�̸�
        // �̹� �浹�� ������ ���� �ִ� ������Ʈ�� �ƴ϶��
        // hp�� 1 ���ҽ�Ű�� �ΰ����� �浹 ȿ�� �߻���Ŵ
        else if ((collision.tag == "frog") && (collision.GetComponent<FrogCtrl>().hasHit == false))
        {
            // �浹 ȿ���� ���
            crashSound.Play();
            // �÷��̾� hp 1 ����
            hp--;
            // �浹�� ������Ʈ�� ��ũ��Ʈ ���� hasHit�� ������ �̹� �浹�� ���� ������ ���� 
            // �ϳ��� ������Ʈ�� ���� ���ظ� �ִ� ���� ���� ����
            collision.GetComponent<FrogCtrl>().hasHit = true;
            // �÷��̾� ������Ʈ�� animator�� hurttrigger�� �߻����� ��ģ �ִϸ��̼��� ����ϵ��� ��
            this.animator.SetTrigger("hurttrigger");
        }

        // ���� �÷��̾�� �浹�� ������Ʈ�� �±װ� 'opossum'�̸�
        // �̹� �浹�� ������ ���� �ִ� ������Ʈ�� �ƴ϶��
        // hp�� 1 ���ҽ�Ű�� �ΰ����� �浹 ȿ�� �߻���Ŵ
        else if ((collision.tag == "opossum") && (collision.GetComponent<OpossumCtrl>().hasHit == false))
        {
            // �浹 ȿ���� ���
            crashSound.Play();
            // �÷��̾� hp 1 ����
            hp--;
            // �浹�� ������Ʈ�� ��ũ��Ʈ ���� hasHit�� ������ �̹� �浹�� ���� ������ ���� 
            // �ϳ��� ������Ʈ�� ���� ���ظ� �ִ� ���� ���� ����
            collision.GetComponent<OpossumCtrl>().hasHit = true;
            // �÷��̾� ������Ʈ�� animator�� hurttrigger�� �߻����� ��ģ �ִϸ��̼��� ����ϵ��� ��
            this.animator.SetTrigger("hurttrigger");
        }

        // ���� �÷��̾�� �浹�� ������Ʈ�� �±װ� 'box'�̸�
        // �̹� �浹�� ������ ���� �ִ� ������Ʈ�� �ƴ϶��
        // hp�� 1 ���ҽ�Ű�� �ΰ����� �浹 ȿ�� �߻���Ŵ
        else if ((collision.tag == "box") && (collision.GetComponent<BoxCtrl>().hasHit == false))
        {
            // �浹 ȿ���� ���
            crashSound.Play();
            // �÷��̾� hp 1 ����
            hp--;
            // �浹�� ������Ʈ�� ��ũ��Ʈ ���� hasHit�� ������ �̹� �浹�� ���� ������ ���� 
            // �ϳ��� ������Ʈ�� ���� ���ظ� �ִ� ���� ���� ����
            collision.GetComponent<BoxCtrl>().hasHit = true;
            // �÷��̾� ������Ʈ�� animator�� hurttrigger�� �߻����� ��ģ �ִϸ��̼��� ����ϵ��� ��
            this.animator.SetTrigger("hurttrigger");
        }

        // ���� �÷��̾�� �浹�� ������Ʈ�� �±װ� 'mushroom'�̸�
        // �̹� �浹�� ������ ���� �ִ� ������Ʈ�� �ƴ϶��
        // hp�� 1 ���ҽ�Ű�� �ΰ����� �浹 ȿ�� �߻���Ŵ
        else if (collision.tag == "mushroom")
        {
            // ������ ȹ�� ȿ���� ���
            itemSound.Play();
            // �÷��̾� hp 1 ����
            hp--;
            // �÷��̾� ������Ʈ�� animator�� hurttrigger�� �߻����� ��ģ �ִϸ��̼��� ����ϵ��� ��
            this.animator.SetTrigger("hurttrigger");
            // ������ ����Ǵ� �������̹Ƿ� �浹�� ������Ʈ�� �Ҹ��Ŵ
            // ���� �浹 �˻����ִ� hasHit�� ������Ʈ ��ũ��Ʈ�� ���Խ�ų �ʿ䰡 ���� ����
            Destroy(collision.gameObject);
        }

        // ���� �÷��̾�� �浹�� ������Ʈ�� �±װ� 'cherry'�̸�
        // �÷��̾��� hp�� �̹� 6 �̻��� ���°� �ƴ϶�� (hp �ִ�ġ�� 6�̹Ƿ� 5 �̸��� ���� ü�� ���� ����)
        // hp�� 1 ������Ŵ
        else if ((collision.tag == "cherry") && (hp < 6))
        {
            // ������ ȹ�� ȿ���� ���
            itemSound.Play();
            // �÷��̾� hp 1 ����
            hp++;
            // ���� ������Ʈ�� �ڽ� ������Ʈ �� ù ������ Ȱ��ȭ��Ŵ
            // ȸ�� ������ ������ ���� �ֱ� ���� ȿ�� (ü���� �ڽ� ������Ʈ �ִϸ��̼�)�� Ȱ��ȭ��Ŵ
            collision.transform.GetChild(0).gameObject.SetActive(true);
            // ü���� ����Ǵ� �������̹Ƿ� �浹�� ������Ʈ �Ҹ�
            // ���� �浹 �˻����ִ� hasHit�� ������Ʈ ��ũ��Ʈ�� ���Խ�ų �ʿ䰡 ���� ����
            Destroy(collision.gameObject, 0.5f);
        }

        // ���� �÷��̾�� �浹�� ������Ʈ�� �±װ� 'flag'�̶��
        // -> �������� 1 ��� ��߰� �÷��̾� �浹
        // �������� 1 -> �������� 2�� �̵� �ܰ踦 ���� �ִ� �� 'nextStage'�� �ҷ���
        else if (collision.tag == "flag")
        {
            // �������� ��� ȿ���� ���
            endSound.Play();
            // �÷��̾� ������Ʈ�� �޸��� �ִϸ��̼� ���߰� �� �ִ� �ִϸ��̼� ����ϵ��� ��
            this.animator.Play("idle");
            // floor (�������� �����̴� �ٴ� ������Ʈ���� �θ� ������Ʈ)�� �ӵ��� 0���� ������ ������ ������ ����
            GameObject.Find("floor").GetComponent<Scroller>().speed = 0;
            // nextStage �� �ҷ���
            SceneManager.LoadScene("nextStage");
        }

        // ���� �÷��̾�� �浹�� ������Ʈ�� �±װ� 'flag2'�̶��
        // -> �������� 2 ��� ��߰� �÷��̾� �浹
        // ���� Ŭ��� ���� �ִ� �� 'gameclear'�� �ҷ���
        else if (collision.tag == "flag2")
        {
            // �������� ��� ȿ���� ���
            endSound.Play();
            // �÷��̾� ������Ʈ�� �޸��� �ִϸ��̼� ���߰� �� �ִ� �ִϸ��̼� ����ϵ��� ��
            this.animator.Play("idle");
            // floor (�������� �����̴� �ٴ� ������Ʈ���� �θ� ������Ʈ)�� �ӵ��� 0���� ������ ������ ������ ����
            GameObject.Find("floor").GetComponent<Scroller>().speed = 0;
            // gameclear �� �ҷ���
            SceneManager.LoadScene("gameclear");
        }
    }

    // �÷��̾� ������Ʈ���� �浹�� �����ϴ� �Լ�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �÷��̾� ������Ʈ�� �浹�� ������Ʈ�� �±װ� 'floor'���
        // �÷��̾� ������Ʈ�� �ٴ� ������Ʈ floor�� �پ� �ִٴ� �ǹ�
        if (collision.gameObject.tag == "floor")
        {
            // ���� ���°� �ƴϹǷ� isJumping�� �ݿ��ؾ� �� 
            isJumping = false;
        }
    }
}
