public class ProjectInfrastructure
{
    private readonly MonoBehaviourServiceLocator _monoBehaviourServiceLocator;
    private readonly BallController _ballController;
    private readonly TileController _tileController;
    private readonly TilePool _tilePool;
    private readonly RoadBuilder _roadBuilder;
    private readonly UIController _UIController;
    
    public ProjectInfrastructure(MonoBehaviourServiceLocator monoBehaviourServiceLocator)
    {
        _monoBehaviourServiceLocator = monoBehaviourServiceLocator;
        _tilePool = new TilePool(_monoBehaviourServiceLocator.TileFactory);
        _roadBuilder = new RoadBuilder(_tilePool, _monoBehaviourServiceLocator.TileFactory);
        _ballController = new BallController(_monoBehaviourServiceLocator.BallView);
        _tileController = new TileController(_roadBuilder);
        _UIController = new UIController(_monoBehaviourServiceLocator.UIView, _monoBehaviourServiceLocator.BallView);
    }

    public void Start()
    {
        _tileController.Start();
        _UIController.Start();
    }

    public void Update(float deltaTime)
    {
        _ballController.Update(deltaTime);
        _tileController.Update(deltaTime);
        _UIController.Update();
    }
}
