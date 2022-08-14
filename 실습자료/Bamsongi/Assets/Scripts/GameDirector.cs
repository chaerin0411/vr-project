using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI를 사용하므로 잊지 말고 추가한다.

/* UI를 감독하는 스크립트 */
public class GameDirector : MonoBehaviour
{
    GameObject score;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.score = GameObject.Find("Score");
    }

    // 점수 올리는 메소드
    public void IncreaseScore()
    {
        this.count += 10;
        this.score.GetComponent<Text>().text = "점수 : " + this.count + " 점";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
