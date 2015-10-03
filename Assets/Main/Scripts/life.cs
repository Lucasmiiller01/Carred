using UnityEngine;
using System.Collections;

public class life : MonoBehaviour {
	private float speed2 = -12;
	private float speed3 = -26;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (IA.Delay_atack == 1) {
						transform.transform.localScale += (Vector3.right * speed2 * Time.deltaTime);
						transform.position += (Vector3.right * speed3 * Time.deltaTime);
		}

	}
}
