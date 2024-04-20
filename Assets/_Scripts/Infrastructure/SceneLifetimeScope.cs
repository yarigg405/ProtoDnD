using UnityEngine;
using VContainer;
using VContainer.Unity;
using Yrr.UI;


namespace Infrastructure.DI
{
    public class SceneLifetimeScope : LifetimeScope
    {
        [SerializeField] private UIManager uiManager;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(uiManager);
        }
    }
}