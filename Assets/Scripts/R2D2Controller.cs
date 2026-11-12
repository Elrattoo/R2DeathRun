using UnityEngine;

public class R2D2Controller : MonoBehaviour
{

 
    public float targetrotation = 16f;

    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -input * targetrotation));
    }
}
