using UnityEngine;
using System.Collections;

[AddComponentMenu("Frosty-Movement/Conditions/Reverse Predicate")]
public class FrostyMovementReversePredicate : FrostyMovementPredicate
{
    public FrostyMovementPredicate predicate;
    public override bool Value { get { return !predicate.Value; } }
}
