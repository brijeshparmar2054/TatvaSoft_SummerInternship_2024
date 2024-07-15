using Business_logic_Layer;
using Data_Access_Layer.Repository.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly BALLogin _balLogin;
        ResponseResult result = new ResponseResult();
        public LoginController(BALLogin balLogin)
        {
            _balLogin = balLogin;
        }


        [HttpPost]
        [Route("LoginUser")]
        public ResponseResult LoginUser(LoginRequest loginRequest)
        {
            try
            {
                result.Data = _balLogin.LoginUser(loginRequest);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("Register")]
        public ResponseResult RegisterUser(User user)
        {
            try
            {
                result.Data = _balLogin.Register(user);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        //[HttpGet]
        //[Route("GetUserById/{id}")]
        //public async Task<IActionResult> GetUserById(int id)
        //{
        //    try
        //    {
        //        var user = await _balLogin.GetUserByIdAsync(id);
        //        if (user == null)
        //        {
        //            return NotFound(new ResponseResult { Result = ResponseStatus.Error, Message = "User not found" });
        //        }
        //        return Ok(new ResponseResult { Data = user, Result = ResponseStatus.Success });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
        //    }
        //}
        [HttpGet]
        [Route("GetUserById/{id}")]
        public async Task<ActionResult<ResponseResult>> GetUserById(int id)
        {
            try
            {
                result.Data = await _balLogin.GetUserByIdAsync(id);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpPost]
        [Route("UpdateUser")]
        public async Task<ActionResult<ResponseResult>> UpdateUser(User user)
        {
            try
            {
                result.Data = await _balLogin.UpdateUserAsync(user);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
