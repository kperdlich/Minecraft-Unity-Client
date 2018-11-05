using UnityEngine;
using System.Collections;
using System.IO;
using Ionic.Zlib;

public static class Zlib
{
    public static byte[] Decompress(byte[] data)
    {
       return ZlibStream.UncompressBuffer(data);
    }

    public static byte[] Compress(byte[] data)
    {
        return ZlibStream.CompressBuffer(data);
    }
}
