using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        // Leer el input del usuario
        float movement = Input.GetAxis("Vertical");
        Vector3 actualPos = GetComponent<Transform>().position;
        /*float newPosY = actualPos.y + (speed * movement * Time.deltaTime);
        if (newPosY <= 7 && newPosY >= -7)
        {
            GetComponent<Transform>().position = new Vector3(
                actualPos.x,
                newPosY,
                actualPos.z
            );
        }*/
        GetComponent<Transform>().position = new Vector3(
                actualPos.x,
                Mathf.Clamp(actualPos.y + (speed * movement * Time.deltaTime), -7f, 7f),
                actualPos.z
        );
        



    }
}
