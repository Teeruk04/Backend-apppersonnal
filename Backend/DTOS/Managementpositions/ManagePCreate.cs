namespace Backend.DTOS.Managementpositions
{
    public class ManagePCreate
    {

        public string manageP_position { get; set; }
        public string manageP_agency { get; set; }
        public string manageP_details { get; set; }
        public DateTime manageP_startdate { get; set; }
        public DateTime? manageP_enddate { get; set; }
        public string manageP_refer {get;set;}
        public int id_statusS { get; set; }
    }
}
