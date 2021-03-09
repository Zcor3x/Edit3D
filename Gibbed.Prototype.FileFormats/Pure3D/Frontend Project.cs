using Gibbed.IO;
using Gibbed.Prototype.FileFormats;
using Gibbed.Prototype.FileFormats.Pure3D;
using System;
using System.IO;


    [KnownType(0x00018000)]
    public class FrontendProject : BaseNode
{
    public string Name { get; set; }
    public uint Version { get; set; }
    public uint ResolutionX { get; set; }
    public uint ResolutionY { get; set; }
    public uint Platform { get; set; }
    public uint PagePath { get; set; }
    public uint ResourcePath { get; set; }
    public uint ScreenPath { get; set; }

    public override string ToString()
    {
        if (string.IsNullOrEmpty(this.Name) == true)
        {
            return base.ToString();
        }

        return base.ToString() + " (" + this.Name + ")";
    }

    public override void Serialize(Stream output)
    {
        output.WriteStringAlignedU8(this.Name);
        output.WriteValueU32(this.Version);
        output.WriteValueU32(this.ResolutionX);
        output.WriteValueU32(this.ResolutionY);
        output.WriteValueU32(this.Platform);
        output.WriteValueU32(this.PagePath);
        output.WriteValueU32(this.ResourcePath);
        output.WriteValueU32(this.ScreenPath);
    }

    public override void Deserialize(Stream input)
    {
        this.Name = input.ReadStringAlignedU8();
        this.Version = input.ReadValueU32();
        this.ResolutionX = input.ReadValueU32();
        this.ResolutionY = input.ReadValueU32();
        this.Platform = input.ReadValueU32();
        this.PagePath = input.ReadValueU32();
        this.ResourcePath = input.ReadValueU32();
        this.ScreenPath = input.ReadValueU32();
    }

    private static object KnownType(int v)
    {
        throw new NotImplementedException();
    }
}