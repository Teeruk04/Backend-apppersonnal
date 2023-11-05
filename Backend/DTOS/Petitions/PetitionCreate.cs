namespace Backend.DTOS.Petitions
{
    public class PetitionCreate
    {
        public string peti_message { get; set; }
        public IFormFileCollection? FormFile { get; set; }
    }
}
