using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

    public float spawnTime; // number of seconds between ball spawns
    public GameObject toSpawn;
    public GameObject containerObject;

    private float nextSpawn;

    // Use this for initialization
	void Start () {
        nextSpawn = 0.0f;
	}

    void Update()
    {
        // if we're ready, spawn another ball
        if (Time.time > nextSpawn) {
            // spawn ball
            spawnObject();

            // set next spawn timer
            nextSpawn = Time.time + spawnTime;
        }
        
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
