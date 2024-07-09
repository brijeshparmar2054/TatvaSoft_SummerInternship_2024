using Authentication.Entities;
using Authentication.Model;

namespace Authentication.Repository
{
    public interface IMission
    {
        Task<List<MissionViewModel>> GetMissionsWithDetails();
        Task<string> CreateMission(MissionDto model);
        Task<MissionViewModel> GetMissionDetailsById(int missionId);

        Task<string> DeleteMission(int id);
        Task<string> UpdateMission(int id, MissionDto model);
    }
}
