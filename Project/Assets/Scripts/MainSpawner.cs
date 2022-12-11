using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using CodeMonkey.Utils;

public class MainSpawner : MonoBehaviour
{
    public AnimationCurve animationCurve;

    public bool isPauseSpawning;
    public float time;

    public List<Enemy> enemyTypes = new List<Enemy>();
    public List<Enemy> bossTypes = new List<Enemy>();
    public List<Transform> enemys = new List<Transform>();

    public Camera mainCamera;
    public Transform enemyHolder;
    public float minDistance;
    public float maxDistance;
    public float difficulty;
    public float baseSpawnTime;

    private bool isInBossFight;
    private float currentCooldown;
    private bool isSpawned;

    public static MainSpawner instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    private void Update()
    {
        /*var upperLeftScreen = Vector3(0, Screen.height, depth);
        var upperRightScreen = Vector3(Screen.width, Screen.height, depth);
        var lowerLeftScreen = Vector3(0, 0, depth);
        var lowerRightScreen = Vector3(Screen.width, 0, depth);

        //Corner locations in world coordinates
        var upperLeft = camera.ScreenToWorldPoint(upperLeftScreen);
        var upperRight = camera.ScreenToWorldPoint(upperRightScreen);
        var lowerLeft = camera.ScreenToWorldPoint(lowerLeftScreen);
        var lowerRight = camera.ScreenToWorldPoint(lowerRightScreen);

        var upperLeft1 = UtilsClass.GetMouseWorldPosition(new Vector2(0, Screen.height));
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;*/


        /*var upperLeft = mainCamera.ScreenToWorldPoint(new Vector2(0, Screen.height));
        var upperRight = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        var lowerLeft = mainCamera.ScreenToWorldPoint(new Vector2(0, 0));
        var lowerRight = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, 0));*/
        

        if (isPauseSpawning)
        {
            return;
        }

        if (time > 300 && !isSpawned)
        {
            Debug.Log("Summon Boss");
            isSpawned = true;
            isPauseSpawning = true;
            
            for (int i = 0; i < enemys.Count; i++)
            {
                Destroy(enemys[i].gameObject);
            }
            enemys.Clear();
            SpawnBoss(GetSpawnPosition());
            return;

        }

        if (!isPauseSpawning)
        {
            time += Time.deltaTime;
        }
        
        if (currentCooldown < 0)
        {
            
            currentCooldown = baseSpawnTime / animationCurve.Evaluate(time);
            SpawnEnemy(GetSpawnPosition());

        }
        else
        {
            currentCooldown -= Time.deltaTime;
        }
    }

    private void SpawnEnemy(Vector3 _enemyPosition)
    {
        
        var newEnemy = Instantiate(WhichEnemy(), _enemyPosition, Quaternion.identity, enemyHolder);
        enemys.Add(newEnemy);
    }

    private void SpawnBoss(Vector3 _enemyPosition)
    {
        var newEnemy = Instantiate(bossTypes[0].prefab, _enemyPosition, Quaternion.identity, enemyHolder);
        enemys.Add(newEnemy);
    }

    private Transform WhichEnemy()
    {
        List<int> ints = new List<int>();

        for (int i = 0; i < enemyTypes.Count; i++)
        {
            if (time > enemyTypes[i].canSpawnAfter)
            {
                for (int ii = 0; ii < enemyTypes[i].spawnWeight; ii++)
                {
                    ints.Add(i + 1);
                }
            } 
        }

        Debug.Log(string.Join(", ", ints));
        int randomNumber = ints[Random.Range(0, ints.Count)];
        return enemyTypes[randomNumber - 1].prefab;

        
    }

    private Vector3 GetSpawnPosition()
    {
        var direction = Random.insideUnitCircle.normalized;
        var distance = Random.Range(minDistance, maxDistance);
        return new Vector3((direction.x * distance), (direction.y * distance), 0) + mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2));
    }

    
}

[System.Serializable]
public class Enemy
{
    public Transform prefab;
    public float canSpawnAfter;
    public int spawnWeight;
}

[System.Serializable]
public class Boss
{
    public Transform prefab;
    public float canSpawnAfter;
    public int spawnWeight;
}