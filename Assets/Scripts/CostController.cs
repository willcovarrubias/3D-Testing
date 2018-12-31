using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostController : MonoBehaviour {

    public GameObject[] buttonsToDisable = new GameObject[4];

    private void Start()
    {
        CheckIfThisStatIsCapped();
    }

    private void Update()
    {
        CheckIfThisStatIsCapped();
    }

    void CheckIfThisStatIsCapped()
    {
        for (int i = 0; i < 4; i++)
        {
            if (GameMaster.gameMaster.numberOfUnlocks[i] >= 5) //If there have been 5 or more unlocks for a stat.
            {

                buttonsToDisable[i].SetActive(false);

            }
            else
            {
                buttonsToDisable[i].SetActive(true);

            }

        }
        
    }
}
