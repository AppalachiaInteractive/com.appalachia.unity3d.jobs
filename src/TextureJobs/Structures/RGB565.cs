namespace Appalachia.Jobs.TextureJobs.Structures
{
    public struct RGB565
    {
        public ushort Value;

        public RGB565(byte R, byte G, byte B)
        {
            Value = (ushort) (((BIT(4, R) | BIT(3, R) | BIT(2, R) | BIT(1, R) | BIT(0,             R)) << 11) |
                              ((BIT(5, G) | BIT(4, G) | BIT(3, G) | BIT(2, G) | BIT(1, G) | BIT(0, G)) << 5) |
                              BIT(4, B) |
                              BIT(3, B) |
                              BIT(2, B) |
                              BIT(1, B) |
                              BIT(0, B));
        }

        public byte R => (byte) ((BIT(15) | BIT(14) | BIT(13) | BIT(12) | BIT(11)) >> 11);
        public byte G => (byte) ((BIT(10) | BIT(9) | BIT(8) | BIT(7) | BIT(6) | BIT(5)) >> 5);
        public byte B => (byte) (BIT(4) | BIT(3) | BIT(2) | BIT(1) | BIT(0));

        private int BIT(int index)
        {
            return (Value & (1 << index)) != 0 ? 1 << index : 0;
        }

        private static int BIT(int index, byte b)
        {
            return (b & (1 << index)) != 0 ? 1 << index : 0;
        }
    }
}
