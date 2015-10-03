using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private bool press_d = false;
	private bool press_a = false;
	private float velocidade = 2;


	public GUIStyle style;

	int wait = 0;

	public string grabd = "";
	string willgrab = ""; 	
	bool isgrabbing = false;


	
	/*public static bool activePause;
	public static bool canControl;

	public static bool interact;
	public static bool canInteract;*/	


	public GameObject HandPoint;

	private GameObject item;
	public static string itemName;
	private bool withItem;
	private bool canLeftItem;

	private GameObject itemTarget;

	public static Animator animator;
	//identificar nome do item
	public void setItemGrab(int whattodo, string item)
	{
		switch(whattodo)
		{
			case 1:
			willgrab = item;
			isgrabbing = true;
			break;
			case 2:
			isgrabbing = false;
			willgrab = "";
			break;
			case 3:
			isgrabbing = false;
			willgrab = "";
			grabd = item;
			wait = 15;
			break;
		}
	}


	void Start () {

		withItem = false;
		canLeftItem = true;


	}
	
	// Update is called once per frame
	void Update () {
		IA.posicao_player = transform.position.x ;
		Move ();

			
		if(wait > 0){wait --;}
	}
		



	// texto para drop item + nome do item
	void OnGUI()
	{
		if(isgrabbing == true )
		{
			GUI.Label (new Rect(0,Screen.height*0.05f,Screen.width,Screen.height*0.05f),"Press E to drop the "+grabd,style);
		}

	}

	
	void Move() {

		if(Input.GetKeyDown(KeyCode.D))press_d = true;
		if(Input.GetKeyUp(KeyCode.D)){press_d = false;rigidbody2D.velocity = new Vector2(0,0);}
		if(Input.GetKeyDown(KeyCode.A))press_a = true;
		if(Input.GetKeyUp(KeyCode.A)){press_a = false;rigidbody2D.velocity = new Vector2(0,0);}
		if(Input.GetKeyDown(KeyCode.LeftShift))velocidade = 4;if(Input.GetKeyUp(KeyCode.LeftShift))velocidade = 2;
		if(press_d)rigidbody2D.velocity = new Vector2(velocidade,0);
		if(press_a)rigidbody2D.velocity = new Vector2(-velocidade,0);

	
		
			// para o item ficar na posiçao certa
			if(HandPoint.transform.localPosition.x < 0){
				
				HandPoint.transform.localPosition = new Vector3(-HandPoint.transform.localPosition.x, HandPoint.transform.localPosition.y, HandPoint.transform.localPosition.z);
			}
		
	
			if(HandPoint.transform.localPosition.x > 0){
				
				HandPoint.transform.localPosition = new Vector3(-HandPoint.transform.localPosition.x, HandPoint.transform.localPosition.y, HandPoint.transform.localPosition.z);
			}

		if(withItem){
			setItemGrab (3, itemName);
			if(Input.GetKey("e") && canLeftItem){
				item.transform.parent = null;
				item = null;
				itemName = null;
				withItem = false;
			}
			if(Input.GetKeyUp("e")){
				canLeftItem = true;
				setItemGrab (3, "");
			}
		}



	}

	void OnTriggerStay2D(Collider2D coll){
		if(coll.tag == "Item" && !withItem){
			setItemGrab (1, coll.name);

			itemTarget = coll.gameObject;

			if(Input.GetKey(KeyCode.E)){
				item = coll.gameObject;

				itemName = coll.name;
				withItem = true;

				item.transform.parent = HandPoint.transform;
				item.transform.localPosition = Vector3.zero;

				canLeftItem = false;

			}

		}
		
		

		}

	
	void OnTriggerExit2D(Collider2D coll)
	{
		setItemGrab (2, "");
	}
}