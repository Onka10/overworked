using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolePool : MonoBehaviour
{
    [SerializeField] private GameObject mMole;   //モグラのオブジェクト
    private List<GameObject> mMoleObjectList;

    /// <summary>
    /// モグラのプールを生成
    /// </summary>
    /// <param name="MaxCount">モグラの最大数</param>
    public void CreatePool(int MaxCount)
    {
        for (int i = 0; i > MaxCount; i++) 
        {
            GameObject NewMole = CreateNewMole();
            NewMole.SetActive(false);
            mMoleObjectList.Add(NewMole);
        }
    }
    /// <summary>
    /// モグラを生成
    /// </summary>
    /// <returns>生成したモグラ</returns>
    private GameObject CreateNewMole()
    {
        GameObject NewMole = Instantiate(mMole);

        return NewMole;
    }

    /// <summary>
    /// 使えるモグラを渡します
    /// </summary>
    /// <returns>今出現していないモグラ</returns>
    public GameObject GetMole()
    {
        foreach(var Mole in mMoleObjectList)
        {
            if(Mole.activeSelf==false)
            {
                Mole.SetActive(true);
                return Mole;
            }
        }
        GameObject NewMole = CreateNewMole();
        NewMole.SetActive(true);
        mMoleObjectList.Add(NewMole);
        return NewMole;
    }

}
