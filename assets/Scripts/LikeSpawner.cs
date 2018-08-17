using UnityEngine;
using System.Collections;

public class LikeSpawner : MonoBehaviour {

	public GameObject likePrefab;
	public float rateSpawn;
	private float currentTime;
	private int posicao;
	private float y;
	public float posA;
	public float posB;

	// Use this for initialization
	void Start () {
		currentTime = 0;
	}

	// Update is called once per frame
	void FixedUpdate () {
		currentTime += Time.deltaTime;
		if(currentTime >= rateSpawn)
		{
			currentTime = 0;
			posicao = Random.Range(1, 100);
			if(posicao >= 51)
			{
				y = posA;
			}
			else
			{
				y = posB;
			}
			GameObject tempPrefab = Instantiate(likePrefab) as GameObject;
			tempPrefab.transform.position = new Vector3(transform.position.x, y, transform.position.z);
		}
	}
}