using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어가 달리는 것처럼 보이기 위해
// 바닥을 좌측으로 움직이기 위한 스크립트 
public class Scroller : MonoBehaviour
{
    // 바닥의 이동 속도
    // Stage 1에서는 9.5f
    // Stage 2에서는 9.95f 사용
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 바닥 오브젝트를 매 프레임마다 좌측으로 speed * 단위 시간만큼 이동시킴
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
