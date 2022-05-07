using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashingKeyTop : MonoBehaviour
{
    [SerializeField] Image mKeyTopImage;
    [SerializeField] float mFlashingTime;
    private Color mFirstKeyTopColor;
    private bool mFlashing;
    private void Start()
    {
        mFirstKeyTopColor = mKeyTopImage.color;
        mFlashing = false;
    }
    public void FlashStart()
    {
        mFlashing = true;
    }
    private void Update()
    {
        //点滅
        if(mFlashing)
        {
            if (mKeyTopImage.color.a == 0)
            {
                //色が元通り
                mKeyTopImage.CrossFadeColor(mFirstKeyTopColor, mFlashingTime, false, true);
            }
            else if (mKeyTopImage.color == mFirstKeyTopColor)
            {
                //アルファが減ってく
                mKeyTopImage.CrossFadeAlpha(0, mFlashingTime, false);
            }
        }
    }
}
