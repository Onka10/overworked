using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMole : MonoBehaviour
{
    [SerializeField, Range(1.0f, 100.0f)] private float mAppearanceTimeLimit;   //出現時間
    [SerializeField] MoleStateEnum.MoleState mState;                //モグラの状態
    private float mAppearanceTime;                         //出現している時間
    private string mDeadKey;                               //死因のキーとなるキー

    /// <summary>
    /// このモグラの死因のキーの設定
    /// </summary>
    /// <param name="_InputKeyID">このキーで死にます</param>
    /// ゲームが始まると一度だけ呼ばれる
    public void SetMoleDeadKey(string _InputKeyID)
    {
        mDeadKey = _InputKeyID;
    }
    /// <summary>
    /// 攻撃が直撃したなら死ぬ
    /// </summary>
    /// <param name="_InputKeyName"></param>
    public void Attacked(string _InputKeyName)
    {
        if (mDeadKey == _InputKeyName)
        {
            ChangeMoleState(MoleStateEnum.MoleState.Dameged);
        }
    }

    /// <summary>
    /// モグラの出現時の挙動
    /// </summary>
    private void Appearance()
    {
        mAppearanceTime += Time.deltaTime;
        if (mAppearanceTime > mAppearanceTimeLimit)
        {
            //姿をくらました
            ChangeMoleState(MoleStateEnum.MoleState.DisAppearance);
        }
    }
    /// <summary>
    /// 引数の状態に変更するよ
    /// </summary>
    /// <param name="_changeState"></param>
    public void ChangeMoleState(MoleStateEnum.MoleState _changeState)
    {
        mState = _changeState;
    }
    /// <summary>
    /// モグラの出現時間の初期化
    /// </summary>
    private void Start()
    {
        mAppearanceTime = 0.0f;
        mState = MoleStateEnum.MoleState.Appearance;
        mDeadKey = "A";
    }

    private void Update()
    {
        if (mState == MoleStateEnum.MoleState.Appearance)       //出現中
        {
            Appearance();
            if(Input.GetKeyDown(KeyCode.A))
            {
                Attacked("A");
            }
        }
        else if (mState == MoleStateEnum.MoleState.Incubation)   //潜伏中
        {
            this.gameObject.SetActive(false);　　　　　　　　　　//潜伏状態になったら非アクティブ化する
        }
    }
}
