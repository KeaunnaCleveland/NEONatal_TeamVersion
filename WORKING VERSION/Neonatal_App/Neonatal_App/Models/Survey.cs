namespace Neonatal_App.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Survey")]
    public partial class Survey
    {
        public int id { get; set; }

        public int client_id { get; set; }

        public int? risk_score { get; set; }

        public int? Q1_race { get; set; }

        public int? Q2_ward { get; set; }

        public int? Q3_first_child { get; set; }

        public int? Q4_prem_birth { get; set; }

        public int? Q5_obgyn { get; set; }

        public int? Q6_age { get; set; }

        public int? Q7_stress { get; set; }

        public int? Q8_smoker { get; set; }

        public int? Q9_fam_smoker { get; set; }

        public int? Q10_alcohol { get; set; }

        public int? Q11_fam_alcohol { get; set; }

        public int? Q12_fam_drug { get; set; }

        public int? Q13_drug { get; set; }

        public int? Q14_safe_nbhood { get; set; }

        public int? Q15_safe_home { get; set; }

        public int? Q16_illness { get; set; }

        public int? Q17_transport { get; set; }

        public int? Q18_internet { get; set; }

        public int? Q19_mob_internet { get; set; }

        public int? Q20_diet { get; set; }

        public int? Q21_gov_assist { get; set; }

        public int? Q22_rel_income { get; set; }

        public int? Q23_education { get; set; }

        [Column(TypeName = "date")]
        public DateTime creation_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? update_date { get; set; }

        public virtual Client Client { get; set; }
    }
}
