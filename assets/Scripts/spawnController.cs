using UnityEngine;
using System.Collections;

public class spawnController : MonoBehaviour {

    public GameObject[] barreiraPrefab;
    public float rateSpawn;
    private float currentTime;
    public int posicao;
    public float y;
    public float posA;
    public float posB;
	public int indice;
	public Transform Player;

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
			indice = Random.Range (0, barreiraPrefab.Length);
           	
            GameObject tempPrefab = Instantiate(barreiraPrefab[indice]) as GameObject;
			tempPrefab.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            //Debug.Log(y);
        }
			
	}

	void Spawn(){

	}
}
