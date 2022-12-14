using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpEffect : ScriptableObject
{

    public abstract void Apply(GameObject player);
    public abstract int getPrice();

}
