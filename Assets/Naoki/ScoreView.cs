using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreView : MonoBehaviour
{

    public Text scoreText;
    public ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();//スコアマネージャー取得
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();//スコアUI取得
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoreManager.score.ToString();//スコア表示
    }
}
