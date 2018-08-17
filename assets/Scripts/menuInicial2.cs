using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class menuInicial2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetButtonDown("Jump"))
        {
            StartGame();
        }
	}

	public void StartGame(){
        SceneManager.LoadScene("Fase01");
    }
}
