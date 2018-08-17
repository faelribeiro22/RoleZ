using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveBarreira : MonoBehaviour {

    public float speed;
    private float x;
    public GameObject Player;
    public bool pontuado;
	public int pontos;
	public UIController UIController;


	// Use this for initialization
	void Start () {
		UIController = FindObjectOfType (typeof(UIController)) as UIController;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        x = transform.position.x;
        x += speed * Time.deltaTime;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);

        if(x <= Player.transform.position.x && pontuado == false)
        {
            pontuado = true;
            //PlayerController.pontuacao += 1;
        }

        if(x <= -10)
        {
            Destroy(transform.gameObject);
        }
	}

	public void interacao(){
		UIController.pontos += 1;
		this.gameObject.SetActive (false);

	}

	public void interacaoZapi(){
		this.gameObject.SetActive (false);

	}
}
