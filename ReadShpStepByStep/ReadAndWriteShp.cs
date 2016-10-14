using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ReadShpStepByStep
{
    class ReadAndWriteShp
    {
        public static Int32 ReadShp_Big(BinaryReader binaryReader,byte[] bytes) {
            Int32 Number;
            bytes = binaryReader.ReadBytes(4);
            Array.Reverse(bytes);
            Number = BitConverter.ToInt32(bytes, 0);
            return Number;
        }
       // public static 
    }
}
