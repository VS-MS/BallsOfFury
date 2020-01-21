using UnityEngine;
using Zenject;

public class CustomPlatformFactory : IFactory<PlatformBehaviour>
{
    DiContainer _container;
    //int i = 0;
    public CustomPlatformFactory(DiContainer container)
    {
        _container = container;
    }
    public PlatformBehaviour Create()
    {
        return _container.InstantiatePrefabResourceForComponent<PlatformBehaviour>("Platform/Platform");
    }
}