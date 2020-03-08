public class TileController 
{
    private readonly RoadBuilder _roadBuilder;
    private float _timer = 0;
    private const int CountTilesForCreate = 80;
    private const int SizeStartingPlatform = 1;
    public TileController (RoadBuilder roadBuilder)
    { 
        _roadBuilder = roadBuilder;
    }
    
    public void Start()
    {
       _roadBuilder.BuildStartingPlatform(SizeStartingPlatform);
       _roadBuilder.CreateRoad(CountTilesForCreate);
    }

    public void Update(float deltaTime)
    {
        _timer += deltaTime;
        if (_timer >= 2)
        {
            _timer = 0;
            _roadBuilder.BackToPool();
            _roadBuilder.CreateRoad(CountTilesForCreate);
        }
    }
}
