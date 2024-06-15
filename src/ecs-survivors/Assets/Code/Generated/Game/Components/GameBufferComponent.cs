//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherBuffer;

    public static Entitas.IMatcher<GameEntity> Buffer {
        get {
            if (_matcherBuffer == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Buffer);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBuffer = matcher;
            }

            return _matcherBuffer;
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

    static readonly Code.Gameplay.Features.Enemies.Buffer bufferComponent = new Code.Gameplay.Features.Enemies.Buffer();

    public bool isBuffer {
        get { return HasComponent(GameComponentsLookup.Buffer); }
        set {
            if (value != isBuffer) {
                var index = GameComponentsLookup.Buffer;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : bufferComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
