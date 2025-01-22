using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BZ2KMT_SOF_2023231.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        [Display(Name = "Név")]

        public string Name { get; set; }

        [Required]
        [ForeignKey("SchoolId")]
        public int SchoolId { get; set; }

        [JsonIgnore]
        [Display(Name = "Iskola")]
        public virtual School School { get; set; }

        [Required]
        [Range(6,28)]
        [Display(Name = "Kor")]
        public int Age { get; set; }

        [Range(1.00,5.00)]
        [Display(Name = "Átlag")]

        public double GradesAVG { get; set; }

        public Student()
        {

        }

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_age"></param>
        /// <param name="_school"></param>
        /// <param name="_schoolid"></param>
        /// <param name="_gradesavg"></param>
        public Student(string _name, int _age, School _school, int _schoolid, double _gradesavg)
            :this(_name, _age, _schoolid, _gradesavg)
        {
            this.School = _school;
        }

        /// <summary>
        /// this constructor is only used in DbContext
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_name"></param>
        /// <param name="_age"></param>
        /// <param name="school"></param>
        /// <param name="_schoolid"></param>
        /// <param name="_gradesavg"></param>
        public Student(int _id, string _name, int _age,  int _schoolid, double _gradesavg)
            : this(_name, _age, _schoolid, _gradesavg)
        {
            Id = _id;
        }
        
        /// <summary>
        /// Base constuctor
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_age"></param>
        /// <param name="_schoolid"></param>
        /// <param name="_gradesavg"></param>
        private Student(string _name, int _age, int _schoolid, double _gradesavg)
        {
            this.Name = _name;
            this.SchoolId = _schoolid;
            this.Age = _age;
            this.GradesAVG = _gradesavg;
        }
    }
}
