public class ProjectInfrastructure
{
    private readonly MonoBehaviourView _monoBehaviourView;
    private readonly SphereController _sphereController;
    private readonly TileController _tileController;
    private readonly Pool _poolTile;
    private readonly RoadBuilder _roadBuilder;
    



    public ProjectInfrastructure(MonoBehaviourView monoBehaviourView)
    {
        _monoBehaviourView = monoBehaviourView;
        _poolTile = new Pool(_monoBehaviourView.Factory);
        _roadBuilder = new RoadBuilder(_poolTile);
        
        _sphereController = new SphereController(_monoBehaviourView.ViewSphere);
        _tileController = new TileController(_monoBehaviourView.ViewTile, _roadBuilder);

    }
    public void Start ()
    {
        _tileController.Start();
    }
    public void Update(float deltaTime)
    {
        _sphereController.OnUpdate(deltaTime);
    }
}
