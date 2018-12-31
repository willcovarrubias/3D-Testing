using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LaserController : MonoBehaviour {

    public Transform parentObject;
    public Transform firePoint;
    Animator anim;

    public float xPos = -.5f;
    public float yPos = 0;
    public float zPos = 0;

    private bool phase3LaserGoing = false;
    private bool phase6LaserGoing = false;
    private bool phase8LaserGoing = false;
    private bool phase9LaserGoing = false;
    private bool phase10LaserGoing = false;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        //StartCoroutine(ShootLaser());
        //phase3LaserGoing = false;

	}
	
	// Update is called once per frame
	void Update () {
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase3  && !phase3LaserGoing)
        {
            StartCoroutine(ShootLaser(3));
        }

        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase6 && !phase6LaserGoing)
        {
            StartCoroutine(ShootLaser(6));
        }

        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase8 && !phase8LaserGoing)
        {
            StartCoroutine(ShootLaser(8));
        }

        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase9 && !phase9LaserGoing)
        {
            StartCoroutine(ShootLaser(9));
        }

        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase10 && !phase10LaserGoing)
        {
            StartCoroutine(ShootLaser(10));
        }

    }

    IEnumerator ShootLaser(int laserName)
    {
        if (laserName == 3)
        {
            phase3LaserGoing = true;
        }

        if (laserName == 6)
        {
            phase6LaserGoing = true;
        }

        if (laserName == 8)
        {
            phase8LaserGoing = true;
        }

        if (laserName == 9)
        {
            phase9LaserGoing = true;
        }

        if (laserName == 10)
        {
            phase10LaserGoing = true;
        }


        Debug.Log("Checking how many times the laser was fired!*************");
        StartCoroutine(PickRowToAppear());
        GameObject laser = Instantiate(Resources.Load("Projectiles/Laser"), new Vector3(firePoint.transform.position.x - 5.6f, firePoint.transform.position.y, firePoint.transform.position.z), Quaternion.Euler(0, 0, 90)) as GameObject;
        laser.transform.parent = parentObject;
        yield return new WaitForSeconds(15);
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase3)
        {
            StartCoroutine(ShootLaser(3));
        }

        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase6)
        {
            StartCoroutine(ShootLaser(6));
        }

        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase8)
        {
            StartCoroutine(ShootLaser(8));
        }

        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase9)
        {
            StartCoroutine(ShootLaser(9));
        }

        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase10)
        {
            StartCoroutine(ShootLaser(10));
        }
    }

    IEnumerator PickRowToAppear()
    {
        List<int> listToChooseFrom = new List<int>();
        for (int i = 0; i < 6; i++)
        {
            if (GameMaster.gameMaster.rowsWithPlatforms[i] == true)
            {
                listToChooseFrom.Add(i);
            }
        }

        System.Random ran = new System.Random();
        int myNum = listToChooseFrom[ran.Next(listToChooseFrom.Count())];
        

        if (myNum == 0)
        {
            //transform.Translate(new Vector3(5,1,0));
            parentObject.localPosition = new Vector3(xPos, yPos, zPos + 1);
        }
        if (myNum == 1)
        {
            //transform.Translate(new Vector3(5, 1, -1));
            parentObject.localPosition = new Vector3(xPos, yPos, zPos + 0);
        }
        if (myNum == 2)
        {
            //transform.Translate(new Vector3(5, 1, -2));
            parentObject.localPosition = new Vector3(xPos, yPos, zPos + -1);
        }
        if (myNum == 3)
        {
            //transform.Translate(new Vector3(5, 1, -3));
            parentObject.localPosition = new Vector3(xPos, yPos, zPos + -2);
        }
        if (myNum == 4)
        {
            // transform.Translate(new Vector3(5, 1, -4));
            parentObject.localPosition = new Vector3(xPos, yPos, zPos + -3);
        }
        if (myNum == 5)
        {
            parentObject.localPosition = new Vector3(xPos, yPos, zPos + -4);
        }

        anim.SetBool("ShootLaser", true);
        yield return new WaitForSeconds(9);
        anim.SetBool("ShootLaser", false);
        parentObject.localPosition = new Vector3(xPos, yPos + 20, zPos + -4);

    }
}
