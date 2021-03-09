using System.IO;
using Gibbed.IO;



namespace Gibbed.Prototype.FileFormats.Pure3D
{
    [KnownType(0x00002380)]
    public class LightGroup : BaseNode
    {
        public string Name { get; set; }
		
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
        }

        public override void Deserialize(Stream input)
        {
            this.Name = input.ReadStringAlignedU8();
        }
    }
}