using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Text;

public class PacketLogin : Packet
{
    public static readonly byte ID = 0x01;
    private int entityID = 0;
    private int serverMode = 0;
    private int dimension = 0;
    private byte difficulty = 0;
    private string levelType = string.Empty;
    private byte maxPlayers = 0; 

    public PacketLogin() : base(ID) {}    

    public override Packet Read(BinaryReader reader)
    {        
        entityID = reader.ReadInt32();
        reader.ReadInt16(); // unused
        levelType = reader.ReadString();
        dimension = reader.ReadInt32();
        difficulty = reader.ReadByte();
        maxPlayers = reader.ReadByte();

        Debug.Log("Logged in with entity id: " + entityID + " server mode: " + serverMode + " level type: " + levelType);

        return this;
    }

    public override Packet Send(BinaryWriter writer)
    {
        base.Send(writer);
        writer.Write(29);
        writer.Write("Unity");
        for (int i = 0; i < 13; ++i)
            writer.Write((byte)0x0);       

        return this;
    }    
}
