using System;
using UnityEngine;

namespace Assets.Frosty2D.Scripts.Core.Movement
{
    [Serializable]
    public class FrostyMovementControllerInput
    {
        [Header("Movement Reference")]
        public FrostyPatternMovement movement;        

        [Header("Input")]
        public KeyCode key;
        public FrostyMovementOptions behavior;
        public bool toggle;
        public bool excludeOtherInputs;
        public int priority;

        [Header("Direction")]
        public bool reverse;
    }
}
