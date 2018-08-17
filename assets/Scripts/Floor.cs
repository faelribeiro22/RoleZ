using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {

    private Material currentMaterial;
    public float speed;
    private float offSet;

	// Use this for initialization
	void Start () {
        currentMaterial = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        offSet += speed * Time.deltaTime;
        currentMaterial.SetTextureOffset("_MainTex", new Vector2(offSet, 0));
	}
}
