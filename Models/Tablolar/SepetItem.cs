namespace UmutYapi.Models.Tablolar
{
    public class SepetItem : Entity
    {
        public int UrunId { get; set; }
        public int SatınAlınacakAdet {  get; set; }
        public int SepetId { get; set; }     
        public virtual Sepet Sepet { get; set; }
    }
}
