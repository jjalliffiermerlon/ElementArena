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
    private BoxCollider2D _bc;
    private SpriteRenderer _sp;
    private bool _isEnabled;

    private void Start()
    {
        _bc = GetComponent<BoxCollider2D>();
        _sp = GetComponent<SpriteRenderer>();
        _spawnWait = Random.Range(minSpawnTimeInSec, maxSpawnTimeInSec);
        ItemType = Random.Range(0, numberOfItemTypes + 1);
    }

    void Update()
    {
        if (!_isEnabled)
        {
            _elapsedTime += Time.deltaTime;
        }

        if (_elapsedTime >= _spawnWait)
        {
            _bc.enabled = true;
            _sp.enabled = true;
            _elapsedTime = 0;
            _spawnWait = Random.Range(minSpawnTimeInSec, maxSpawnTimeInSec);
            ItemType = Random.Range(0, numberOfItemTypes + 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _bc.enabled = false;
            _sp.enabled = false;
        }
    }
}