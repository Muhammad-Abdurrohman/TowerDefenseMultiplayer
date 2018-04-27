using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour {

    //[SerializeField]
    //private Stat health;

    public float startHP;
    public float health;

    [Header("Unity Stuff")]
    public Image healthBar;

    private Animator myAnimator;

    //Cara untuk instantiate antar scripts
    private static Tower instance;

    public static Tower Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Tower>();
            }

            return instance;
        }
    }

    void Awake()
    {
        //health.Initialize();
    }

    // Use this for initialization
    void Start () {
        health = startHP;
        healthBar.fillAmount = 1;
        myAnimator = gameObject.GetComponent<Animator>();
        //Spawn(HP);
        //Debug.Log(health.MaxVal);
        //Debug.Log(health.CurrentVal);
    }
	
	// Update is called once per frame
	void Update () {
        checkLive();
	}
    
    public void Spawn(float health)
    {
        //this.health.Bar.Reset();
        //this.health.MaxVal = HP;
        //this.health.CurrentVal = this.health.MaxVal;
    }

    public void TakeDamage(float damage)
    {
        /*Debug.Log(health.CurrentVal);
        Debug.Log(damage);
        health.CurrentVal -= damage;
        Debug.Log(health.CurrentVal);
        if (health.CurrentVal <= 0)
        {
            //myAnimator.SetTrigger("Die");
        }
        */
        health -= damage;
        Debug.Log(health);
        healthBar.fillAmount = health/100f;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Hero1" || other.gameObject.tag == "Hero6" || other.gameObject.tag == "Hero11")
        {
            this.health = this.health - 5;
            Debug.Log(health);
            this.healthBar.fillAmount -= 5 / 100f;
        }

        else if (other.gameObject.tag == "Hero2" || other.gameObject.tag == "Hero7" || other.gameObject.tag == "Hero12")
        {
            this.health = this.health - (float)7.5;
            Debug.Log(health);
            this.healthBar.fillAmount -= (float)7.5 / 100f;
        }

        else if (other.gameObject.tag == "Hero3" || other.gameObject.tag == "Hero8" || other.gameObject.tag == "Hero13")
        {
            this.health = this.health - 10;
            Debug.Log(health);
            this.healthBar.fillAmount -= 10 / 100f;
        }

        else if (other.gameObject.tag == "Hero4" || other.gameObject.tag == "Hero9" || other.gameObject.tag == "Hero14")
        {
            this.health = this.health - 20;
            Debug.Log(health);
            this.healthBar.fillAmount -= 20 / 100f;
        }

        else if (other.gameObject.tag == "Hero5" || other.gameObject.tag == "Hero10" || other.gameObject.tag == "Hero15")
        {
            this.health = this.health - 20;
            Debug.Log(health);
            this.healthBar.fillAmount -= 20 / 100f;
        }
    }

    public void checkLive()
    {
        if (this.health <= 0)
        {
            myAnimator.SetBool("die", true);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
