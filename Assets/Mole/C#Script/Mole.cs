using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    [SerializeField,Range(1.0f,100.0f)] private float mAppearanceTimeLimit;   //�o������
    private string mDeadKey;                               //�����̃L�[�ƂȂ�L�[
    private MoleStateEnum.MoleState mState;                //���O���̏��
    private float mAppearanceTime;
    /// <summary>
    /// ���̃��O���̎����̃L�[�̐ݒ�
    /// </summary>
    /// <param name="_InputKeyID">���̃L�[�Ŏ��ɂ܂�</param>
    /// �Q�[�����n�܂�ƈ�x�����Ă΂��
    public void InitMole(string _InputKeyID)
    {
        mDeadKey = _InputKeyID;
    }
    /// <summary>
    /// �U�������������Ȃ玀��
    /// </summary>
    /// <param name="_InputKeyName"></param>
    public void Attacked(string _InputKeyName)
    {
        if (mDeadKey == _InputKeyName) 
        {
            
        }
    }
    private void Appearance()
    {
        mAppearanceTime += Time.deltaTime;
        if (mAppearanceTime>mAppearanceTimeLimit)
        {
            
        }
    }
    private void ChangeMoleState(MoleStateEnum.MoleState _changeState)
    {

    }
    private void OnEnable()
    {
        mAppearanceTime = 0.0f;
    }
    private void Update()
    {


    }
}
