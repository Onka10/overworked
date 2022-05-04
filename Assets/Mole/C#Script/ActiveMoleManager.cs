using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMoleManager : MonoBehaviour
{
    List<Mole> ActiveMoleClassList = new List<Mole>();

    public void AddActiveMoleList(Mole _mole)
    {
        ActiveMoleClassList.Add(_mole);
    }

    public void InputCheck(char _Input)
    {

    }
}
