public class TileController 
{
    private readonly RoadBuilder _roadBuilder;
    private float _timer = 0;

    public TileController (RoadBuilder roadBuilder)
    { 
        _roadBuilder = roadBuilder;
    }
    
    public void Start()
    {
       _roadBuilder.BuildStartingPlatform(1, 1);
       _roadBuilder.CreateRoad(80);
    }

    public void Update(float deltaTime)
    {
        _timer += deltaTime;
        if (_timer >= 5)
        {
            _timer = 0;
            _roadBuilder.BackToPool();
            _roadBuilder.CreateRoad(80);
        }
    }
}
