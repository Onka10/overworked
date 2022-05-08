using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MoleView : MonoBehaviour
{
    [SerializeField] private GameObject mLeftEye, mRightEye;     //モグラの目
    [SerializeField] private GameObject mLeftAttackedEyePrefab,mRightAttackedEyePrefab;//大元のダメージを受けた目            //攻撃を受けた状態の目
    private GameObject mAttackedLeftEye, mAttackedRightEye;      //攻撃を受けた状態の両目

    /// <summary>
    /// 目を非表示にしたり表示したりする
    /// </summary>
    /// <param name="_leftEye">左目</param>
    /// <param name="_rightEye">右目</param>
    /// <param name="_active">有効化するかしないか</param>
    private void SetActiveEyes(GameObject _leftEye,GameObject _rightEye,bool _active)
    {
        _leftEye.SetActive(_active);
        _rightEye.SetActive(_active);
    }
    /// <summary>
    /// 目の差分パーツを初期化する
    /// </summary>
    /// <param name="_leftEyeObject">左目</param>
    /// <param name="_rightEyeObject">右目</param>
    private void InitEyesObject(GameObject _leftEyeObject,GameObject _rightEyeObject)
    {
        //位置調整
        _leftEyeObject.transform.position = mLeftEye.transform.position;
        _rightEyeObject.transform.position = mRightEye.transform.position;

        //親子付け
        _leftEyeObject.transform.SetParent(this.transform);
        _rightEyeObject.transform.SetParent(this.transform);

    }
    private void Start()
    {
        //ダメージを受けた目を複製
        mAttackedLeftEye = Instantiate(mLeftAttackedEyePrefab);
        mAttackedRightEye = Instantiate(mRightAttackedEyePrefab);

        //目のパーツを初期化
        InitEyesObject(mAttackedLeftEye,mAttackedRightEye);
        //ダメージを受けた目を非表示
        SetActiveEyes(mAttackedLeftEye, mAttackedRightEye, false);
    }
    /// <summary>
    /// 見た目の初期化
    /// </summary>
    public void InitLooks()
    {
        SetActiveEyes(mLeftEye,mRightEye,true);
    }
    /// <summary>
    /// 攻撃を受けた状態の見た目に変化
    /// </summary>
    public void ChangeAttackedLooks()
    {
        //攻撃を受ける前の目を非表示
        SetActiveEyes(mLeftEye,mRightEye, false);
        // 攻撃を受けた状態の目に変更
        SetActiveEyes(mAttackedLeftEye, mAttackedRightEye, true);
    }
}
