using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManeger : MonoBehaviour
{
    // // Start is called before the first frame update
    // private static GameObject mInstance;
    // public static GameObject Instance
    // {
    //     get
    //     {
    //         return mInstance;
    //     }
    // }
    // public int time;
    // public ScoreManager scoreManager;
    // bool ifGameStarted = false;//�Q�[���n�܂��Ă�̂�
    // public int nextScore = 0;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    //     if (mInstance == null)
    //     {
    //         DontDestroyOnLoad(gameObject);
    //         mInstance = gameObject;
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }

    //     time = 0;//������
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if (ifGameStarted)//�Q�[���I���܂ł̃X�R�A���L�^����B
    //     {
    //         nextScore = scoreManager.score;
    //     }

    // }
    // IEnumerator Timer()
    // {
    //     Debug.Log("Game Started");
    //     while (ifGameStarted)
    //     {
    //         yield return new WaitForSeconds(1f);//�^�C����b���ŋL�^����
    //         if (ifGameStarted)//��~��̍ĉ��Z��h�~����
    //         {
    //             time += 1;
    //         }


    //     }
    // }
    // public void StartTime()//�^�C���L�^�J�n
    // {
    //     if (!ifGameStarted)
    //     {
    //         ifGameStarted = true;
    //         StartCoroutine(Timer());
    //     }

    // }
    // public void PauseTime()//�ꎞ��~
    // {
    //     ifGameStarted = false;
    // }
    // public void ResetTime()//���Z�b�g
    // {

    //     ifGameStarted = false;
    //     time = 0;
    //     scoreManager.score = 0;

    // }
    // public void NextScene()//�V�[���`�F���W
    // {
    //     time = 0;
    //     ifGameStarted = false;
    //     nextScore = scoreManager.score;
    //     SceneManager.LoadScene(1);
    // }
}
