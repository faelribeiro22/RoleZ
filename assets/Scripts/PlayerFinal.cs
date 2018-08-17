using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerFinal : MonoBehaviour {

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
	public GameObject objetoInteracao;
	public UIController UIController;


    //Audio
    public AudioSource audio;
    public AudioClip soundJump;
    public AudioClip soundMorte;
	public AudioClip soundLike;

	// Use this for initialization
	void Start () {
		UIController = FindObjectOfType (typeof(UIController)) as UIController;


	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(objetoInteracao != null){
			//Debug.Log ("objetoInteracao.SendMessage");
			objetoInteracao.SendMessage ("interacao",SendMessageOptions.DontRequireReceiver);
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

		if (UIController.pontos >= 5) {
				SceneManager.LoadScene("Ganhou");
			}

	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "obstaculos") {
            SceneManager.LoadScene("RIP");
			//Application.LoadLevel ("RIP");
		}
		if (col.tag == "Interacao") {
			objetoInteracao = col.gameObject;
			audio.PlayOneShot(soundLike);
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if(col.tag == "Interacao"){
			objetoInteracao = null;
		}
	}

}
