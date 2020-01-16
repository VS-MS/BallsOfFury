using UnityEngine;
using Zenject;

public class DefaultInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ITimeController>().To<TimeController>().AsSingle();
    }
}