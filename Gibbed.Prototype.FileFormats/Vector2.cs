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

using System.ComponentModel;
using System.IO;
using Gibbed.IO;

namespace Gibbed.Prototype.FileFormats
{
    [TypeConverter(typeof(VectorTypeConverter))]
    public class Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2()
        {
        }

        public Vector2(Stream input)
        {
            this.Deserialize(input);
        }

        public void Serialize(Stream output)
        {
            output.WriteValueF32(this.X);
            output.WriteValueF32(this.Y);
        }

        public void Deserialize(Stream input)
        {
            this.X = input.ReadValueF32();
            this.Y = input.ReadValueF32();
        }
    }
}
