using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;

    // Start is called before the first frame update
    void Start()
    {

        score = 0;//初期化
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ScoreAdd(int moleScore)//違うモルもし違うポイントがあればそれを入力。
    {
        score += moleScore;//指定するスコアを加算する。
    }

}
