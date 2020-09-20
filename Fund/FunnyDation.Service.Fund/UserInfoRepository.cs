using FunnyDation.Dapper;
using FunnyDation.Data;
using FunnyDation.IService.Fund;
using System;
using System.Linq;

namespace FunnyDation.Service.Fund
{
    public class UserInfoRepository : BaseRepository<UserInfo>, IUserInfoRepository
    {
        public UserInfo ValidateUser(string strUser)
        {
            UserInfo user = new UserInfo();
            try
            {
                  
                DynamicParameters Parameters = new DynamicParameters();
                string strQuery = "WHERE User_Name=@Name";
                Parameters.Add("Name", strUser);
                var res = this.GetModelList(strQuery, Parameters).First();
                return res;
            }
            catch
            {
                return user;
            }



        }
    }
}
