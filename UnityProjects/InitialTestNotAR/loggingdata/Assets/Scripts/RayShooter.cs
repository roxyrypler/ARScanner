using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    public GameObject hitPoint;
    public float scanSpeed = 1;

    private void Start()
    {
        StartCoroutine(RayCasting());
    }

    private IEnumerator RayCasting()
    {
        yield return new WaitForSeconds(scanSpeed);
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //Debug.DrawRay(transform.position, fwd * 100, Color.green, 10.0f);

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green, 10.0f);
            Debug.Log("Did Hit: " + hit.point);
            Instantiate(hitPoint, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);
        }


        StartCoroutine(RayCasting());
    }
}
