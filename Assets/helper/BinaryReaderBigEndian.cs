using System;
using System.Collections;
using System.IO;
using System.Text;

public class BinaryReaderBigEndian : BinaryReader
{
    public BinaryReaderBigEndian(Stream input) : base(input) {}

    public override int ReadInt32()
    {
        var data = base.ReadBytes(4);
        Array.Reverse(data);
        return BitConverter.ToInt32(data, 0);
    }

    public override Int16 ReadInt16()
    {
        var data = base.ReadBytes(2);
        Array.Reverse(data);
        return BitConverter.ToInt16(data, 0);
    }

    public override Int64 ReadInt64()
    {
        var data = base.ReadBytes(8);
        Array.Reverse(data);
        return BitConverter.ToInt64(data, 0);
    }

    public override UInt32 ReadUInt32()
    {
        var data = base.ReadBytes(4);
        Array.Reverse(data);
        return BitConverter.ToUInt32(data, 0);
    }    

    public override string ReadString()
    {
        var strLen = ReadInt16();
        var str = ReadBytes(strLen*2); // utf-16        
        return Encoding.Unicode.GetString(Encoding.Convert(Encoding.BigEndianUnicode, Encoding.Unicode, str));        
    }

    public override float ReadSingle()
    {
        var data = base.ReadBytes(4);
        Array.Reverse(data);
        return BitConverter.ToSingle(data, 0);
    }

    public override double ReadDouble()
    {
        var data = base.ReadBytes(8);
        Array.Reverse(data);
        return BitConverter.ToDouble(data, 0);
    }
}
