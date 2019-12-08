public class SphereController 
{
    private readonly ViewSphere _viewSphere;

    public SphereController (ViewSphere viewSphere)
    {
        _viewSphere = viewSphere;
    }

    public void OnUpdate (float deltaTime)
    {
        _viewSphere.Move(deltaTime);
    }
}
