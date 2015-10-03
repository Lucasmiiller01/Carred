using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public GameObject arrow1;
	public GameObject arrow2;
	
	private bool option;
	private bool canPress;
	
	// Use this for initialization
	void Start () {
		option = true;
		canPress = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (option) {
			arrow1.active = true;
			arrow2.active = false;
		} else {
			arrow1.active = false;
			arrow2.active = true;
		}
		
		if(Input.GetAxisRaw("Vertical") != 0 && canPress == true){
			if(option){
				option = false;
			}else{
				option = true;
			}
			canPress = false;
		}
		if(Input.GetAxisRaw("Vertical") == 0){
			canPress = true;
		}
		
		if(option){
			if(Input.GetKeyDown("return")){
				//Application.LoadLevel("Fase1");
			}
		}else{
			if(Input.GetKeyDown("return")){
				Application.Quit();
			}
		}
		
	}
}
