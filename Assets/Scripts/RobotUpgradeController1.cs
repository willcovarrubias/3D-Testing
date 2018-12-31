using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotUpgradeController1 : MonoBehaviour {

    Animator anim;

    private int boltsCount;
    public Text boltsCountText;
    private int boltsSpent;
    private int boltsCost;
    private int boltsTotal;
    public Text boltsTotalText;
    public Text areYouSureText;

    private float massToAdd;
    private float speedToAdd;
    private float jumpHeightToAdd;
    private float punchCooldownToAdd;
    private int numberOfUnlocksToAdd;

    public Text[] unlockCostText = new Text[4];
    public Text[] unlockProgressText = new Text[4];
    public GameObject notEnoughBoltsObject;
    public GameObject areYouSureObject;
    public GameObject pleaseSelectAnUpgrade;
    private int costOfUnlocks;
    private int newAmountCost;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        boltsTotal = GameMaster.gameMaster.boltsCollected;
        boltsTotalText.text = "Total Bolts: " + boltsTotal;

        for (int i = 0; i < 4; i++)
        {
            unlockProgressText[i].text = GameMaster.gameMaster.numberOfUnlocks[i] + "/5";

        }

    }

    private void Update()
    {
        

        if (boltsCount == 0)
        {
            boltsCountText.text = "Confirm";
        }
        else
        {
            boltsCountText.text = "Confirm (-" + boltsCount + " Bolts)";
        }

        if (GameMaster.gameMaster.numberOfUnlocks[0] + GameMaster.gameMaster.numberOfUnlocks[1] + GameMaster.gameMaster.numberOfUnlocks[2] + GameMaster.gameMaster.numberOfUnlocks[3] == 0)
        {
            costOfUnlocks = 5;
        }
        if (GameMaster.gameMaster.numberOfUnlocks[0] + GameMaster.gameMaster.numberOfUnlocks[1] + GameMaster.gameMaster.numberOfUnlocks[2] + GameMaster.gameMaster.numberOfUnlocks[3] == 1)
        {
            costOfUnlocks = 6;
        }   
        if (GameMaster.gameMaster.numberOfUnlocks[0] + GameMaster.gameMaster.numberOfUnlocks[1] + GameMaster.gameMaster.numberOfUnlocks[2] + GameMaster.gameMaster.numberOfUnlocks[3] == 2)
        {
            costOfUnlocks = 7;
        }    
        if (GameMaster.gameMaster.numberOfUnlocks[0] + GameMaster.gameMaster.numberOfUnlocks[1] + GameMaster.gameMaster.numberOfUnlocks[2] + GameMaster.gameMaster.numberOfUnlocks[3] == 3)
        {
            costOfUnlocks = 8;
        }    
        if (GameMaster.gameMaster.numberOfUnlocks[0] + GameMaster.gameMaster.numberOfUnlocks[1] + GameMaster.gameMaster.numberOfUnlocks[2] + GameMaster.gameMaster.numberOfUnlocks[3] == 4)
        {
            costOfUnlocks = 9;
        }    
        if (GameMaster.gameMaster.numberOfUnlocks[0] + GameMaster.gameMaster.numberOfUnlocks[1] + GameMaster.gameMaster.numberOfUnlocks[2] + GameMaster.gameMaster.numberOfUnlocks[3] == 5)
        {
            costOfUnlocks = 10;
        }    
        if (GameMaster.gameMaster.numberOfUnlocks[0] + GameMaster.gameMaster.numberOfUnlocks[1] + GameMaster.gameMaster.numberOfUnlocks[2] + GameMaster.gameMaster.numberOfUnlocks[3] >= 6)
        {
            costOfUnlocks = 15;
        }

        newAmountCost = costOfUnlocks;

        for (int i = 0; i < 4; i++)
        {
            unlockCostText[i].text = "(" + costOfUnlocks + ")";
        }

        for (int i = 0; i < 4; i++)
        {     
            if (GameMaster.gameMaster.numberOfUnlocks[i] >= 5)
            {
                unlockProgressText[i].color = Color.black;
            }
            else
            {
                unlockProgressText[i].color = Color.red;
            }
        }


        Debug.Log("The current values from Game Master: " + GameMaster.gameMaster.numberOfUnlocks[0]);
        
        unlockProgressText[0].text = (GameMaster.gameMaster.numberOfUnlocks[0] + 1) + " MPH";
        unlockProgressText[1].text = (GameMaster.gameMaster.numberOfUnlocks[1] + 1) * 100 + " lbs";
        unlockProgressText[2].text = (GameMaster.gameMaster.numberOfUnlocks[2] + 1) * 1000 + " Thrust(N)";
        unlockProgressText[3].text = (5 - GameMaster.gameMaster.numberOfUnlocks[3]) + " seconds";

    }

    public void Add1ToSpeed()
    {
        speedToAdd+= .5f;
        GameMaster.gameMaster.numberOfUnlocks[0]++;
        boltsCount += newAmountCost;
    }

    public void Add1ToMass()
    {
        massToAdd += 5;
        GameMaster.gameMaster.numberOfUnlocks[1]++;
        boltsCount += newAmountCost;
    }

    public void Add1ToJumpHeight()
    {
        jumpHeightToAdd++;
        GameMaster.gameMaster.numberOfUnlocks[2]++;
        boltsCount += newAmountCost;
    }

    public void Add1ToPunchCooldown()
    {
        punchCooldownToAdd++;
        GameMaster.gameMaster.numberOfUnlocks[3]++; 
        boltsCount += newAmountCost;
    }

    public void FinalizePurchase()
    {
        if (boltsCount > GameMaster.gameMaster.boltsCollected)
        {

            notEnoughBoltsObject.SetActive(true);
            boltsCount = 0;
            GameMaster.gameMaster.Load();
        }
        else if (boltsCount == 0)
        {
            pleaseSelectAnUpgrade.SetActive(true);
        }
        else
        {
            areYouSureText.text = "Spend " + boltsCount + " bolts?";
            areYouSureObject.SetActive(true);
        }
    }

    public void UndoChanges()
    {
        GameMaster.gameMaster.Load();
        Application.LoadLevel("MainMenu");
    }

    public void OKButton()
    {
        anim.Play("RobotSad");
        notEnoughBoltsObject.SetActive(false);
    }

    public void OKButton2()
    {
        pleaseSelectAnUpgrade.SetActive(false);
    }

    public void Confirm()
    {
        
        areYouSureObject.SetActive(false);
        anim.Play("RobotCelebration");
        GameMaster.gameMaster.boltsCollected -= boltsCount;
        boltsCount = 0;
        boltsTotal = GameMaster.gameMaster.boltsCollected;
        boltsTotalText.text = "Total Bolts: " + boltsTotal;
        GameMaster.gameMaster.characterSpeeds[0] += speedToAdd;
        GameMaster.gameMaster.characterMass[0] += massToAdd;
        GameMaster.gameMaster.characterJumpHeight[0] += jumpHeightToAdd;
        GameMaster.gameMaster.characterPunchCooldown[0] += punchCooldownToAdd;
        //GameMaster.gameMaster.numberOfUnlocks[0] += numberOfUnlocksToAdd;
        GameMaster.gameMaster.Save();



    }

    public void Cancel()
    {
        anim.Play("RobotSad");
        boltsCount = 0;
        GameMaster.gameMaster.Load();
        areYouSureObject.SetActive(false);
    }

   
}
