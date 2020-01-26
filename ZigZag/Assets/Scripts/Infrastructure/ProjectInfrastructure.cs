public class ProjectInfrastructure
{
    private readonly MonoBehaviourServiceLocator _monoBehaviourServiceLocator;
    private readonly BallController _ballController;
    private readonly TileController _tileController;
    private readonly TilePool _tilePool;
    private readonly RoadBuilder _roadBuilder;
    private readonly UIController _UIController;
    private readonly GameplayController _gameplayController;
    
    public ProjectInfrastructure(MonoBehaviourServiceLocator monoBehaviourServiceLocator)
    {
        _monoBehaviourServiceLocator = monoBehaviourServiceLocator;
        _tilePool = new TilePool(_monoBehaviourServiceLocator.TileFactory);
        _roadBuilder = new RoadBuilder(_tilePool);
        _ballController = new BallController(_monoBehaviourServiceLocator.BallView);
        _tileController = new TileController(_roadBuilder);
        _UIController = new UIController(_monoBehaviourServiceLocator.UIView);
        _gameplayController = new GameplayController(_ballController, _UIController);
    }

    public void Start()
    {
        _tileController.Start();
        _UIController.Start();
        _ballController.Start();
        _gameplayController.Start();
    }

    public void Update(float deltaTime)
    {
        _ballController.Update(deltaTime);
        _tileController.Update(deltaTime);
        _gameplayController.Update();
    }
}
