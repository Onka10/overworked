using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    private Animation mAnimation;         
    private string mMoleCharID;           //モグラの識別名

    public void InitMole(string CharID,float posX,float posY,float posZ)
    {
        mAnimation = GetComponent<Animation>();
        Vector3 pos = new Vector3(posX, posY, posZ);
        gameObject.transform.position = pos;
        mMoleCharID = CharID;
    }

    public void Attacked(string Alphabet)
    {
        if (mMoleCharID == Alphabet)
        {
            Destroy(this);
        }
    }
}
