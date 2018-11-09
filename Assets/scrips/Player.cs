using System;
using UnityEngine;
using System.Collections;
using System.IO;
using System.IO.Compression;

public class Player : MonoBehaviour
{
    public bool Spawned = false;
    public MinecraftTcpConnection ServerConnection;
    public string Name;
    public bool OnGround;
    public float Yaw, Pitch;
    public double Stance;

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Translate(0, 0, z);
        transform.Translate(x, 0, 0);

        if (Spawned)
        {
            new PacketPlayerPosition()
            {
                onGround = OnGround,
                x = transform.position.x,
                y = transform.position.y,
                z = transform.position.z * -1,
                stance = Stance
            }.Send(ServerConnection.socketWriter);
        }
    }

    public void SetCamera(float yaw, float pitch)
    {
        this.Yaw = yaw;
        this.Pitch = pitch;
        transform.rotation = Quaternion.Euler(0, pitch, yaw);
    }
}
