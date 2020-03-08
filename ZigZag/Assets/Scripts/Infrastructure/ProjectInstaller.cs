using UnityEngine;

public class ProjectInstaller : MonoBehaviour
{
    [SerializeField] private MonoBehaviourContainer _monoBehaviourServiceLocator;

    private ProjectInfrastructure _infrastructure;

    private void Awake()
    {
        _infrastructure = new ProjectInfrastructure(_monoBehaviourServiceLocator);
    }

    private void Start()
    {
        _infrastructure.Start();
    }
    private void Update()
    {
        _infrastructure.Update(Time.deltaTime);
    }
}
