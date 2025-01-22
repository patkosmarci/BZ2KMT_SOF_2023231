using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BZ2KMT_SOF_2023231.Models
{
    public enum stype
    {
        Primary,
        Secondary, //középsuli
        High, //gimi

    }
    public class School
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Név")]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(0, 99999)]
        [Display(Name = "Kor")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Típus")]
        public stype Type { get; set; }

        public string ImageFileName { get; set; }   

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }

        public School()
        {

        }

        /// <summary>
        /// this constructor is only used in DbContext
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_name"></param>
        /// <param name="_type"></param>
        public School(int _id, string _name, stype _type) : this(_name, _type)
        {
            Id = _id;
            ImageFileName = "";
            //ImageContentType = "";
            //ImageData = new byte[0];
        }

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_type"></param>
        public School(string _name, stype _type)
        {
            Name = _name;
            Type = _type;
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }
    }
}
