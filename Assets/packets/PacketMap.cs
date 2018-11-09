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
        map[PacketPlayerPosition.ID] = new PacketPlayerPosition();
        map[PacketBlockChange.ID] = new PacketBlockChange();
        map[PacketMultiBlockChange.ID] = new PacketMultiBlockChange();
        map[PacketBlockAction.ID] = new PacketBlockAction();
        map[PacketSpawnNamedEntity.ID] = new PacketSpawnNamedEntity();
        map[PacketEntityEquipment.ID] = new PacketEntityEquipment();
        map[PacketSpawnDroppedItem.ID] = new PacketSpawnDroppedItem();
        map[PacketEntityVelocity.ID] = new PacketEntityVelocity();
    }

    public Packet Get(byte id)
    {
        Packet packet;
        if (map.TryGetValue(id, out packet))
            Debug.Log("Received Packet: 0x" + id.ToString("X"));
        return packet;
    }
}
