using System.IO;
using Gibbed.IO;

namespace Gibbed.Prototype.FileFormats.Pure3D
{
    [KnownType(0x00010020)]
    // ReSharper disable InconsistentNaming
    public class PrimitiveGroup : BaseNode
        // ReSharper restore InconsistentNaming
    {
        public uint Version { get; set; }
        public string ShaderName { get; set; }
        public uint PrimitiveType { get; set; }
        public uint VertexType { get; set; }
        public uint NumVertices { get; set; }
        public uint NumIndices { get; set; }
        public uint NumMatrices { get; set; } // skeleton bones / blendindices
        public uint MemoryImaged { get; set; }
        public uint Optimized { get; set; }
        public uint VertexAnimated { get; set; }
        public uint VertexAnimationMask { get; set; }

        public override void Serialize(Stream output)
        {
            output.WriteValueU32(this.Version);
            output.WriteStringAlignedU8(this.ShaderName);
            output.WriteValueU32(this.PrimitiveType);
            output.WriteValueU32(this.VertexType);
            output.WriteValueU32(this.NumVertices);
            output.WriteValueU32(this.NumIndices);
            output.WriteValueU32(this.NumMatrices);
            output.WriteValueU32(this.MemoryImaged);
            output.WriteValueU32(this.Optimized);
            output.WriteValueU32(this.VertexAnimated);
            output.WriteValueU32(this.VertexAnimationMask);
        }

        public override void Deserialize(Stream input)
        {
            this.Version = input.ReadValueU32();
            this.ShaderName = input.ReadStringAlignedU8();
            this.PrimitiveType = input.ReadValueU32();
            this.VertexType = input.ReadValueU32();
            this.NumVertices = input.ReadValueU32();
            this.NumIndices = input.ReadValueU32();
            this.NumMatrices = input.ReadValueU32();
            this.MemoryImaged = input.ReadValueU32();
            this.Optimized = input.ReadValueU32();
            this.VertexAnimated = input.ReadValueU32();
            this.VertexAnimationMask = input.ReadValueU32();
        }
    }
}
