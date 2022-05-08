using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
public class ScoreView : MonoBehaviour
{

    public Text scoreText;
    public ScoreManager scoreManager;

    void Start()
    {
        scoreManager.Score
        .Subscribe(t => scoreText.text = t.ToString())
        .AddTo(this);
    }
}
