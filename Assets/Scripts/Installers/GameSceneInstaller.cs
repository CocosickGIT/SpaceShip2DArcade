using Player;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private UIScore _uiScore;

        public override void InstallBindings()
        {
            Container.Bind<UIScore>().FromInstance(_uiScore).AsSingle();
        }
    }
}