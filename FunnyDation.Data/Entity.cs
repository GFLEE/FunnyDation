using FunnyDation.Service;
using System;

namespace FunnyDation.Data
{
    /// <summary>
    /// UserInfo表实体对象映射
    /// </summary>
    [Table("UserInfo")]
    public class UserInfo
    {
        [Key]
        public string Id { get; set; }
        public string User_Name { get; set; }
        public int Enable { get; set; }
    }

    [Table("FD")]
    public class FD_Entity
    {
        [Key]
        public string Id { get; set; }
        public string User_Name { get; set; }
        public int Enable { get; set; }
    }



}
