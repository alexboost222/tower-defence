using MVPPassiveView.Models.ProjectileTargets;

namespace TMPTesting
{
    public interface IProjectileTargetSource
    {
        IProjectileTarget Target { get; }
    }
}