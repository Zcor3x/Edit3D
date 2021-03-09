using System.IO;
using Gibbed.IO;



namespace Gibbed.Prototype.FileFormats.Pure3D
{
    [KnownType(0x0018001)]
    public class FrontendScreen : BaseNode
    {
        public string Name { get; set; }
		public uint Version { get; set; }
		
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
        }

        public override void Deserialize(Stream input)
        {
            this.Name = input.ReadStringAlignedU8();
			this.Version = input.ReadValueU32();
        }
    }
}