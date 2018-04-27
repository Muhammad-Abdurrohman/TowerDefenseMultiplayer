using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Hero : MonoBehaviour {
    public float cost;
    //public float HP;
    public float startSpeed;
    public float speed;
    public float power;
    public float cooldown;
    public Vector3 direction;
    public int kubu;

    public int goo;

    public float startHP;
    
    public float health;

    [Header("Unity Stuff")]
    public Image healthBar;

    private Vector3 direction1 = new Vector3(1, 0, 0);
    private Vector3 direction2 = new Vector3((float)0.4, (float)0.5, 0);
    private Vector3 direction3 = new Vector3(-1, 0, 0);
    private Vector3 direction4 = new Vector3((float)-0.4, (float)0.5, 0);
    private Vector3 direction5 = new Vector3((float)-0.4, (float)-0.5, 0);
    private Vector3 direction6 = new Vector3((float)0.45, (float)-0.5, 0);
    
    private Animator myAnimator;

    // Use this for initialization
    void Start () {
        myAnimator = gameObject.GetComponent<Animator>();
        goo = GameManager.Instance.arah;
        gogo();

        health = startHP;
    }

	// Update is called once per frame
	void Update () {
        //if (PauseMenu.IsOn)
        //    return;
        
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tower")
        {
            Debug.Log("Collided");
            myAnimator.SetBool("die", true);
            speed = 0;
            //Tower.Instance.TakeDamage(power);
            //target1.TakeDamage(power);
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject,1);
        }

        if (this.gameObject.tag == "Hero1" || this.gameObject.tag == "Hero2" || this.gameObject.tag == "Hero3" || this.gameObject.tag == "Hero4" || this.gameObject.tag == "Hero5")
        { 
            if (other.gameObject.tag == "Hero6" || other.gameObject.tag == "Hero11")
            {
                GetComponent<BoxCollider2D>().enabled = false;
                health = health - 10;
                this.healthBar.fillAmount -= 10 / startHP;
                speed = 0;
                isAlive();
            }

            else if (other.gameObject.tag == "Hero7" || other.gameObject.tag == "Hero12")
            {
                GetComponent<BoxCollider2D>().enabled = false;
                health = health - 15;
                this.healthBar.fillAmount -= 20 / startHP;
                speed = 0;
                isAlive();
            }

            else if (other.gameObject.tag == "Hero8" || other.gameObject.tag == "Hero13")
            {
                GetComponent<BoxCollider2D>().enabled = false;
                health = health - 20;
                this.healthBar.fillAmount -= 20 / startHP;
                speed = 0;
                isAlive();
            }

            else if (other.gameObject.tag == "Hero9" || other.gameObject.tag == "Hero14")
            {
                GetComponent<BoxCollider2D>().enabled = false;
                health = health - 40;
                this.healthBar.fillAmount -= 40 / startHP;
                speed = 0;
                isAlive();
            }

            else if (other.gameObject.tag == "Hero10" || other.gameObject.tag == "Hero15")
            {
                GetComponent<BoxCollider2D>().enabled = false;
                health = health - 40;
                this.healthBar.fillAmount -= 40 / startHP;
                speed = 0;
                isAlive();
            }
        }

        else if (this.gameObject.tag == "Hero6" || this.gameObject.tag == "Hero7" || this.gameObject.tag == "Hero8" || this.gameObject.tag == "Hero9" || this.gameObject.tag == "Hero10")
        {
            if (other.gameObject.tag == "Hero1" || other.gameObject.tag == "Hero11")
            {
                GetComponent<BoxCollider2D>().enabled = false;
                health = health - 10;
                this.healthBar.fillAmount -= 10 / startHP;
                speed = 0;
                isAlive();
            }

            else if (other.gameObject.tag == "Hero2" || other.gameObject.tag == "Hero12")
            {
                GetComponent<BoxCollider2D>().enabled = false;
                health = health - 15;
                this.healthBar.fillAmount -= 15 / startHP;
                speed = 0;
                isAlive();
            }

            else if (other.gameObject.tag == "Hero3" || other.gameObject.tag == "Hero13")
            {
                GetComponent<BoxCollider2D>().enabled = false;
                health = health - 20;
                this.healthBar.fillAmount -= 20 / startHP;
                speed = 0;
                isAlive();
            }

            else if (other.gameObject.tag == "Hero4" || other.gameObject.tag == "Hero14")
            {
                GetComponent<BoxCollider2D>().enabled = false;
                health = health - 40;
                this.healthBar.fillAmount -= 40 / startHP;
                speed = 0;
                isAlive();
            }

            else if (other.gameObject.tag == "Hero5" || other.gameObject.tag == "Hero15")
            {
                GetComponent<BoxCollider2D>().enabled = false;
                health = health - 40;
                this.healthBar.fillAmount -= 40 / startHP;
                speed = 0;
                isAlive();
            }
        }

        else if (this.gameObject.tag == "Hero11" || this.gameObject.tag == "Hero12" || this.gameObject.tag == "Hero13" || this.gameObject.tag == "Hero14" || this.gameObject.tag == "Hero15")
        {
            if (other.gameObject.tag == "Hero1" || other.gameObject.tag == "Hero6")
            {
                GetComponent<BoxCollider2D>().enabled = false;
                health = health - 10;
                this.healthBar.fillAmount -= 10 / startHP;
                speed = 0;
                isAlive();
            }

            else if (other.gameObject.tag == "Hero2" || other.gameObject.tag == "Hero7")
            {
                GetComponent<BoxCollider2D>().enabled = false;
                health = health - 15;
                this.healthBar.fillAmount -= 15 / startHP;
                speed = 0;
                isAlive();
            }

            else if (other.gameObject.tag == "Hero3" || other.gameObject.tag == "Hero8")
            {
                GetComponent<BoxCollider2D>().enabled = false;
                health = health - 20;
                this.healthBar.fillAmount -= 20 / startHP;
                speed = 0;
                isAlive();
            }

            else if (other.gameObject.tag == "Hero4" || other.gameObject.tag == "Hero9")
            {
                GetComponent<BoxCollider2D>().enabled = false;
                health = health - 40;
                this.healthBar.fillAmount -= 40 / startHP;
                speed = 0;
                isAlive();
            }

            else if (other.gameObject.tag == "Hero5" || other.gameObject.tag == "Hero10")
            {
                GetComponent<BoxCollider2D>().enabled = false;
                health = health - 40;
                this.healthBar.fillAmount -= 40 / startHP;
                speed = 0;
                isAlive();
            }
        }
        //isAlive();
    }

    public void isAlive()
    {
        if (health <= 0)
        {
            myAnimator.SetBool("die", true);
            Destroy(gameObject, 1);
        }
        else
        {
            speed = startSpeed;
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    public void gogo()
    {
        if (goo == 1)
        {
            direction = direction1;
        }

        else if (goo == 2)
        {
            direction = direction2;
        }

        else if (goo == 3)
        {
            direction = direction3;
        }

        else if (goo == 4)
        {
            direction = direction4;
        }

        else if (goo == 5)
        {
            direction = direction5;
        }

        else if (goo == 6)
        {
            direction = direction6;
        }
    }
}