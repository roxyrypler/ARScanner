using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendingEvents : MonoBehaviour
{

    public SocketIO.SocketIOComponent socket;

    
    void Start()
    {
        StartCoroutine(SayHello());
    }

    private IEnumerator SayHello()
    {
        yield return new WaitForSeconds(5);
        socket.Emit("UnityHello");
    }
}
