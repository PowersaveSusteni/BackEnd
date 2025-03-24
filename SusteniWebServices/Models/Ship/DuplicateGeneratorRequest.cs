using Susteni.Models; // ou o namespace onde está AccountLogOnInfoItem

namespace Susteni.Models.Ship
{
    public class DuplicateGeneratorRequest
    {
        public AccountLogOnInfoItem LogonInfo { get; set; }
        public string GeneratorGuid { get; set; }
    }
}
