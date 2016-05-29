using UnityEngine;
using System.Linq;
using System.Collections;
using Assets.Frosty2D.Scripts.Core.Movement;

[AddComponentMenu("Frosty-Movement/Movement Controller")]
public class FrostyMovementController : MonoBehaviour
{
    public FrostyMovementControllerInput[] inputs;

    void Update()
    {
        foreach(FrostyMovementControllerInput input in inputs.OrderBy(i=>i.priority))
        {
            bool isHeld = Input.GetKey(input.key);
            bool isPressed = Input.GetKeyDown(input.key);
            bool isReleased = Input.GetKeyUp(input.key);
            
            if (isPressed)
            {
                input.movement.Reactivate();
            }

            if (isReleased)
            {
                input.movement.Deactivate();
            }
        }
    }
}
