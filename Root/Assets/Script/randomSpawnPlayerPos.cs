using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawnPlayerPos : MonoBehaviour
{
    [SerializeField] Vector3[] spawnPoint;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 playerPos = spawnPoint[Random.Range(0,spawnPoint.Length - 1)];
        player.transform.position = new Vector3(playerPos.x, .5f, playerPos.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
