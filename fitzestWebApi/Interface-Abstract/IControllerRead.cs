using Microsoft.AspNetCore.Mvc;

namespace fitzestWebApi.Interface_Abstract;

public interface IControllerRead<IdType>
{
    Task<IActionResult> Get();
    Task<IActionResult> GetById(IdType id);

}