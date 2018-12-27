using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YUVDecoder
{
    class FileInfo
    {
        public static yuvType yuv = yuvType.y420;
        public static int sizeType = 1;
        public static int height = 144;
        public static int width = 176;

        public enum yuvType
        {
            y420 = 0,
            y422 = 1,
            y444 = 2
        };
    }
    
}
