using Backend.Models;

namespace Backend.DTOS.Managementpositions
{
    public class ManagePResponse
    {
            static public object FromManageP(Managementposition managementposition)
        {
            return new
            {
                managementposition.Id,
                managementposition.manageP_position,
                managementposition.manageP_agency,
                managementposition.manageP_details,
                managementposition.manageP_startdate,
                managementposition.manageP_enddate,
                managementposition.manageP_refer,
                StatusSName = managementposition.Status.Name,
                managementposition.Createdate,
            };
        }
    }
}
