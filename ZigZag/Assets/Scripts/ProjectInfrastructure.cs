public class ProjectInfrastructure
{
    private readonly MonoBehaviourView _monoBehaviourView;
    private readonly SphereController _sphereController;
    private readonly TileController _tileController;
    private readonly Pool _poolTile;
    private readonly RoadBuilder _roadBuilder;
    private readonly UIController _UIController;
    
    public ProjectInfrastructure(MonoBehaviourView monoBehaviourView)
    {
        _monoBehaviourView = monoBehaviourView;
        _poolTile = new Pool(_monoBehaviourView.Factory);
        _roadBuilder = new RoadBuilder(_poolTile, _monoBehaviourView.Factory);
        _sphereController = new SphereController(_monoBehaviourView.ViewSphere);
        _tileController = new TileController(_roadBuilder);
        _UIController = new UIController(_monoBehaviourView.ViewUI, _monoBehaviourView.ViewSphere);
    }

    public void Start()
    {
        _tileController.Start();
        _UIController.Start();
    }

    public void Update(float deltaTime)
    {
        _sphereController.Update(deltaTime);
        _tileController.Update(deltaTime);
        _UIController.Update();
    }
}
