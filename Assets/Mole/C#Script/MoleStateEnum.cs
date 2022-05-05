using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleStateEnum : MonoBehaviour
{
    public enum MoleState
    {    
        Incubation,        //キーボード下に潜伏中
        Appearance,        //キーボード上に出現
        DisAppearance,     //キーボード下に逃げた
        Dameged　　        //攻撃を受けている
    };

}
