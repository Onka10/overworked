using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManeger : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameObject mInstance;
    public static GameObject Instance
    {
        get
        {
            return mInstance;
        }
    }
    public int time;
    public ScoreManager scoreManager;
    bool ifGameStarted = false;//ゲーム始まってるのか
    public int nextScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        if (mInstance == null)
        {
            DontDestroyOnLoad(gameObject);
            mInstance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }

        time = 0;//初期化
    }

    // Update is called once per frame
    void Update()
    {
        if (ifGameStarted)//ゲーム終わるまでのスコアを記録する。
        {
            nextScore = scoreManager.score;
        }

    }
    IEnumerator Timer()
    {
        Debug.Log("Game Started");
        while (ifGameStarted)
        {
            yield return new WaitForSeconds(1f);//タイムを秒数で記録する
            if (ifGameStarted)//停止後の再加算を防止する
            {
                time += 1;
            }


        }
    }
    public void StartTime()//タイム記録開始
    {
        if (!ifGameStarted)
        {
            ifGameStarted = true;
            StartCoroutine(Timer());
        }

    }
    public void PauseTime()//一時停止
    {
        ifGameStarted = false;
    }
    public void ResetTime()//リセット
    {

        ifGameStarted = false;
        time = 0;
        scoreManager.score = 0;

    }
    public void NextScene()//シーンチェンジ
    {
        time = 0;
        ifGameStarted = false;
        nextScore = scoreManager.score;
        SceneManager.LoadScene(1);
    }
}
