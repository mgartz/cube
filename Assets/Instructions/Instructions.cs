using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Instructions : MonoBehaviour {

	public Text lflText;
	public Text lfmText;
	public Text lfrText;
	public Text lcText;
	public Text rflText;
	public Text rfmText;
	public Text rfrText;
	public Text rcText;
	public Text hcText;

	public Image lflImage;
	public Image lfmImage;
	public Image lfrImage;
	public Image lcImage;
	public Image rflImage;
	public Image rfmImage;
	public Image rfrImage;
	public Image rcImage;
	public Image hcImage;

	public Sprite lflaSprite;
	public Sprite lflbSprite;
	public Sprite lfmaSprite;
	public Sprite lfmbSprite;
	public Sprite lfraSprite;
	public Sprite lfrbSprite;
	public Sprite lcaSprite;
	public Sprite lcbSprite;
	public Sprite rflaSprite;
	public Sprite rflbSprite;
	public Sprite rfmaSprite;
	public Sprite rfmbSprite;
	public Sprite rfraSprite;
	public Sprite rfrbSprite;
	public Sprite rcaSprite;
	public Sprite rcbSprite;
	public Sprite hcaSprite;
	public Sprite hcbSprite;

	int countShiftDown = 0;
	int lastCountShiftDown = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UpdateShiftState();
		if ((countShiftDown > 0 && lastCountShiftDown == 0) || (countShiftDown == 0 && lastCountShiftDown > 0)){
			UpdateUIForShiftChange();
		}
	}

	void UpdateShiftState(){
		if (Input.GetKeyDown(KeyCode.LeftShift))
			countShiftDown++;
		if (Input.GetKeyDown(KeyCode.RightShift))
			countShiftDown++;
		if (Input.GetKeyUp(KeyCode.LeftShift))
			countShiftDown--;
		if (Input.GetKeyUp(KeyCode.RightShift))
			countShiftDown--;
	}

	void UpdateUIForShiftChange(){
		lastCountShiftDown = countShiftDown;
		if (lastCountShiftDown == 0){
			lflImage.sprite = lflaSprite;
			lfmImage.sprite = lfmaSprite;
			lfrImage.sprite = lfraSprite;
			lcImage.sprite = lcaSprite;
			
			rflImage.sprite = rflaSprite;
			rfmImage.sprite = rfmaSprite;
			rfrImage.sprite = rfraSprite;
			rcImage.sprite = rcaSprite;
			
			hcImage.sprite = hcaSprite;
		}
		else {
			lflImage.sprite = lflbSprite;
			lfmImage.sprite = lfmbSprite;
			lfrImage.sprite = lfrbSprite;
			lcImage.sprite = lcbSprite;
			
			rflImage.sprite = rflbSprite;
			rfmImage.sprite = rfmbSprite;
			rfrImage.sprite = rfrbSprite;
			rcImage.sprite = rcbSprite;
			
			hcImage.sprite = hcbSprite;
		}
	}
}
