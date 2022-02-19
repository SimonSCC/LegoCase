namespace LegoCaseLogic.Models
{
    public class VendorSource
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int PostalCode { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public bool ECOFriendly { get; set; }


        public override string ToString()
        {
            return $"{ID}. {Name} {PostalCode}";
        }
        
    }
}
