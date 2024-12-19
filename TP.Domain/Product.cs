namespace TP.Domain
{
    public class Product:BaseDomainEntity
    {
        public string Name { get; set; }
        public DateTime ProduceDate { get; set; }
        public string ManufacturePhone { get; set; }
        public string ManufactureEmail { get; set; }
        public bool IsAvailable { get; set; }

        #region Relation

        public ApplicationUser ApplicationUser { get; set; }

        #endregion
    }
}
