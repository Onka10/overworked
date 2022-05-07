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
        //�_��
        if(mFlashing)
        {
            if (mKeyTopImage.color.a == 0)
            {
                //�F�����ʂ�
                mKeyTopImage.CrossFadeColor(mFirstKeyTopColor, mFlashingTime, false, true);
            }
            else if (mKeyTopImage.color == mFirstKeyTopColor)
            {
                //�A���t�@�������Ă�
                mKeyTopImage.CrossFadeAlpha(0, mFlashingTime, false);
            }
        }
    }
}
