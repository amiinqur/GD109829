using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
   GroundSpawner groundSpawner;
    public GameObject coinPrefab;
    public GameObject obstaclePrefab;

    public GameObject TallOb;

    public GameObject Building;

    public float Tallf=0.2f;

    public Light leftSpot;

    public Light rightSpot;

    private Light direcLight;


    private void Start () {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        //leftSpot.enabled=true;
        direcLight = Lamps.direcLight;
	}

    private void FixedUpdate(){
       
        if(direcLight.transform.localRotation.eulerAngles.x <170)
        {
            //Debug.Log(direcLight.transform.localRotation.eulerAngles.x);
            leftSpot.enabled=false;
            rightSpot.enabled=false;
        }
        else
        {
            leftSpot.enabled=true;
            rightSpot.enabled=true;
        }
    }

    private void OnTriggerExit (Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    public void SpawnObstacle ()
    {
        GameObject SpawnSelec = obstaclePrefab;
        float random=Random.Range(0f,1f);
        if(random<Tallf){
            SpawnSelec=TallOb;
        }
        // Choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn the obstace at the position
        Instantiate(SpawnSelec, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnBuilding()
    {
        int obstacleSpawnIndex = Random.Range(5, 7);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        // Spawn the obstace at the position
        Instantiate(Building, spawnPoint.position, Quaternion.identity, transform);
    }


    public void SpawnCoins ()
    {
        int coinsToSpawn = 10;
        for (int i = 0; i < coinsToSpawn; i++) {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point)) {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}
