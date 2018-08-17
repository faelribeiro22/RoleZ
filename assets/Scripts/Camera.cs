using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    public Transform player;
    private float x;
    private float y;
    public float transition;
    public bool usarlerp;
    public bool segueY;
    public float ajusteY;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        x = player.position.x;
        if(segueY == true)
        {
            y = player.position.y + ajusteY;
        }
        else
        {
            y = transform.position.y;
        }
        if(usarlerp == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(x, y, transform.position.z), transition);
        }
        else
        {
            transform.position = new Vector3(x, y, transform.position.z);
        }
	}
}
