using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Module : ScriptableObject
{
    /// <summary>
    /// Implement this to load the custom module.
    /// </summary>
    public abstract void Load();

    public abstract string GetName();

    public abstract override bool Equals(object other);

}
