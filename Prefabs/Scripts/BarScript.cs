using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {

	private float fillAmount;

	[SerializeField]
	private float lerpSpeed;

	[SerializeField]
	private Image content;

	[SerializeField]
	private Text valueText;

	[SerializeField]
	private Color fullColor;

	[SerializeField]
	private Color lowColor;

	[SerializeField]
	private bool lerpColors;

	public float MaxValue { get; set; }

	public float Value {
		set
        {
			    fillAmount = Map (value, 0, MaxValue, 0, 1);
		}
	}

	// Use this for initialization
	void Start () {
		if (lerpColors) {
			content.color = fullColor;
		}
	}
	
	// Update is called once per frame
	void Update () {
		HandleBar ();
	}

	private void HandleBar(){
		if (fillAmount != content.fillAmount) {	
			content.fillAmount = Mathf.Lerp (content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
            //content.fillAmount = (float)0.5;
        }
		if (lerpColors) {
			content.color = Color.Lerp (lowColor, fullColor, fillAmount);

		}
	}

    public void Reset()
    {
        Value = MaxValue;
        content.fillAmount = 1;
    }
	
	// in = real
	// out = range
	private float Map(float value, float inMin, float inMax, float outMin, float outMax){
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
		//(80 - 0) * (1 - 0) / (100 - 0) + 0
		//80 * 1 / 100 = 0,8
	}
}
