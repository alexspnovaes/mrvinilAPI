using System.Threading.Tasks;
using System.Web.Http;
using $ext_safeprojectname$.Application.ApplicationServices;
using $ext_safeprojectname$.Application.QueryServices;
using $ext_safeprojectname$.DTO.ViewModels;
using IFramework.AspNet;
using IFramework.Infrastructure;

namespace MrVinil.ApiControllers
{
    [RoutePrefix("api/training")]
    public class $ext_safeprojectname$Controller : ApiControllerBase
    {
        private $ext_safeprojectname$AppService _appService;
    private readonly $ext_safeprojectname$QueryService _queryService;

    public $ext_safeprojectname$Controller($ext_safeprojectname$AppService appService, $ext_safeprojectname$QueryService queryService)
    {
        _appService = appService;
        _queryService = queryService;
    }

    [HttpGet]
    [Route("gettraining/{trainingId}")]
    public Task<ApiResult<Training>> GetTraining(string trainingId)
    {
        return ProcessAsync(() => _queryService.GetTrainingAsync(trainingId));
    }
}
}