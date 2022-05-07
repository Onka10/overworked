using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashingKeyTop : MonoBehaviour
{
    [SerializeField] private Image mKeyTopImage;    //点滅させるキートップ
    [SerializeField] private float mFlashSpan;      //点滅する時間的な間隔
    [SerializeField] private float mMaxFlashingTime;
    private float mFlashingTime;
    private Color mFirstKeyTopColor;                //最初の色
    private bool mFlashing;        //点滅中
    /// <summary>
    /// こいつを呼ぶと点滅開始する
    /// </summary>
    public void FlashStart()
    {
        mFlashing = true;
    }
    /// <summary>
    /// CanvasRendererのRGBを引数の色にする
    /// </summary>
    /// <param name="_color">この色に変更する</param>
    private void CrossFadeColorKeyTop(Vector4 _color)
    {
        mKeyTopImage.CrossFadeColor(_color, mFlashSpan, false, true);
    }
    /// <summary>
    /// 点滅
    /// </summary>
    private void Flash()
    {
        if (mKeyTopImage.canvasRenderer.GetColor() == mFirstKeyTopColor)
        {
            CrossFadeColorKeyTop(Color.gray);
        }
        else if (mKeyTopImage.canvasRenderer.GetColor() == Color.gray)
        {

            CrossFadeColorKeyTop(mFirstKeyTopColor);
        }
    }
    private void Start()
    {
        mFirstKeyTopColor = mKeyTopImage.color;
        mFlashingTime = 0.0f;
        mFlashing = false;
    }

   
    private void Update()
    {
        //点滅
        if (mFlashing)
        {
            mFlashingTime += Time.deltaTime;
            if (mFlashingTime < mMaxFlashingTime)
            {
                Flash();
            }
            else//時間いっぱい点滅したなら
            {
                CrossFadeColorKeyTop(mFirstKeyTopColor);
                mFlashing = false;
                mFlashingTime = 0.0f;
            }
        }

    }
}
