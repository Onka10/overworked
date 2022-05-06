using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartButton : MonoBehaviour
{
    Button SButton;
    private void Start()
    {
        SButton = gameObject.GetComponent<Button>();
    }
    public void GameStart()
    {
        Debug.Log("GameStart");
    }
    private void Update()
    {
        if (false)//スペースを押してスタート
        {
            GameStart();
            //アニメーション演出があれば、Buttonは偽物でも構いません。
        }
    }
}
