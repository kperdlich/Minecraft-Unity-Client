using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.IO;
using System;
using System.Threading;

public class MinecraftTcpConnection : MonoBehaviour
{
    public GameObject player;

    public static MinecraftTcpConnection Instance;

    private static readonly string serverIP = "localhost";
    private static readonly int serverPort = 25565;
    private TcpClient tcpClient = null;
    public BinaryReader socketReader = null;
    public BinaryWriter socketWriter = null;
    private PacketMap packetMap = null;
    private bool stopReading = false;

    void Start()
    {
        Instance = this;
        Connect();
    }

    public void Connect()
    {
        if (tcpClient != null)
        {
            Disconnect();
        }
        
        tcpClient = new TcpClient();
        tcpClient.Connect(serverIP, serverPort);
        packetMap = new PacketMap();

        socketReader = new BinaryReaderBigEndian(tcpClient.GetStream());
        socketWriter = new BinaryWriterBigEndian(tcpClient.GetStream());

        Debug.Log("TCP Connection established to " + serverIP + ":" + serverPort);

        new PacketHandshake(serverIP + ":" + serverPort)
            .Send(socketWriter);

        new PacketLogin().Send(socketWriter);
    }    

    private void Update()
    {
        ReadPackets();        
    }
    
    private void ReadPackets()
    {                
        var stream = tcpClient.GetStream();
        while(!stopReading && stream.CanRead && stream.DataAvailable)
        {
            var id = socketReader.ReadByte();
            var packet = packetMap.Get(id);
            if (packet == null)
            {
                stopReading = true;
                Debug.LogError("Stop reading packets! Packet not registered: 0x" + id.ToString("X"));
            }                
            else
            {
                packet.Read(socketReader).Action(socketWriter);                
            }
        }        
    }

    public void Disconnect()
    {
        if (tcpClient != null)
        {
            tcpClient.Close();
            tcpClient = null;
        }
    }
}
