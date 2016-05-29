using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[AddComponentMenu("Frosty-Movement/Kinematics")]
public class FrostyKinematics : MonoBehaviour
{
    private List<Vector2> forces;
    private const int CLAMP_UP = 0;
    private const int CLAMP_RIGHT = 1;
    private const int CLAMP_DOWN = 2;
    private const int CLAMP_LEFT = 3;
    private float[] clamp;

    void Start()
    {
        forces = new List<Vector2>();
        clamp = new float[4];
    }

    void Update()
    {
        //ApplyMovement(new Vector2(1,1), 5);
        ClampPosition(Vector2.right, 400);
        ClampPosition(Vector2.down, -194);

        Move();
        ResetMovement();
    }

    private void Move()
    {
        Vector3 allForces = forces.Aggregate((v1, v2) => v1 + v2);
        allForces += this.transform.position;
        float clampX = Mathf.Clamp(allForces.x, clamp[CLAMP_LEFT] > 0 ? -clamp[CLAMP_LEFT] : allForces.x,
                                                clamp[CLAMP_RIGHT] > 0 ? clamp[CLAMP_RIGHT] : allForces.x);

        float clampY = Mathf.Clamp(allForces.y, clamp[CLAMP_DOWN] > 0 ? -clamp[CLAMP_DOWN] : allForces.y,
                                                clamp[CLAMP_UP] > 0 ? clamp[CLAMP_UP] : allForces.y);

        allForces = new Vector3(clampX, clampY);
        this.transform.position = allForces;
    }

    private void ResetMovement()
    {
        forces.Clear();
        clamp[CLAMP_UP] = clamp[CLAMP_RIGHT] = clamp[CLAMP_DOWN] = clamp[CLAMP_LEFT] = -1;
    }

    public void ApplyMovement(Vector2 direction, float speed)
    {
        forces.Add(direction.normalized * speed);
    }

    public void ClampPosition(Vector2 direction, float value)
    {
        value = Mathf.Abs(value);
        Vector2 normalized = direction.normalized * value;

        clamp[CLAMP_UP] = Mathf.Min(clamp[CLAMP_UP] <= 0 ? normalized.y : clamp[CLAMP_UP], normalized.y);
        clamp[CLAMP_RIGHT] = Mathf.Min(clamp[CLAMP_RIGHT] <= 0 ? normalized.x : clamp[CLAMP_RIGHT], normalized.x);
        clamp[CLAMP_DOWN] = Mathf.Min(clamp[CLAMP_DOWN] <= 0 ? -normalized.y : clamp[CLAMP_DOWN], -normalized.y);
        clamp[CLAMP_LEFT] = Mathf.Min(clamp[CLAMP_LEFT] <= 0 ? -normalized.x : clamp[CLAMP_LEFT], -normalized.x);
    }
}
