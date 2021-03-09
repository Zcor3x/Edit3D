using System.IO;
using Gibbed.IO;

namespace Gibbed.Prototype.FileFormats.Pure3D
{
    [KnownType(0x00121001)]
    public class AnimationGroup : BaseNode
    {
        public uint NumberOfChannels { get; set; }
        public uint GroupId { get; set; }
		
        public override void Serialize(Stream output)
        {
            output.WriteValueU32(this.NumberOfChannels);
            output.WriteValueF32(this.GroupId);
        }

        public override void Deserialize(Stream input)
        {
            this.NumberOfChannels = input.ReadValueU32();
            this.GroupId = input.ReadValueU32();
        }
    }
}