using ProjectManagement.DataLayer.DTOs.Common;

namespace ProjectManagement.Application.Services.Interfaces
{
    public interface IMainFormService : IAsyncDisposable
    {
        Task<MainFormDto> GetMainForm();
    }
}
