using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour {

    private SpriteRenderer spriteRenderer;

    //Cara untuk instantiate antar scripts
    private static Hover instance;

    public static Hover Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Hover>();
            }

            return instance;
        }
    }

    // Use this for initialization
    void Start () {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        FollowMouse();
	}

    private void FollowMouse()
    {
        if (spriteRenderer.enabled)
        {
            transform.localScale = new Vector3((float)0.45, (float)0.45, 1);
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }

    public void Activate(Sprite sprite)
    {
        this.spriteRenderer.sprite = sprite;
        spriteRenderer.enabled = true;
    }

    public void Deactivate()
    {
        spriteRenderer.enabled = false;
        GameManager.Instance.ClickedBtn = null;
    }
}
