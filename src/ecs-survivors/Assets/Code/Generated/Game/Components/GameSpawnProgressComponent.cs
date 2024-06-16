//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherSpawnProgress;

    public static Entitas.IMatcher<GameEntity> SpawnProgress {
        get {
            if (_matcherSpawnProgress == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SpawnProgress);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSpawnProgress = matcher;
            }

            return _matcherSpawnProgress;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Code.Gameplay.Features.Enemies.SpawnProgress spawnProgressComponent = new Code.Gameplay.Features.Enemies.SpawnProgress();

    public bool isSpawnProgress {
        get { return HasComponent(GameComponentsLookup.SpawnProgress); }
        set {
            if (value != isSpawnProgress) {
                var index = GameComponentsLookup.SpawnProgress;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : spawnProgressComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}