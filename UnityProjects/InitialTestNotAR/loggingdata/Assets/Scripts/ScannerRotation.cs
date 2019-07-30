using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerRotation : MonoBehaviour
{
    public float scanSpeed = 1;

    float t = 0.0f;
    Quaternion targetRotation;
    Quaternion originalRotation;
    void Start()
    {
        originalRotation = transform.localRotation;
        t = 0;
        targetRotation = RandomRotation();
        StartCoroutine(NewRotation());
    }

    private void AssignNewRotation()
    {
        originalRotation = transform.localRotation;
        t = 0;
        targetRotation = RandomRotation();
    }

    private IEnumerator NewRotation()
    {
        yield return new WaitForSeconds(scanSpeed);
        AssignNewRotation();
        StartCoroutine(NewRotation());
    }

    void Update()
    {
        t = Mathf.Clamp01(t + Time.deltaTime);
        transform.localRotation = Quaternion.Slerp(originalRotation, targetRotation, t);
    }

    private Quaternion RandomRotation()
    {
        var randomRot = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        return Quaternion.Euler(randomRot);
    }
}
