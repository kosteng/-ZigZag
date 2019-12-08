public class ProjectInfrastructure
{
    private readonly MonoBehaviourView _monoBehaviourView;
    private readonly SphereController _sphereController;

    public ProjectInfrastructure(MonoBehaviourView monoBehaviourView)
    {
        _monoBehaviourView = monoBehaviourView;
        _sphereController = new SphereController(_monoBehaviourView.ViewSphere);

    }

    public void Update(float deltaTime)
    {
        _sphereController.OnUpdate(deltaTime);
    }
}
