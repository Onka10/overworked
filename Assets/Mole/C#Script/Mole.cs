using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    [SerializeField,Range(1.0f,100.0f)] private float mAppearanceTimeLimit;   //出現時間
    private MoleState _moleState;                //モグラの状態
    private float mAppearanceTime;               //出現している時間

    /// <summary>
    /// モグラの 状態を返す
    /// </summary>
    public MoleState GetMoleState(){
        return _moleState;
    }

    /// <summary>
    /// 攻撃されたらなら死ぬ
    /// </summary>
    public void Attacked()
    { 
        ChangeMoleState(MoleState.Dameged);
        Debug.Log("攻撃された");

        //TO Doスコアマネージャを呼ぶ
    }

    /// <summary>
    /// 引数の状態に変更
    /// </summary>
    /// <param name="_changeState"></param>
    private void ChangeMoleState(MoleState _changeState)
    {
       _moleState  = _changeState;
    }

    

    // /// <summary>
    // /// モグラの出現時の挙動
    // /// </summary>
    // private void Appearance()
    // {
    //     mAppearanceTime += Time.deltaTime;
    //     if (mAppearanceTime>mAppearanceTimeLimit)
    //     {
    //         //姿をくらました
    //         //ChangeMoleState(MoleStateEnum.MoleState.DisAppearance);
    //     }
    // }

    // /// <summary>
    // /// モグラの出現時間の初期化
    // /// </summary>
    // private void OnEnable()
    // {
    //     mAppearanceTime = 0.0f;
    //     _moleState = MoleState.Appearance;
    // }

    // private void Update()
    // {
    //     if (_moleState == MoleState.Appearance)       //出現中
    //     {
    //         Appearance();
    //     }
    //     else if(_moleState == MoleState.Incubation)   //潜伏中
    //     {
    //         this.gameObject.SetActive(false);//潜伏状態になったら非アクティブ化する
    //     }
    // }
}
