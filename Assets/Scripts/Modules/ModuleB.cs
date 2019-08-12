using UnityEngine;

[CreateAssetMenu(menuName = "Modules/Module B")]
public sealed class ModuleB : Module
{
    private ModuleB() { }

    public override bool Equals(object other)
    {
        Module m = (Module)other;

        return m is ModuleB;
    }

    public override string GetName() => "Module B";

    public override void Load()
    {
        Debug.Log("[<b>Module</b>] Module B loaded.");
    }
}
