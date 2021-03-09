using System.IO;
using Gibbed.IO;



namespace Gibbed.Prototype.FileFormats.Pure3D
{
    [KnownType(0x00010010)]
    public class PackedNormalList : BaseNode
    {
		public uint IsRoot { get; set; }
		public uint Type { get; set; }

        public override void Serialize(Stream output)
        {
			output.WriteValueU32(this.IsRoot);
			output.WriteValueU32(this.Type);
        }

        public override void Deserialize(Stream input)
        {
			this.IsRoot = input.ReadValueU32();
            this.Type = input.ReadValueU32();
        }
    }
}