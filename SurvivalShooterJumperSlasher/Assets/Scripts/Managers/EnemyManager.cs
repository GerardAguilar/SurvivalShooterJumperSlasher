using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;


    void Start ()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        //enemy = (GameObject)Resources.Load("Zombunny");//Resources folder needs to be created for this to work
        InvokeRepeating ("Spawn", spawnTime, spawnTime);//function name, initial breathing room, interval
    }


    void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
