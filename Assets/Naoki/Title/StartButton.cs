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
        if (false)//�X�y�[�X�������ăX�^�[�g
        {
            GameStart();
            //�A�j���[�V�������o������΁AButton�͋U���ł��\���܂���B
        }
    }
}
