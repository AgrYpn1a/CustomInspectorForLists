using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class Modules : MonoBehaviour, IEnumerable<Module>
{
    [SerializeField]
    private List<Module> _modules = new List<Module>();

    public IEnumerator<Module> GetEnumerator() => _modules.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => null;

    public bool Add(Module m)
    {
        // We reject duplicates
        if (_modules.Contains(m)) return false;

        _modules.Add(m);

        return true;
    }

    public bool Remove(Module m)
    {
        if (_modules.Contains(m))
        {
            _modules.Remove(m);
            return true;
        }

        return false;
    }

    public bool Remove(List<Module> modules)
    {
        if (modules.Count == 0) return false;

        _modules = _modules.Except(modules).ToList();

        return true;
    }

    public void Clear()
    {
        _modules = new List<Module>();
    }

}
