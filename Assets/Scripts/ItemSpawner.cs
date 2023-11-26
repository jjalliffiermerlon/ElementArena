using UnityEngine;
using Random = UnityEngine.Random;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private int maxSpawnTimeInSec = 10;
    [SerializeField] private int minSpawnTimeInSec = 5;
    [SerializeField] private int numberOfItemTypes = 2;
    public static int ItemType;
    private float _spawnWait;
    private float _elapsedTime;
    private bool _isEnabled;
    [SerializeField] GameObject[] elementPrefabs;
    private GameObject elementSpawned;

    private void Start()
    {
        _spawnWait = Random.Range(minSpawnTimeInSec, maxSpawnTimeInSec);
        ItemType = Random.Range(0, elementPrefabs.Length);
    }

    void Update()
    {
        if (!_isEnabled)
        {
            _elapsedTime += Time.deltaTime;
        }

        if (_elapsedTime >= _spawnWait)
        {
            Destroy(elementSpawned);
            elementSpawned = Instantiate(elementPrefabs[ItemType]);
            elementSpawned.transform.position = gameObject.transform.position;
            AudioManager.Instance.playElementSpawned();

            _elapsedTime = 0;
            _spawnWait = Random.Range(minSpawnTimeInSec, maxSpawnTimeInSec);
            ItemType = Random.Range(0, elementPrefabs.Length);
        }
    }
}