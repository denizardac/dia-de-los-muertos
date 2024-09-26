using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;

    public bool gameStarted = false;

    [SerializeField] private List<GameObject> SpawnableProps;

    void Update()
    {
        if(Input.GetMouseButton(0) && !gameStarted)
        {
            StartSpawning();
            gameStarted = true;
        }
    }

    private void StartSpawning ()
    {
        InvokeRepeating("SpawnProp", 0.5f, spawnRate);
    }


    private void SpawnProp()
    {
        Vector3 spawnPos = spawnPoint.position;

        spawnPos.x = Random.Range(-maxX, maxX);
        if(SpawnableProps.Count > 0){
            GameObject _SpawnPrefab = SpawnableProps[Random.Range(0,SpawnableProps.Count)];
            Instantiate( _SpawnPrefab, spawnPos, Quaternion.identity );
        }

    }
    
}
