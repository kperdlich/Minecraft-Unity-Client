using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Text;

public class BinaryWriterBigEndian : BinaryWriter
{
    public BinaryWriterBigEndian(Stream output) : base(output) {}   

    public override void Write(short value)
    {
        base.Write(Reverse(BitConverter.GetBytes(value)));
    }

    public override void Write(ushort value)
    {
        base.Write(Reverse(BitConverter.GetBytes(value)));
    }

    public override void Write(int value)
    {
        base.Write(Reverse(BitConverter.GetBytes(value)));
    }

    public override void Write(uint value)
    {
        base.Write(Reverse(BitConverter.GetBytes(value)));
    }

    public override void Write(long value)
    {
        base.Write(Reverse(BitConverter.GetBytes(value)));
    }

    public override void Write(ulong value)
    {
        base.Write(Reverse(BitConverter.GetBytes(value)));
    }

    public override void Write(float value)
    {
        base.Write(Reverse(BitConverter.GetBytes(value)));
    }

    public override void Write(double value)
    {
        base.Write(Reverse(BitConverter.GetBytes(value)));
    }

    public override void Write(string value)
    {
        Write((short)value.Length);
        Write(Encoding.BigEndianUnicode.GetBytes(value));
    }

    private byte[] Reverse(byte[] bytes)
    {
        Array.Reverse(bytes);
        return bytes;
    }
}

