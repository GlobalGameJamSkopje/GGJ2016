using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        
        transform.Translate(Input.GetAxis("Horizontal") * 10f * Time.deltaTime, 0, 0);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -6, 6),
            transform.position.y,
            transform.position.z);

    }


}
