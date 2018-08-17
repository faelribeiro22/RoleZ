using UnityEngine;
using System.Collections;

public class Movimento : MonoBehaviour {

	public Transform posInicial;
	public Transform posA;
	public Transform posB;

	public float speed;

	private float startTime;
	private float journeyLength;
	public Transform Objeto;

	public int idMovimento;


	void Start () {
		Objeto.position = posInicial.position;
		startTime = Time.time;
		journeyLength = Vector3.Distance (posA.position, posB.position);


	}


	void FixedUpdate () {
		float dist = (Time.time - startTime) * speed;
		float journey = dist / journeyLength;

		if (idMovimento == 1) {
			Objeto.position = Vector3.Lerp (posA.position, posB.position, journey);
			if (Objeto.position == posB.position) {
				Movimento2 ();
			}
		} else if (idMovimento == 2) {
			Objeto.position = Vector3.Lerp (posB.position, posA.position, journey);
			if (Objeto.position == posA.position) {
				Movimento1 ();
			}
		}
	}

	void Movimento1() {
		idMovimento = 1;
		startTime = Time.time;
		journeyLength = Vector3.Distance (posA.position, posB.position);
	}
	void Movimento2() {
		idMovimento = 2;
		startTime = Time.time;
		journeyLength = Vector3.Distance (posB.position, posA.position);
	}
}
