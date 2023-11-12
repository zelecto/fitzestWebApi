﻿using Microsoft.AspNetCore.Mvc;

namespace fitzestWebApi.Interface_Abstract
{
    public interface IControllerCrud<T, Tkey> : IControllerRead<Tkey> where T : class
    {
        Task<IActionResult> Post([FromBody] T entity);
        Task<IActionResult> Delete(Tkey id);
        Task<IActionResult> Put(Tkey id, T entity);
        Task<IActionResult> DeleteAll();
    }
}
