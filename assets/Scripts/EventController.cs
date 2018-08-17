using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EventController : MonoBehaviour {


	public Player Player;


	// Use this for initialization
	void Start () {

		Player = FindObjectOfType (typeof(Player)) as Player;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}
	public void AtivarZapi(){
		Player.Zapi = true;
		Player.Amigo.SetActive (true);
		Debug.Log ("teste");
	}
}
