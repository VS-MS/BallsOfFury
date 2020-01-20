using UnityEngine;
using Zenject;

public class DefaultInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ITimeController>().To<TimeController>().AsSingle();

        Container.BindFactory<PlatformBehaviour, PlatformBehaviour.Factory>().FromFactory<CustomPlatformFactory>();
        Container.BindFactory<CapsuleBehaviour, CapsuleBehaviour.Factory>().FromFactory<CustomCapsuleFactory>();
    }
}