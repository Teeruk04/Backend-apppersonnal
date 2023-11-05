using Backend.DTOS.Activities;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IActivityService
    {
        Task<IEnumerable<Activity>> FindAll();
        Task<object> FindByActivityId(int id);
        Task<object> Update(ActivityUpdate data, int id);
        Task Create(Activity activity);
        Task Delete(object activity);
    }
}
