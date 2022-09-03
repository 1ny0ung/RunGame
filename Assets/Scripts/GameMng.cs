using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 버튼 클릭을 통한 게임 씬 간의 이동을 관리하는 GameMng 스크립트
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

    // StartScene씬, gameover 씬, gameclear 씬에서 stage1에서 게임을 시작하기 위함
    // 버튼 클릭과 연결
    public void reStart()
    {
        // Stage 1 씬으로 이동
        SceneManager.LoadScene("Stage 1");
    }

    // nextStage 씬에서 다음 스테이지로 넘어가기 위함
    // 버튼 클릭과 연결
    public void Stage1to2()
    {
        // Stage 2 씬으로 이동
        SceneManager.LoadScene("Stage 2");
    }

    // gameover, gameclear 씬에서 게임 종료를 눌렀을 때 다시 시작 화면으로 돌아가기 위함
    // 버튼 클릭과 연결
    public void main()
    {
        // StartScene 씬으로 이동
        SceneManager.LoadScene("StartScene");
    }
}

