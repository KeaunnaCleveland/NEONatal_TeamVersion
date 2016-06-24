namespace Neonatal_App.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Surveys = new HashSet<Survey>();
        }

        public int id { get; set; }

        [Required(ErrorMessage = "first name is required")]
        [StringLength(50)]
        public string first_name { get; set; }

        [Required(ErrorMessage = "last name is required")]
        [StringLength(50)]
        public string last_name { get; set; }

        [Required(ErrorMessage = "date of birth is required")]
        [Column(TypeName = "date")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "street number is required")]
        public int street_number { get; set; }

        [Required(ErrorMessage = "street name is required")]
        [StringLength(50)]
        public string street_name { get; set; }

        [Required(ErrorMessage = "city is required")]
        [StringLength(50)]
        public string city { get; set; }

        [Required(ErrorMessage = "zip code name is required")]
        public int zip_code { get; set; }

        [Required(ErrorMessage = "county is required")]
        [StringLength(50)]
        public string county { get; set; }

        [Required(ErrorMessage = "ward number is required")]
        public int ward { get; set; }

        public long? phone { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(128)]
        public string AspNetUsers_id { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Survey> Surveys { get; set; }

    }
}
