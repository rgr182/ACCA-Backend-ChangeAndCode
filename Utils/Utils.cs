using ACCA_Backend.Utils.Interfaces;

namespace ACCA_Backend.Utils
{
    public class Utils : IUtils
    {
        public Guid GenerateToken() => Guid.NewGuid();
        public String GenerateTokenString()=>Guid.NewGuid().ToString();
    }
}
