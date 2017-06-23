namespace TeduShop.Web.Models
{
    public class ProductTagViewModel
    {
        public int ProductId { get; set; }


        public string TagId { get; set; }


        public virtual ProductViewModel Product { get; set; }


        public virtual TagViewModel Tag { get; set; }
    }
}