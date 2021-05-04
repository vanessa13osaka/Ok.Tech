using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ok.Tech.Api.Controllers
{
    [ApiController]
    public class MainController: ControllerBase
    {
        private readonly List<string> _erros;

        public MainController()
        {
            _erros = new List<string>();
        }

        protected ActionResult CustomResponse(object result = null)
        {

            if (!IsOperationValid())
            {
                return BadRequest(new { sucess = false, errors = _erros, data = result });
            }

            return Ok(new { sucess = true, data = result });
        }


        protected ActionResult CustomResponse(ModelStateDictionary modelSate, object result = null)
        {

            if (!modelSate.IsValid)
            {
                var errorMessages = ModelState.Values.SelectMany(ms => ms.Errors).Select(me => me.ErrorMessage);

                _erros.AddRange(errorMessages.ToList());

                return BadRequest(new { sucess = false, errors = _erros, data = result });
            }

            return Ok(new { sucess = true, data = result });
        }


        protected bool IsOperationValid()
        {

            return !_erros.Any();
        }
    }
}
