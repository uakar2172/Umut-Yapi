namespace UmutYapi.Models.Tablolar
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime? GuncellemeTarihi { get; set; }
    }
}
