using UnityEngine;

public class WorldLimit : MonoBehaviour
{
    [SerializeField] private float mapHeight;
    [SerializeField] private float mapWidth;
    [SerializeField] private float tileSize;
    [SerializeField] private float activationDelay;
    [SerializeField] private float endHeight;
    [SerializeField] private float endWidth; //Currently useless to have both endHeight and endWidth
    [SerializeField] private float secBetweenReductions;
    [SerializeField] private int arenaRatio; //To keep the same aspect ratio, the Width reduction must be doubled every arenaRatio reductions. Must be > 0
    private int _reductionsBeforeRatioCorrection;
    private BoxCollider2D _bc;
    private float _elapsedTime;
    private bool _hasStarted;
    private Vector2 _currentLimitSize;
    void Start()
    {
        _bc = GetComponent<BoxCollider2D>();
        _bc.size.Set (mapHeight, mapWidth);
        _currentLimitSize = new Vector2(mapWidth, mapHeight);
        _reductionsBeforeRatioCorrection = arenaRatio;
    }
    
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if ((_elapsedTime >= activationDelay && !_hasStarted) || (_elapsedTime >= secBetweenReductions && _hasStarted))
        {
            _hasStarted = true;
            _elapsedTime = 0f;
            _reductionsBeforeRatioCorrection -= 1;
            BarrierReduction();
        }
    }

    private void BarrierReduction()
    {
        if (_currentLimitSize.x > endWidth && _currentLimitSize.y > endHeight)
        {
            if (_reductionsBeforeRatioCorrection != 0)
            {
                _currentLimitSize = new Vector2(_currentLimitSize.x - tileSize, _currentLimitSize.y - tileSize);
                _bc.size = new Vector2(_currentLimitSize.x, _currentLimitSize.y);
            }
            else
            {
                _reductionsBeforeRatioCorrection = arenaRatio;
                _currentLimitSize = new Vector2(_currentLimitSize.x - 2*tileSize, _currentLimitSize.y - tileSize);
                _bc.size = new Vector2(_currentLimitSize.x, _currentLimitSize.y);
            }
        }
    }
}
