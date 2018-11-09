using System;
using UnityEngine;
using System.Collections;
using System.IO;

public class PacketChunkData : Packet
{
    public static readonly byte ID = 0x33;
    private int x = 0, z = 0;
    private bool groundUpContinuous = false;
    private ushort primaryBitMap = 0, addBitMap = 0;
    private int compressedSize = 0, unusedInt = 0;
    private byte[] compressedData = null;

    public PacketChunkData() : base(ID)
    {
    }

    public override void Action(BinaryWriter writer)
    {
        var uncompressedData = Zlib.Decompress(compressedData);
        if (GetCalculatedUncompressedDataSize() != uncompressedData.Length)
            Debug.LogError("Uncompressed size != calculated size!");
        
        for (int i = 0; i < 16; ++i)
        {
            var chunk = ChunkManager.Get().GetChunk(new Vector3(x, i * 16, z));
            if ((primaryBitMap & (1 << i)) != 0)
            {
                for (int ix = 0; ix < 16; ++ix)
                {
                    for (int iy = 0; iy < 16; ++iy)
                    {
                        for (int iz = 0; iz < 16; ++iz)
                        {
                            chunk.SetBlock(ix, iy, iz, uncompressedData[GetUncompressedDataIndex(i, ix, iy, iz)]);
                        }
                    }
                }
            }
            chunk.Loaded = true;
        }
        ChunkManager.LoadedChunks++;
    }

    private static int GetUncompressedDataIndex(int section, int x, int y, int z)
    {
        return (z * 16 * 16) + (y * 16) + x + (section * 16);
    }

    public override Packet Read(BinaryReader reader)
    {
        x = reader.ReadInt32();
        z = reader.ReadInt32();
        groundUpContinuous = reader.ReadBoolean();
        primaryBitMap = reader.ReadUInt16();
        addBitMap = reader.ReadUInt16();
        compressedSize = reader.ReadInt32();
        unusedInt = reader.ReadInt32();
        compressedData = reader.ReadBytes(compressedSize);
        return base.Read(reader);
    }

    private int GetCalculatedUncompressedDataSize()
    {
        int sections = 0;
        const int sectionSize = 4096 + (3 * 2048);
        for (int i = 0; i < 16; ++i)
            sections += primaryBitMap >> i & 1;
        int size = sections * sectionSize;
        if (groundUpContinuous)
            size += 256;
        return size;
    }
}
