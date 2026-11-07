using Unity.VisualScripting;
using UnityEngine;

public class Camera : MonoBehaviour
{

    enum FollowMode { SmoothDamp, Lerp}

    [SerializeField] Transform target;
    [SerializeField] FollowMode followMode;

    [Header("SmoothDamp")]
    [SerializeField] float smoothTime = 0.3f;

    [Header("Lerp")]
    [SerializeField] float lerpSpeed;

    Vector3 offset;
    Vector3 velocity;

    void Start()
    {
        offset = transform.position - target.position;
    }

   
    void LateUpdate()
    {
        if(followMode == FollowMode.SmoothDamp)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref velocity, smoothTime);
        }
        else if(followMode == FollowMode.Lerp)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpSpeed * Time.deltaTime);
        }
    }
}
