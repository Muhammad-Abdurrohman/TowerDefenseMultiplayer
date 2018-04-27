using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroButton : MonoBehaviour {

    [SerializeField]
    private GameObject heroPrefab;

    [SerializeField]
    private Sprite sprite;

    [SerializeField]
    private int price;

    [SerializeField]
    private Text priceTxt;

    [SerializeField]
    private int flag;

    public GameObject HeroPrefab
    {
        get
        {
            return heroPrefab;
        }
    }

    public Sprite Sprite
    {
        get
        {
            return sprite;
        }
    }

    public int Price
    {
        get
        {
            return price;
        }
    }

    public int Flag
    {
        get
        {
            return flag;
        }
    }

    //Cara untuk instantiate antar scripts
    private static HeroButton instance;

    public static HeroButton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<HeroButton>();
            }

            return instance;
        }
    }

    private void Start()
    {
        priceTxt.text = Price + "";
        GameManager.Instance.Changed += new CurrencyChanged(PriceCheck);
    }

    private void PriceCheck()
    {
        if (price <= GameManager.Instance.Currency)
        {
            GetComponent<Image>().color = Color.white;
            GetComponent<Button>().interactable = true;
            priceTxt.color = Color.white;

        }

        else
        {
            //GetComponent<Image>().color = Color.grey;
            GetComponent<Button>().interactable = false;
            priceTxt.color = Color.grey;
        }
    }
}
