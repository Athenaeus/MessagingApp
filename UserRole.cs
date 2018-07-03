public partial class UserRole
    {
        [Key]
        public int PKID { get; set; }

        public int? UserID { get; set; }

        [StringLength(10)]
        public string ViewData { get; set; }

        [StringLength(10)]
        public string EditData { get; set; }

        [StringLength(10)]
        public string DeleteData { get; set; }

        public virtual User Users { get; set; }
    }
}
// i did not include the namespace and using statements in this file
