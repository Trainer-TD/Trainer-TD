using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {
    [Header("Enemy Prefabs (List in order)")]
    public Enemy[] AllEnemies;
    public Enemy Mewtwo;

    [Header("Decide Spawn Location")]
    public Transform spawnPoint;

    [Header("Wave Properies")]
    public float timeBetweenWaves = 10f;
    public float timeBetweenEnemies = 0.5f;
    public float maxTimePerRound = 50f;
    private float countdown = 10f;
    private bool ReadyNextWave = false;
    private bool startedTimer = false;
    private bool CanSpawnNextWave = false;
    private bool isMewtwoRound = false;
    private int MewtwoCounter = 0;

    public Text waveCountdownText;

    public int waveNumber = 10;
    public int maxLevel = 45;

    [Header("LevelText UI")]
    public Text levelUI;
    private int level = 0;
    public Text levelStartUI;

    [Header("Notification Text")]
     public GameObject TokenText;
     public Text enemyTypeText;
     public Text currentEnemyTypeText;

     private string nextEnemyType;
     private string currentEnemyType;
     private int roundOffset;


    void Start () {
       nextEnemyType = "Grass";
       enemyTypeText.text = "Next Level Enemies: " + nextEnemyType;
       currentEnemyType = "";
    }

    void Update () {
        if (PlayerProperties.Rounds == maxLevel) {
            isMewtwoRound = true;
        }

        if (PlayerProperties.CurrentEnemiesAlive <= 0) {
            SetReadyNextWave ();
        }

        if (ReadyNextWave && startedTimer) {
            StartTimer ();
        }

        if (countdown <= 0f) {
            CanSpawnNextWave = true;
        }

        if (CanSpawnNextWave) {
            StartCoroutine(SpawnWave());
            CanSpawnNextWave = false;
            countdown = maxTimePerRound;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = "Time to next level: " + string.Format("{0:00.00}", countdown);
        levelUI.text = "Current Level: " + PlayerProperties.Rounds.ToString();
        enemyTypeText.text = "Next Level Enemies: " + nextEnemyType;
        currentEnemyTypeText.text = "Current Level Enemies: " + currentEnemyType;

    }

    IEnumerator SpawnWave () {
        PlayerProperties.Rounds++;
        levelStartUI.text = "Level " + PlayerProperties.Rounds.ToString();
        levelStartUI.gameObject.SetActive(true);
        Invoke("StopWaveText", 2);

        if ( level % 5 != 0) {
            PlayerProperties.CurrentEnemiesAlive += waveNumber;
            if ( level >= 41 && level <= 44) {
                PlayerProperties.CurrentEnemiesAlive = 1;
            }
        }

        level = PlayerProperties.Rounds;
        if (level < maxLevel && !isMewtwoRound) {
            Enemy currentEnemy = AllEnemies[(level - 1) - (level / 5)];
        }
        if (level + 1 != maxLevel && !isMewtwoRound) {
            Enemy currentEnemy = AllEnemies[(level - 1) - (level / 5)];
            Enemy nextEnemy = AllEnemies[level - (level / 5)];        
            nextEnemyType = nextEnemy.classType;
            currentEnemyType = currentEnemy.classType;
        } 
        else {
            MewtwoCounter += 1;
            Debug.Log("Mewtwo getting stronger: " + MewtwoCounter);
            nextEnemyType = "Mewtwo";
            currentEnemyType = "Mewtwo";
        }
        
        if (PlayerProperties.Rounds % 5 == 0 && PlayerProperties.Rounds <= 44){
           PlayerProperties.elementToken++;
           TokenText.SetActive(true);
           Invoke("TurnOffNotication", 3);
        }
        else {
            if (level >= 41 && level <= 44) {
                SpawnEnemy();
            }
            else {
                for (int i = 0; i < waveNumber; i++) {
                    SpawnEnemy();
                    yield return new WaitForSeconds(timeBetweenEnemies);
                }
            }
        }

    }

    void TurnOffNotication () {
       TokenText.SetActive(false);
    }

    void SpawnEnemy() {
        if (level % 5 == 0 && level <= maxLevel) {
            return;
        }

        if (level < maxLevel) {
            Instantiate(AllEnemies[(level - 1) - (level / 5)], spawnPoint.position, spawnPoint.rotation);
        }
        else {
            if (Mewtwo.baseSpeed <= 7f) {
                Mewtwo.baseSpeed = Mewtwo.baseSpeed + (0.1f * MewtwoCounter);
            }
            else {
                Mewtwo.baseSpeed = 7f;
            }

            if (Mewtwo.startArmor <= 75f) {
                Mewtwo.startArmor = Mewtwo.startArmor + (1f * MewtwoCounter);
            }
            else {
                Mewtwo.startArmor = 75f;
            }

            Mewtwo.startHealth = Mewtwo.startHealth + (200f * MewtwoCounter);
            Instantiate(Mewtwo, spawnPoint.position, spawnPoint.rotation);
        }
    }

    void SetReadyNextWave () {
        PlayerProperties.CurrentEnemiesAlive = 0; // reset
        ReadyNextWave = true;
    }

    void StartTimer () {
        countdown = timeBetweenWaves;
        ReadyNextWave = false;
        startedTimer = true;
    }

    void StopWaveText() {
       levelStartUI.gameObject.SetActive(false);
    }

}
