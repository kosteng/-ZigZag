public class ProjectInfrastructure
{
    private readonly MonoBehaviourContainer _monoBehaviourContainer;
    private readonly BallController _ballController;
    private readonly TileController _tileController;
    private readonly TilePool _tilePool;
    private readonly RoadBuilder _roadBuilder;
    private readonly UIController _UIController;
    private readonly GameplayController _gameplayController;
    
    public ProjectInfrastructure(MonoBehaviourContainer monoBehaviourContainer)
    {
        _monoBehaviourContainer = monoBehaviourContainer;
        _tilePool = new TilePool(monoBehaviourContainer.TileFactory);
        _roadBuilder = new RoadBuilder(_tilePool);
        _ballController = new BallController(monoBehaviourContainer.BallView);
        _tileController = new TileController(_roadBuilder);
        _UIController = new UIController(monoBehaviourContainer.UIView);
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
