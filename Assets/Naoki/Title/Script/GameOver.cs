using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    public int Score;
    public GameObject OverScene;
    public GameObject ResetButton;
    public Text t1;
    public Text t2;
    public Text t3;
    public Text t4;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void PlayOverAnime()
    {
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
    public void ResetOverAnime()
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
