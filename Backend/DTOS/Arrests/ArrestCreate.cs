namespace Backend.DTOS.Arrests
{
    public class ArrestCreate
    {
        public DateTime Arrest_date { get; set; }
        public String Arrest_crimescene { get; set; }
        public String Arrest_plaint { get; set; }
        public String Arrest_outcomeofthecase { get; set; }

    }
}
