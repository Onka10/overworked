using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public GameManeger gameManeger;
    // Start is called before the first frame update
    void Start()
    {
        gameManeger = FindObjectOfType<GameManeger>();
        score = gameManeger.nextScore;//������
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ScoreAdd(int moleScore)//�Ⴄ���������Ⴄ�|�C���g������΂������́B
    {
        score += moleScore;//�w�肷��X�R�A�����Z����B
    }

}
