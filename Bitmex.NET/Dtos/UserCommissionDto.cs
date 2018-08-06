namespace Bitmex.NET.Dtos
{
    public class UserCommissionDto
    {
        public double? MakerFee { get; set; }
        public double? TakerFee { get; set; }
        public double? SettlementFee { get; set; }
        public double? MaxFee { get; set; }

    }
}
