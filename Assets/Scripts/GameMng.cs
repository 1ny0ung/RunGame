using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ��ư Ŭ���� ���� ���� �� ���� �̵��� �����ϴ� GameMng ��ũ��Ʈ
public class GameMng : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // StartScene��, gameover ��, gameclear ������ stage1���� ������ �����ϱ� ����
    // ��ư Ŭ���� ����
    public void reStart()
    {
        // Stage 1 ������ �̵�
        SceneManager.LoadScene("Stage 1");
    }

    // nextStage ������ ���� ���������� �Ѿ�� ����
    // ��ư Ŭ���� ����
    public void Stage1to2()
    {
        // Stage 2 ������ �̵�
        SceneManager.LoadScene("Stage 2");
    }

    // gameover, gameclear ������ ���� ���Ḧ ������ �� �ٽ� ���� ȭ������ ���ư��� ����
    // ��ư Ŭ���� ����
    public void main()
    {
        // StartScene ������ �̵�
        SceneManager.LoadScene("StartScene");
    }
}

