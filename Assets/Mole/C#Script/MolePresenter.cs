using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolePresenter : MonoBehaviour
{
    [SerializeReference] private Mole mMole;
    private void InactiveCommplite()
    {
        // mMole.ChangeMoleState(MoleStateEnum.MoleState.Incubation);
    }
}
