using UnityEngine;
using System.Collections;
using System.IO;

public abstract class Packet {

    protected byte id = 0;

    protected Packet(byte id)
    {
        this.id = id;
    }

    public virtual Packet Send(BinaryWriter writer)
    {
        Debug.Log("Send Packet: 0x" + id.ToString("X"));
        writer.Write(id);      
        return this;
    }

    public virtual Packet Read(BinaryReader reader)
    {             
        return this;
    }    

    public virtual void Action(BinaryWriter writer)
    {

    }
}
