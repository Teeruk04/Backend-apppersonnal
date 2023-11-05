using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public  class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string User_name { get; set; }
        public string User_lastname { get; set; }
        public string User_cardnumber { get; set; }
        public DateTime User_birthdate { get; set; }
        public string User_placeofbirth { get; set; }
        public string User_race { get; set; }
        public string User_nationality { get; set; }
        public string User_religion { get; set; }   
        public string Field { get; set; }
        public DateTime Createdate { get; set; }


        public int id_title { get; set; }
        [ForeignKey("id_title")]
        public virtual Title Title { get; set; }

        public int id_statusU { get; set; }
        [ForeignKey("id_statusU")]
        public virtual StatusU StatusU { get; set; }

        public int id_sex { get; set; }
        [ForeignKey("id_sex")]
        public virtual Sex Sex { get; set; }


        public ICollection<Education> Education { get; set; } = new List<Education>();
        public ICollection<Activity> Activity { get; set; } = new List<Activity>();
        public ICollection<Workhistory> Workhistory { get; set; } = new List<Workhistory>();
        public ICollection<Arrest> Arrest { get; set;} = new List<Arrest>();
        public ICollection<FatherAndMother> FatherAndMother { get; set; } = new List<FatherAndMother>();    
        public ICollection<Marriage> Marriage { get; set; } = new List<Marriage>();
        public ICollection<Child> children { get; set; } = new List<Child>();   
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Travel> Travels { get; set; } = new List<Travel>();  
        public ICollection<Salary> Salaries { get; set; } = new List<Salary>();
        public ICollection<Managementposition> Managementpositions { get; set; } = new List<Managementposition>();
        public ICollection<Academicposition> Academicpositions { get; set;} = new List<Academicposition>();
        public ICollection<Insignia> Insignias { get; set; } = new List<Insignia>();
        public ICollection<Petition> Petitions { get; set; } = new List<Petition>();
        public ICollection<ReportLeave> ReportLeaves { get; set; } = new List<ReportLeave>();
    }
}
