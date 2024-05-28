using Code.Gameplay.Common.Collisions;
using Code.Infrastructure.View.Registrars;
using Entitas.Unity;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.View
{
  public class EntityBehaviour : MonoBehaviour, IEntityView
  {
    private GameEntity _entity;
    private ICollisionRegistry _collisionRegistry;
    public GameEntity Entity => _entity;

    [Inject]
    private void Construct(ICollisionRegistry collisionRegistry) => 
      _collisionRegistry = collisionRegistry;

    public void SetEntity(GameEntity entity)
    {
      _entity = entity;
      _entity.AddView(this);
      _entity.Retain(this);

      gameObject.Link(_entity);

      foreach (IEntityComponentRegistrar registrar in GetComponentsInChildren<IEntityComponentRegistrar>()) 
        registrar.RegisterComponents();

      foreach (Collider2D collider2d in GetComponentsInChildren<Collider2D>(includeInactive: true)) 
        _collisionRegistry.Register(collider2d.GetInstanceID(), _entity);
    }

    public void ReleaseEntity()
    {
      foreach (IEntityComponentRegistrar registrar in GetComponentsInChildren<IEntityComponentRegistrar>()) 
        registrar.UnregisterComponents();

      foreach (Collider2D collider2d in GetComponentsInChildren<Collider2D>(includeInactive: true)) 
        _collisionRegistry.Unregister(collider2d.GetInstanceID());
      
      gameObject.Unlink();
      _entity.Release(this);
      _entity = null;
    }
  }
}