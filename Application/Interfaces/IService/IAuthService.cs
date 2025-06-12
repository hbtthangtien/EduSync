using Application.DTOs.Commons;
using Application.DTOs.Login;
using Application.DTOs.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IService
{
    public interface IAuthService
    {
        Task<BaseResponse<string>> LoginAsync(LoginDTO loginDto);
        Task<BaseResponse<object>> RegisterAsync(RegisterDTO registerDto);
    }
}
