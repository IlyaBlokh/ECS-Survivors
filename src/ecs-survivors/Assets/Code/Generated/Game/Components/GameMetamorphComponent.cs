//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherMetamorph;

    public static Entitas.IMatcher<GameEntity> Metamorph {
        get {
            if (_matcherMetamorph == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Metamorph);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMetamorph = matcher;
            }

            return _matcherMetamorph;
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

    static readonly Code.Gameplay.Features.Statuses.Metamorph metamorphComponent = new Code.Gameplay.Features.Statuses.Metamorph();

    public bool isMetamorph {
        get { return HasComponent(GameComponentsLookup.Metamorph); }
        set {
            if (value != isMetamorph) {
                var index = GameComponentsLookup.Metamorph;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : metamorphComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
