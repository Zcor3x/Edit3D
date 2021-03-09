using Gibbed.IO;
using System.IO;


namespace Gibbed.Prototype.FileFormats.Pure3D


{
    [KnownType(0x00011000)]
    public class Shader : BaseNode
    {
		public uint NumberOfParameter { get; set; }
        public string Name { get; set; }
		public uint IsRoot { get; set; }
		public uint Version { get; set; }
		public uint Pure3DDeviceDriverInterfaceShaderName { get; set; }
		public uint HasTranslucency { get; set; }
        public uint VertexNeeds { get; set; }
        public uint VertexMask { get; set; }
        public uint Type { get; set; }
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
			output.WriteValueU32(this.NumberOfParameter);
            output.WriteStringAlignedU8(this.Name);
			output.WriteValueU32(this.IsRoot);
			output.WriteValueU32(this.Version);
			output.WriteValueU32(this.Pure3DDeviceDriverInterfaceShaderName);
			output.WriteValueU32(this.HasTranslucency);
			output.WriteValueU32(this.VertexNeeds);
			output.WriteValueU32(this.VertexMask);
			output.WriteValueU32(this.Type);
        }
        public override void Deserialize(Stream input)
        {	
			this.NumberOfParameter = input.ReadValueU32();
            this.Name = input.ReadStringAlignedU8();
			this.IsRoot = input.ReadValueU32();
			this.Version = input.ReadValueU32();
			this.Pure3DDeviceDriverInterfaceShaderName = input.ReadValueU32();
			this.HasTranslucency = input.ReadValueU32();
			this.VertexNeeds = input.ReadValueU32();
			this.VertexMask = input.ReadValueU32();
			this.Type = input.ReadValueU32();
        }
    }
}