using System.IO;
using Gibbed.IO;



namespace Gibbed.Prototype.FileFormats.Pure3D
{
    [KnownType(0x07010001)]
    public class CollisionVolume : BaseNode
    {
        public string Name { get; set; }
		public uint NumberofSubVolumes { get; set; }
		public uint ObjectReferenceIndex { get; set; }
		public uint OwnerIndex { get; set; }
		
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
            output.WriteValueU32(this.NumberofSubVolumes);
            output.WriteValueU32(this.ObjectReferenceIndex);
            output.WriteValueU32(this.OwnerIndex);
        }

        public override void Deserialize(Stream input)
        {
            this.Name = input.ReadStringAlignedU8();
            this.NumberofSubVolumes = input.ReadValueU32();
            this.ObjectReferenceIndex = input.ReadValueU32();
            this.OwnerIndex = input.ReadValueU32();
        }
    }
}