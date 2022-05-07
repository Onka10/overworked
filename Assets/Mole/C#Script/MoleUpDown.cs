using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleUpDown : MonoBehaviour
{
    [SerializeField] private float mMaxUpPositionY;    //最大高度
    private float mFirstPositionY;                     //最初のポジション
    [SerializeField] private float mUpSpeed;           //上下運動速度
    private bool mDownward;                            //下降中かどうか
    //速度をスクリプトで変更したい用
    public void SetUpDownParameter(float _maxUpPositionY,float _upSpeed)
    {
        mMaxUpPositionY = _maxUpPositionY;
        mUpSpeed = _upSpeed;
    }
    /// <summary>
    /// 一定高度まで行ったらそのあと下がるよ
    /// </summary>
    /// <returns>上下運動を完了したかどうか</returns>
    public bool UpDown()
    {
        Vector3 UpDownSpeed = new Vector3(0, mUpSpeed, 0);
        //上昇
        this.gameObject.transform.position += UpDownSpeed;
        //下降
        if (mDownward)
        {
            this.gameObject.transform.position -= UpDownSpeed;
        }
        //最大高度まで行けば下がりだすよ
        if(mMaxUpPositionY<transform.position.y)
        {
            mDownward = true;
        }
        //初期位置に戻れたらTrue
        if (mFirstPositionY > transform.position.y)
        {
            this.gameObject.transform.position = new Vector3(0, mFirstPositionY, 0);
            mDownward = false;
            return true;
        }
        return false;
    }

    private void Start()
    {
        mDownward = false;
        mFirstPositionY = this.transform.position.y;
        
    }
}
