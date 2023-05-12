using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private GameObject VisualParent;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
}
