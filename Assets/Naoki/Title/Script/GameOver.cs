using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Cysharp.Threading.Tasks;

public class GameOver : MonoBehaviour
{
    private int Score;
    public ScoreManager scoreManager;
    public GameObject OverScene;
    public GameObject ResetButton;
    public Text t1;
    public Text t2;
    public Text t3;
    public Text t4;
    GameManager _gameManger;

    // Start is called before the first frame update
    void Start()
    {
        _gameManger = GameManager.I;
        _gameManger.State
        .Where(s => s==GameState.Result)
        .Subscribe(_ =>{
            PlayOverAnime();
        })
        .AddTo(this);

        _gameManger.State
        .Where(s => s!=GameState.Result)
        .Subscribe(_ =>{
            ResetOverAnime();
        })
        .AddTo(this);
    }
    private void PlayOverAnime()
    {
        Score = scoreManager.Score.Value;
        OverScene.SetActive(true);
        Animator OverAnimator = OverScene.GetComponent<Animator>();
        OverAnimator.SetInteger("Score", Score);
        string s = Score.ToString();//�_���𕪊�����
        switch (s.Length)
        {
            case 1:
                t1.text = "0";
                t2.text = "0";
                t3.text = "0";
                t4.text = s[0].ToString();
                break;
            case 2:
                t1.text = "0";
                t2.text = "0";
                t3.text = s[0].ToString(); // 3
                t4.text = s[1].ToString(); // 4
                break;
            case 3:
                t1.text = "0";
                t2.text = s[0].ToString(); // 3
                t3.text = s[1].ToString(); // 4
                t4.text = s[2].ToString(); // 4
                break;
            case 4:
                t1.text = s[0].ToString(); // 1
                t2.text = s[1].ToString(); // 2
                t3.text = s[2].ToString(); // 3
                t4.text = s[3].ToString(); // 4
                break;
        }
        ResetButton.SetActive(true);
    }
    private void ResetOverAnime()
    {
        ResetButton.transform.position += new Vector3(0, -0.0471f, 0);
        OverScene.SetActive(false);
        ResetButton.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
