using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSendingToServer : MonoBehaviour
{
    private SocketIO.SocketIOComponent socket;

    void Start()
    {
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIO.SocketIOComponent>();

        JSONObject j = new JSONObject(JSONObject.Type.OBJECT);
        j.AddField("TransformX", transform.position.x);
        j.AddField("TransformY", transform.position.y);
        j.AddField("TransformZ", transform.position.z);

        socket.Emit("PointTransform", j);
    }
}
