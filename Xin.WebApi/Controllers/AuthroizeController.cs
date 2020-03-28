using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Xin.Repository;
using Xin.Web.Framework.Model;
using Xin.Service;
using System.Linq;
using Xin.Entities;
using Xin.Common;

namespace Xin.WebApi.Controllers
{
    /// <summary>
    /// 认证
    /// </summary>
    [Route("api/[controller]")]
    //jwt1 身份认证
    public class AuthroizeController : ControllerBase
    {
        private readonly JwtSeetings _jwtSeetings;
        private readonly IUowProvider _uowProvider;
        public AuthroizeController(IOptions<JwtSeetings> jwtSeetingsOptions, IUowProvider uowProvider)
        {
            if (jwtSeetingsOptions != null)
                _jwtSeetings = jwtSeetingsOptions.Value;
            _uowProvider = uowProvider;
        }

        /// <summary>
        /// 登录获取token
        /// </summary>
        /// <param name="loginViewModel">登录实体信息</param>
        /// <returns></returns>
        [HttpPost, AllowAnonymous]
        public async Task<ActionResult> Post([FromBody]LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ResUser>();
                var cRepository = uow.GetCustomRepository<IResUserRepository>();
                var users = (await cRepository.GetUserByUP(loginViewModel.Name, loginViewModel.Password)).ToList();


                if (users.Count > 0)
                {
                    var user = users.First();
                    var name = new Claim(ClaimTypes.Name, user.UserName);
                    var sid = new Claim(ClaimTypes.Sid, user.Id.ToString());
                    var giveName = new Claim(ClaimTypes.GivenName, user.UserCode);
                    var mobilePhone = new Claim(ClaimTypes.MobilePhone, user.Phone);
                    var dept = user.ResDepartment;
                    var groupSid = new Claim(ClaimTypes.GroupSid, dept.Id.ToString());

                    var claims = new List<Claim>();
                    claims.Add(name);
                    claims.Add(sid);
                    claims.Add(mobilePhone);
                    claims.Add(groupSid);
                    claims.Add(giveName);
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSeetings.SecretKey));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var expires = DateTime.Now.AddMinutes(1440);
                    var token = new JwtSecurityToken(
                        _jwtSeetings.Issuer,
                        _jwtSeetings.Audience,
                        claims,
                        DateTime.Now,
                        expires,
                        creds
                        );
                    return Ok(new ResponseObj<dynamic>()
                    {
                        Code = 1,
                        Message = "认证成功",
                        Data = new
                        {
                            Token = new JwtSecurityTokenHandler().WriteToken(token),
                            Expires = TypeUtil.ConvertDateTimeInt(expires)
                        }
                    });
                }

                return Ok(new ResponseObj<dynamic>()
                {
                    Code = 0,
                    Message = "用户名密码错误！"
                });
            }

        }
    }
}