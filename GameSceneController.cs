using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

using Random = UnityEngine.Random;

public class GameSceneController : MonoBehaviour {

    public GameObject hero;
    public GameObject enemyPrefab;
    public Text infoText;
    private float enemyTimer = 0;
    private float enemySpawnInterval = 1;
    private float enemySpawnDistance = 15;
    private int score = 0;

	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("r"))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        enemyTimer -= Time.deltaTime;

        if ( enemyTimer <= 0 && hero != null)
        {
            enemyTimer = enemySpawnInterval;

            float spawnAngle = Random.Range(0, 360);

            GameObject enemyObject = GameObject.Instantiate<GameObject>(enemyPrefab);
            enemyObject.transform.position = new Vector3
                (
                hero.transform.position.x + Mathf.Cos(spawnAngle) * enemySpawnDistance,
                hero.transform.position.y,
                hero.transform.position.z + Mathf.Sin(spawnAngle) * enemySpawnDistance
                );

            EnemyContoller enemy = enemyObject.transform.GetComponent<EnemyContoller>();
            enemy.chaseDirection = (hero.transform.position - enemy.transform.position).normalized;

            enemy.onDestroyed = () =>
            {
                score += 100;
                infoText.text = "Score: " + score.ToString();
            };

            enemy.onHitPlayer = () =>
            {
                infoText.text = "Game Over! Press R to Restart";

                Time.timeScale = 0;
            };
        }
	}
}
