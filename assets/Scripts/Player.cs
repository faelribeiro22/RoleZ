using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float jumpForce;
    public BoxCollider2D colliderChao;
    public bool jump;
    public Transform GroundCheck;
	public bool grounded;
    public Rigidbody2D RbPlayer;
    public bool wallCheck;
    public Animator anime;
	public LayerMask WhatIsGround;
	public bool doubleJump;
	public float tempo;
	public GameObject objetoInteracao;
	public GameObject objetoZapi;
	public GameObject IconeZapiAtivo;
	public GameObject IconeZapiDesativado;
	public GameObject Amigo;
	public bool Zapi;
	private GameObject obstaculo;

	public UIController UIController;


    //Audio
    public AudioSource audio;
    public AudioClip soundJump;
    public AudioClip soundMorte;
	public AudioClip soundZapi;
	public AudioClip soundLike;

	// Use this for initialization
	void Start () {
		tempo = 0;
		IconeZapiAtivo.SetActive (false);
		Amigo.SetActive (false);
		Zapi = false;

		UIController = FindObjectOfType (typeof(UIController)) as UIController;

	}
	
	// Update is called once per frame
	void Update () {
		tempo += Time.deltaTime;
		if(objetoInteracao != null){
			//Debug.Log ("objetoInteracao.SendMessage");
			objetoInteracao.SendMessage ("interacao",SendMessageOptions.DontRequireReceiver);
		}
		if(objetoZapi != null){
			//Debug.Log ("objetoZapi.SendMessage");
			objetoZapi.SendMessage ("interacaoZapi",SendMessageOptions.DontRequireReceiver);
			IconeZapiAtivo.SetActive (true);
			IconeZapiDesativado.SetActive (false);
		}
		if (tempo >= 20) {
			if ((UIController.pontos >= 5) && (SceneManager.GetActiveScene().name == "Fase01")) {
				SceneManager.LoadScene("Fase02");
			}
			if ((UIController.pontos >= 5) && (SceneManager.GetActiveScene().name == "Fase02")) {
				SceneManager.LoadScene("Fase03");
			}
			if (UIController.pontos < 5) {
				SceneManager.LoadScene("RIP");
			}
        }
		anime.SetBool("jump", !grounded);
		anime.SetBool ("grounded", grounded);
		grounded = Physics2D.OverlapCircle (GroundCheck.position, 0.2f, WhatIsGround);
		if (grounded == true) {
			doubleJump = false;
		}
		if (Input.GetButtonDown ("Jump") && (grounded || !doubleJump)) {
			//Debug.Log ("Pulei!");
            audio.volume = 1;
            audio.PlayOneShot(soundJump);
			RbPlayer.velocity = new Vector2 (0, 0);
			RbPlayer.AddForce (new Vector2 (0, jumpForce));
			if (!grounded && !doubleJump) {
				doubleJump = true;
			}
		}

		if(Zapi == false){
			IconeZapiAtivo.SetActive (false);
			IconeZapiDesativado.SetActive (true);
		}


	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "obstaculos" && !Zapi) {
            SceneManager.LoadScene("RIP");
			//Application.LoadLevel ("RIP");
		}
		if (col.tag == "obstaculos" && Zapi) {
			Amigo.SetActive (false);
			obstaculo = col.gameObject;
			obstaculo.SetActive (false);
			Zapi = false;
		}
		if (col.tag == "Interacao") {
			objetoInteracao = col.gameObject;
			audio.PlayOneShot(soundLike);
		}
		if (col.tag == "InteracaoZapi") {
			objetoZapi = col.gameObject;
			Zapi = true;
			audio.PlayOneShot(soundZapi);

		}
	}

	void OnTriggerExit2D(Collider2D col){
		if(col.tag == "Interacao"){
			objetoInteracao = null;
		}
		if (col.tag == "InteracaoZapi") {
			objetoZapi = null;
		}
		if (col.tag == "obstaculos") {
			obstaculo = null;
		}
	}
		

}
