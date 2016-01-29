using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour
{

    void Update()
    {
        transform.position = new Vector3(
             transform.position.x,
             transform.position.y,
             transform.position.z + GameManager.GM.GameSpeed * Time.deltaTime);
    }
}
