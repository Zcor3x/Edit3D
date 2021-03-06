/* Copyright (c) 2012 Rick (rick 'at' gibbed 'dot' us)
 * 
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 * 
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 * 
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using System;
using System.IO;
using Gibbed.IO;

namespace Gibbed.Prototype.FileFormats.Pure3D
{
    [KnownType(0x0001100B)]
    public class ShaderProgram : BaseNode
    {
        public enum ShaderProgramType : uint
        {
            VertexShader = 0,
            PixelShader = 1
        }

        public string Name { get; set; }
        public uint Unknown02 { get; set; }
        public ShaderProgramType ShaderType { get; set; }
        public uint ChildCount2 { get; set; }

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
            output.WriteValueU32(this.Unknown02);
            output.WriteValueU32((UInt32)this.ShaderType);
            output.WriteValueU32(this.ChildCount2);
        }

        public override void Deserialize(Stream input)
        {
            this.Name = input.ReadStringAlignedU8();
            this.Unknown02 = input.ReadValueU32();
            this.ShaderType = (ShaderProgramType)input.ReadValueU32();
            this.ChildCount2 = input.ReadValueU32();
        }
    }
}
