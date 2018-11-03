using System;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class PacketHandshake : Packet
{
    public static readonly byte ID = 0x02;
    public string UsernameHost;

    public PacketHandshake() : base(ID) {}

    public PacketHandshake(String usernameHost) : base(ID)
    {   
        UsernameHost = usernameHost;
    }    

    public override Packet Send(BinaryWriter writer)
    {
        base.Send(writer);       
        writer.Write(UsernameHost);
        return this;
    }

    public override Packet Read(BinaryReader reader)
    {        
        var hash = reader.ReadString();
        Debug.Log("Got connection hash: " + hash);              
        return this;
    }   
}
