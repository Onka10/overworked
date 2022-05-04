using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleR : MonoBehaviour
{
    [SerializeField] private float mMoleQPosY, mMoleQPosX,mMoleQPosZ;//ｑのキーのモグラの位置
    [SerializeField] private float mMoleBetweenX, mMoleBetweenY,mMoleBetweenZ;
    [SerializeField] private MolePool mMolePool;
    private const int mTopDivisionKeyNum = 10;//一番上の段のキーの個数
    private const int mMiddleDivisionKeyNum = 9;//中断のキーの個数
    private const int mBottomDivisionKeyNum = 7;//下の段のキーの個数
    
    void Start()
    {
        //キーボードの数だけ発注
        mMolePool.CreatePool(mTopDivisionKeyNum + mMiddleDivisionKeyNum + mBottomDivisionKeyNum);
    }
    /// <summary>
    /// モグラを配置します
    /// </summary>
    /// <param name="_alphabetPermutation">Qを0としたアルファベットの順列。ｗが１。aが10</param>
    /// <param name="_mole">配置したいモグラ</param>>
    public GameObject SetMole(int _alphabetPermutation,GameObject _mole)
    {

        //担当しているキー
        float x = mMoleQPosX, y = mMoleQPosY, z = mMoleQPosZ;//ｑのキーの位置から展開

        //モグラの位置決め
        //キーボード一段目
        if (_alphabetPermutation < mTopDivisionKeyNum)
        {
            x += mMoleBetweenX * _alphabetPermutation;
        }
        //二段目
        else if (_alphabetPermutation < mTopDivisionKeyNum + mMiddleDivisionKeyNum)
        {
            x += mMoleBetweenX * (_alphabetPermutation - mTopDivisionKeyNum);
            y += mMoleBetweenY;
            z += mMoleBetweenZ;
        }
        //三段目
        else if (_alphabetPermutation < mTopDivisionKeyNum + mMiddleDivisionKeyNum + mBottomDivisionKeyNum)
        {
            x += mMoleBetweenX * (_alphabetPermutation - mTopDivisionKeyNum - mMiddleDivisionKeyNum);
            y += mMoleBetweenY * 2;
            z += mMoleBetweenZ * 2;
        }

        //モールの初期化
        _mole.AddComponent<Mole>();
        Mole moleClass = _mole.GetComponent<Mole>();

        //moleClass.InitMole(,x,y,z);
        
        return _mole;
    }
}
