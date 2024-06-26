//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAngleSpeed;

    public static Entitas.IMatcher<GameEntity> AngleSpeed {
        get {
            if (_matcherAngleSpeed == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AngleSpeed);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAngleSpeed = matcher;
            }

            return _matcherAngleSpeed;
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

    public Code.Gameplay.Features.Movement.AngleSpeed angleSpeed { get { return (Code.Gameplay.Features.Movement.AngleSpeed)GetComponent(GameComponentsLookup.AngleSpeed); } }
    public float AngleSpeed { get { return angleSpeed.Value; } }
    public bool hasAngleSpeed { get { return HasComponent(GameComponentsLookup.AngleSpeed); } }

    public GameEntity AddAngleSpeed(float newValue) {
        var index = GameComponentsLookup.AngleSpeed;
        var component = (Code.Gameplay.Features.Movement.AngleSpeed)CreateComponent(index, typeof(Code.Gameplay.Features.Movement.AngleSpeed));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceAngleSpeed(float newValue) {
        var index = GameComponentsLookup.AngleSpeed;
        var component = (Code.Gameplay.Features.Movement.AngleSpeed)CreateComponent(index, typeof(Code.Gameplay.Features.Movement.AngleSpeed));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveAngleSpeed() {
        RemoveComponent(GameComponentsLookup.AngleSpeed);
        return this;
    }
}
