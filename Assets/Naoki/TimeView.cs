using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeView : MonoBehaviour
{
    public Text TimerUI;
    public GameManeger gameManeger;
    // Start is called before the first frame update
    void Start()
    {
        gameManeger = GameObject.FindObjectOfType<GameManeger>();//ゲームマネージャー取得
        TimerUI = GameObject.Find("Timer").GetComponent<Text>();//タイムUI取得
    }

    // Update is called once per frame
    void Update()
    {

        TimerUI.text = gameManeger.time.ToString();//タイムを表示する
    }


}