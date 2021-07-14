namespace HW16.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("DBSession")]
    public partial class DBSession
    {
        [Key]
        public int StudentID { get; set; }

        [StringLength(50)]
        public string StudentName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? BirthOfDate { get; set; }

        [StringLength(50)]
        public string Addresses { get; set; }

        [StringLength(50)]
        public string Picture { get; set;}

    
    }
}
