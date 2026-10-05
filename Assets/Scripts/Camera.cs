using UnityEngine;

public class Camera : MonoBehaviour
{
    Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = target.position;
        pos.z = -10;
        if(pos.y < 0)
        {
            pos.y = 0;
        }

        gameObject.transform.position = pos;
    }
}
