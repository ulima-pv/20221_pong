using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementManager : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.position += (speed * Time.deltaTime * Vector3.left);
    }
}
