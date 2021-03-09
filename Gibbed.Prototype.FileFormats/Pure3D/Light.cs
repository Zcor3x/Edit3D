using System.IO;
using Gibbed.IO;


namespace Gibbed.Prototype.FileFormats.Pure3D
{
    [KnownType(0x00013000)]
    public class Light : BaseNode
    {
        public string Name { get; set; }
		public uint Version { get; set; }
        public uint Type { get; set; }
		public uint Colour { get; set; }
		public uint Constant { get; set; }
		public uint Linear { get; set; }
		public uint Squared { get; set; }
		public uint Enabled { get; set; }
		
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
            output.WriteValueU32(this.Type);
            output.WriteValueU32(this.Colour);
            output.WriteValueU32(this.Constant);
            output.WriteValueU32(this.Linear);
			output.WriteValueU32(this.Squared);
			output.WriteValueU32(this.Enabled);
        }

        public override void Deserialize(Stream input)
        {
            this.Name = input.ReadStringAlignedU8();
			this.Version = input.ReadValueU32();
            this.Type = input.ReadValueU32();
            this.Colour = input.ReadValueU32();
            this.Constant = input.ReadValueU32();
            this.Linear = input.ReadValueU32();
			this.Squared = input.ReadValueU32();
			this.Enabled = input.ReadValueU32();
        }
    }
}