using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

    public GameObject toSpawn;
    public GameObject containerObject;

	// Use this for initialization
	void Start () {
	    
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            spawnObject();
        }
    }

    public void spawnObject()
    {
        GameObject go = (GameObject)GameObject.Instantiate(toSpawn, gameObject.transform.position, Quaternion.identity);
        go.transform.parent = containerObject.transform;
    }
}
