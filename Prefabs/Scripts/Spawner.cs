using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spawner : NetworkBehaviour {

    public GameObject Purple;
    public GameObject Blue;
    public GameObject Green;
    public GameObject Red;
    public GameObject Yellow;

    public int flag;
    public int kubu;
    public int arah;
    public Vector3 pos;

    //Cara untuk instantiate antar scripts
    private static Spawner instance;

    public static Spawner Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Spawner>();
            }

            return instance;
        }
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    [Command]
    public void CmdSpawn()
    {
        flag = GameManager.Instance.flagHere;
        kubu = GameManager.Instance.kubu;
        arah = GameManager.Instance.arah;

        if (arah == 1)
            pos = new Vector3(-4, -4, 0);
        else if (arah == 2)
            pos = new Vector3(-4, (float)-2.5, 0);
        else if (arah == 3)
            pos = new Vector3(4, -4, 0);
        else if (arah == 4)
            pos = new Vector3(4, (float)-2.5, 0);
        else if (arah == 5)
            pos = new Vector3(-1, (float)1.3, 0);
        else if (arah == 6)
            pos = new Vector3(1, (float)1.3, 0);

        if (flag == 1)
        {
            GameObject aPurple = (GameObject)Instantiate(Purple);
            aPurple.transform.position = pos;
            if (kubu == 1)
                aPurple.gameObject.tag = "Hero1";
            else if (kubu == 2)
                aPurple.gameObject.tag = "Hero6";
            else if (kubu == 3)
                aPurple.gameObject.tag = "Hero11";

            NetworkServer.Spawn(aPurple);
        }

        else if (flag == 2)
        {
            GameObject aBlue = (GameObject)Instantiate(Blue);
            aBlue.transform.position = pos;
            if (kubu == 1)
                aBlue.gameObject.tag = "Hero2";
            else if (kubu == 2)
                aBlue.gameObject.tag = "Hero7";
            else if (kubu == 3)
                aBlue.gameObject.tag = "Hero12";

            NetworkServer.Spawn(aBlue);
        }

        else if (flag == 3)
        {
            GameObject aGreen = (GameObject)Instantiate(Green);
            aGreen.transform.position = pos;
            if (kubu == 1)
                aGreen.gameObject.tag = "Hero3";
            else if (kubu == 2)
                aGreen.gameObject.tag = "Hero8";
            else if (kubu == 3)
                aGreen.gameObject.tag = "Hero13";

            NetworkServer.Spawn(aGreen);
        }

        else if (flag == 4)
        {
            GameObject aRed = (GameObject)Instantiate(Red);
            aRed.transform.position = pos;
            if (kubu == 1)
                aRed.gameObject.tag = "Hero4";
            else if (kubu == 2)
                aRed.gameObject.tag = "Hero9";
            else if (kubu == 3)
                aRed.gameObject.tag = "Hero14";

            NetworkServer.Spawn(aRed);
        }

        else if (flag == 5)
        {
            GameObject aYellow = (GameObject)Instantiate(Yellow);
            aYellow.transform.position = pos;
            if (kubu == 1)
                aYellow.gameObject.tag = "Hero5";
            else if (kubu == 2)
                aYellow.gameObject.tag = "Hero10";
            else if (kubu == 3)
                aYellow.gameObject.tag = "Hero15";

            NetworkServer.Spawn(aYellow);
        }


    }

}
