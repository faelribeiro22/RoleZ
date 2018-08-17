using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Text pontuacao;
	public int pontos;



	// Use this for initialization
	void Start () {
		pontuacao.text = "Teste pontos";

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		pontuacao.text = pontos.ToString ();
	}

}
