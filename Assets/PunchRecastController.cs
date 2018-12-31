using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchRecastController : MonoBehaviour {

    private float curTimeTilPunch = 100;
        private float maxTimeTilPunch = 100;
    GameObject punchRecastBar;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float calculatedTimeTilAbleToPunch = curTimeTilPunch / maxTimeTilPunch;
        SetBossHealthBar(calculatedTimeTilAbleToPunch);
    }

    public void SetBossHealthBar(float timeTilPunch)
    {
        punchRecastBar.transform.localScale = new Vector3(timeTilPunch, punchRecastBar.transform.localScale.y, punchRecastBar.transform.localScale.z);
        punchRecastBar.transform.localScale = new Vector3(Mathf.Clamp(timeTilPunch, 0f, 1f), punchRecastBar.transform.localScale.y, punchRecastBar.transform.localScale.z);

    }   
}
