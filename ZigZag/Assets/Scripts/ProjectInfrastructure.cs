public class ProjectInfrastructure
{
    private readonly MonoBehaviourView _monoBehaviourView;
    private readonly SphereController _sphereController;
    private readonly TileController _tileController;
    private readonly Pool _poolTile;
    



    public ProjectInfrastructure(MonoBehaviourView monoBehaviourView)
    {
        _monoBehaviourView = monoBehaviourView;
        _sphereController = new SphereController(_monoBehaviourView.ViewSphere);
        _tileController = new TileController(_monoBehaviourView.ViewTile, _monoBehaviourView.Factory, _poolTile);
        _poolTile = new Pool();
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
