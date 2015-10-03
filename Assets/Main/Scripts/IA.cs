using UnityEngine;
using System.Collections;

public class IA : MonoBehaviour {
	public static float posicao_player;
	public float dano_tomado = 100;
	private float speed = -1;
	public float lose_life = 0;
	public string range_zombie;

	//bool delay = false
	public static float Delay_atack = 0;


	// Use this for initialization
	void Start () {
	
	
	}
	
	// Update is called once per frame
	void Update () {
		switch (range_zombie) {
			
		case "left":
		{

			
			transform.position += (Vector3.right * speed * Time.deltaTime);
			
		}
			break;
			
		case "rigth":
		{
			
			
			transform.position += (Vector3.right * -speed * Time.deltaTime);
			
		}
			break;
			
			
		}
		
		
		if (transform.position.x < posicao_player + 1)
			range_zombie = "left";
		 if (transform.position.x < posicao_player -1)
			range_zombie = "rigth";


		if (transform.position.x <= posicao_player + 1.5 ) {
			Delay_atack += 1;
				
		}

		if (lose_life == 5)Delay_atack = 0;

		if (Delay_atack == 200 && lose_life <= 4) {
				dano_tomado -= 20;
			lose_life += 1;
		}
	


		if (Delay_atack >= 200) {
			Delay_atack = 0;
		}




		
				
	
	}
}
