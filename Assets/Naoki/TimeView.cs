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
        gameManeger = GameObject.FindObjectOfType<GameManeger>();//�Q�[���}�l�[�W���[�擾
        TimerUI = GameObject.Find("Timer").GetComponent<Text>();//�^�C��UI�擾
    }

    // Update is called once per frame
    void Update()
    {

        TimerUI.text = gameManeger.time.ToString();//�^�C����\������
    }


}