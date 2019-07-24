
namespace ecommerce.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    //Tabla Products

    public class Product
    {
        //clave numérica autoincrementable
        public int Id { get; set; }

        
        public string Name { get; set; }

        //DisplayFormat altera el formato  moneda  currency 2
        //ApplyFormatInEditMode es para que no guarde el parámetro con el signo de pesos
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        //Ultima compra
        [Display(Name = "Last Purchase")]
        public DateTime LastPurchase { get; set; }

        //fecha
        [Display(Name = "Last Sale")]
        public DateTime LastSale { get; set; }
        
        //Está disponible? 
        [Display(Name = "Is Available?")]
        public bool IsAvailable { get; set; }

        //Bodega
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double Stock { get; set; }
    }

}
