using UnityEngine;
using System.Collections;
using Assets.Frosty2D.Scripts.Core.Movement;

[AddComponentMenu("Frosty-Movement/Pattern Movement")]
public class FrostyPatternMovement : MonoBehaviour
{
    [Header("Kinematics Reference")]
    public FrostyKinematics kinematics;

    [Header("Movement Pattern")]
    public FrostySingleMovementPattern[] patterns;
    
    private Vector2 currentDirection;
    private float currentSpeed;
    private Vector2 rawMovement;
    
    void Update()
    {
        currentSpeed = 0f;
        rawMovement = Vector2.zero;
        currentDirection = Vector2.zero;

        if (patterns == null) return;

        for(int i = 0; i < patterns.Length; i++)
        {
            FrostySingleMovementPattern pattern = patterns[i];
            float speed;
            Vector2 dir = pattern.Evaluate(Time.smoothDeltaTime, out speed);
            rawMovement += (dir.normalized * speed);
        }

        currentDirection = rawMovement.normalized;
        currentSpeed = rawMovement.magnitude;

        if (kinematics != null)
        {
            kinematics.ApplyMovement(currentDirection, currentSpeed);
        }
    }

    public bool HasFinished()
    {
        for (int i = 0; i < patterns.Length; i++)
        {
            if (patterns[i].active)
            {
                return false;
            }
        }
        return true;
    }

    public void Reactivate(bool keepSpeed = true)
    {
        for (int i = 0; i < patterns.Length; i++)
        {
            patterns[i].Reactivate(keepSpeed);
        }
    }

    public void Deactivate()
    {
        for (int i = 0; i < patterns.Length; i++)
        {
            patterns[i].Deactivate();
        }
    }
}
