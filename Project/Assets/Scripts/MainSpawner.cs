using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using CodeMonkey.Utils;

public class MainSpawner : MonoBehaviour
{
    public Camera mainCamera;
    public List<Transform> enemys = new List<Transform>();
    public Transform enemyHolder;
    public float minDistance;
    public float maxDistance;
    public float difficulty;
    public float baseSpawnTime;

    private float currentCooldown;

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

        

        if (currentCooldown < 0)
        {
            var direction = Random.insideUnitCircle.normalized;
            var distance = Random.Range(minDistance, maxDistance);
            Vector3 enemyPosition = new Vector3((direction.x * distance), (direction.y * distance), 0) + mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2));
            currentCooldown = baseSpawnTime / difficulty;
            SpawnEnemy(enemys[0], enemyPosition);

        }
        else
        {
            currentCooldown -= Time.deltaTime;
        }
    }

    private void SpawnEnemy(Transform _enemyTrans, Vector3 _enemyPosition)
    {
        Instantiate(_enemyTrans, _enemyPosition, Quaternion.identity, enemyHolder);
    }
    
}
