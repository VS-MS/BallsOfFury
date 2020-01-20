using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CustomCapsuleFactory : IFactory<CapsuleBehaviour>
{
    DiContainer _container;

    public CustomCapsuleFactory(DiContainer container)
    {
        _container = container;
    }
    public CapsuleBehaviour Create()
    {
        return _container.InstantiatePrefabResourceForComponent<CapsuleBehaviour>("Platform/Capsule");
    }
}
