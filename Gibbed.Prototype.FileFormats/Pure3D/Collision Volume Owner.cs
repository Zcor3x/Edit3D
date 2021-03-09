using Gibbed.IO;
using System.IO;

namespace Gibbed.Prototype.FileFormats.Pure3D
{
    [KnownType(0x07010021)]
    public class CollisionVolumeOwner : BaseNode
    {
		public uint NumberOfNames { get; set; }

        public override void Serialize(Stream output)
        {
			output.WriteValueU32(this.NumberOfNames);
        }

        public override void Deserialize(Stream input)
        {
			this.NumberOfNames = input.ReadValueU32();
        }
    }
}