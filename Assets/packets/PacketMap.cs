using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PacketMap
{
    private Dictionary<byte, Packet> map = new Dictionary<byte, Packet>();

    public PacketMap()
    {
        map[PacketKeepAlive.ID] = new PacketKeepAlive();
        map[PacketLogin.ID] = new PacketLogin();
        map[PacketHandshake.ID] = new PacketHandshake();
        map[PacketSpawnPosition.ID] = new PacketSpawnPosition();
        map[PacketPlayerAbilities.ID] = new PacketPlayerAbilities();
        map[PacketTimeUpdate.ID] = new PacketTimeUpdate();
        map[PacketChatMessage.ID] = new PacketChatMessage();
        map[PacketChunkAllocation.ID] = new PacketChunkAllocation();
        map[PacketPlayerListItem.ID] = new PacketPlayerListItem();
        map[PacketPlayerPositionAndLook.ID] = new PacketPlayerPositionAndLook();
        map[PacketCollectItem.ID] = new PacketCollectItem();
        map[PacketSetWindowItems.ID] = new PacketSetWindowItems();
        map[PacketSetSlot.ID] = new PacketSetSlot();
        map[PacketChangeGameState.ID] = new PacketChangeGameState();
        map[PacketUpdateHealth.ID] = new PacketUpdateHealth();
        map[PacketSetExperience.ID] = new PacketSetExperience();
        map[PacketChunkData.ID] = new PacketChunkData();
        map[PacketUpdateTileEntity.ID] = new PacketUpdateTileEntity();        
    }

    public Packet Get(byte id)
    {
        Packet packet;
        if (map.TryGetValue(id, out packet))
            Debug.Log("Received Packet: 0x" + id.ToString("X"));
        return packet;
    }
}
