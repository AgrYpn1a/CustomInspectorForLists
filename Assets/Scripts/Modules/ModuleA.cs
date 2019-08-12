using UnityEngine;

[CreateAssetMenu(menuName = "Modules/Module A")]
public sealed class ModuleA : Module
{
    private ModuleA() { }

    public override bool Equals(object other)
    {
        Module m = (Module)other;

        return m is ModuleA;
    }

    public override string GetName() => "Module A";

    public override void Load()
    {
        Debug.Log("[<b>Module</b>] Module A loaded.");
    }
}
