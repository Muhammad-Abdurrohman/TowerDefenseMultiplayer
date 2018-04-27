using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

//Delegate for the currency changed event
public delegate void CurrencyChanged();

public class GameManager : NetworkBehaviour{

    //An event that is triggered when the currency changes
    public event CurrencyChanged Changed;

    [SerializeField]
    private int currency;

    [SerializeField]
    private Text currencyTxt;

    public HeroButton ClickedBtn { get; set; }

    public int Currency
    {
        get
        {
            return currency;
        }

        set
        {
            this.currency = value;
            this.currencyTxt.text = value.ToString() + "/200";

            OnCurrencyChanged();
        }
    }

    int interval = 1;
    float nextTime = 0;

    public int flagHere;
    public int arah;
    public int kubu;
    public Vector3 pos;
    public Vector3 rot;

    public GameObject UIPlayer1;
    public GameObject UIPlayer2;
    public GameObject UIPlayer3;
    public GameObject GameOverCanvas;
    public Text GameOverText;

    public GameObject Dir1;
    public GameObject Dir2;
    public GameObject Dir3;
    public GameObject Dir4;
    public GameObject Dir5;
    public GameObject Dir6;

    public GameObject Purple;
    public GameObject Blue;
    public GameObject Green;
    public GameObject Red;
    public GameObject Yellow;

    public GameObject Tower1;
    public GameObject Tower2;
    public GameObject Tower3;

    public int liveTower1;
    public int liveTower2;
    public int liveTower3;

    //Cara untuk instantiate antar scripts
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }

            return instance;
        }
    }

    // Use this for initialization
    void Start () {        
        Currency = currency;
        liveTower1 = 1; liveTower3 = 1; liveTower2 = 1;
    }

    // Update is called once per frame
    void Update()
    {
        HandleEscape();
        if (Time.time >= nextTime && Currency < 200)
        {
            Currency += 10;
            nextTime += interval;
        }

        checkTower1();
        checkTower2();
        checkTower3();
        checkGameOver();
    }

    public void PickHero(HeroButton heroButton)
    {
        if (Currency >= heroButton.Price)
        {
            this.ClickedBtn = heroButton;
            Hover.Instance.Activate(heroButton.Sprite);
            flagHere = heroButton.Flag;
            if (kubu == 1)
            {
                Dir1.SetActive(true);
                Dir2.SetActive(true);

                if (liveTower2 == 0)
                    Dir1.SetActive(false);
                if (liveTower3 == 0)
                    Dir2.SetActive(false);
            }

            else if (kubu == 2)
            {
                Dir3.SetActive(true);
                Dir4.SetActive(true);

                if (liveTower1 == 0)
                    Dir3.SetActive(false);
                if (liveTower3 == 0)
                    Dir4.SetActive(false);
            }

            else if (kubu == 3)
            {
                Dir5.SetActive(true);
                Dir6.SetActive(true);

                if (liveTower1 == 0)
                    Dir5.SetActive(false);
                if (liveTower2 == 0)
                    Dir6.SetActive(false);
            }

        }
    }

    [Command]
    public void CmdBuyHero(int Arah)
    {
        if (Currency >= ClickedBtn.Price)
        {
            Currency -= ClickedBtn.Price;
            Hover.Instance.Deactivate();
            Dir1.SetActive(false);
            Dir2.SetActive(false);
            Dir3.SetActive(false);
            Dir4.SetActive(false);
            Dir5.SetActive(false);
            Dir6.SetActive(false);
            
            arah = Arah;
        }

        Spawner.Instance.CmdSpawn();
    }

    public void Kubu(int kkubu)
    {
        kubu = kkubu;
    }

    public void OnCurrencyChanged()
    {
        if (Changed != null)
        {
            Changed();
        }
    }

    private void HandleEscape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Hover.Instance.Deactivate();

            Dir1.SetActive(false);
            Dir2.SetActive(false);
            Dir3.SetActive(false);
            Dir4.SetActive(false);
            Dir5.SetActive(false);
            Dir6.SetActive(false);
        }
    }

    public void checkTower1()
    {
        if (Tower1.GetComponent<BoxCollider2D>().enabled == false)
        {
            liveTower1 = 0;
            //Debug.Log("Tower 1 has been destroyed");
            UIPlayer1.SetActive(false);

        }
    }

    public void checkTower2()
    {
        if (Tower2.GetComponent<BoxCollider2D>().enabled == false)
        {
            liveTower2 = 0;
            //Debug.Log("Tower 2 has been destroyed");
            UIPlayer2.SetActive(false);
        }
    }

    public void checkTower3()
    {
        if (Tower3.GetComponent<BoxCollider2D>().enabled == false)
        {
            liveTower3 = 0;
            //Debug.Log("Tower 3 has been destroyed");
            UIPlayer3.SetActive(false);
        }
    }

    public void checkGameOver()
    {
        if (liveTower2 == 0 && liveTower3 == 0)
        {
            //Time.timeScale = 0;
            GameOverCanvas.SetActive(true);
            GameOverText.text = "Game Over!" + '\n' +"Player 1 Winner";
        }

        else if (liveTower1 == 0 && liveTower3 == 0)
        {
            //Time.timeScale = 0;
            GameOverCanvas.SetActive(true);
            GameOverText.text = "Game Over!" + '\n' + " Player 2 Winner";
        }

        else if (liveTower1 == 0 && liveTower2 == 0)
        {
            //Time.timeScale = 0;
            GameOverCanvas.SetActive(true);
            GameOverText.text = "Game Over!" + '\n' + " Player 3 Winner";
        }
    }
}
