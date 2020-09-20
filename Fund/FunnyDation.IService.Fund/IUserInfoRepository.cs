using System;

using FunnyDation.Data;

namespace FunnyDation.IService.Fund
{
    public interface IUserInfoRepository
    {
        UserInfo ValidateUser(string strUser);

    }
}
