using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace WorkWeiXinApi.Model
{

    [Table("WorkWeiXinApi_Access_Token")]
    public class WorkWeiXinApiAccessToken
    {

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Access_Token { get; set; }
        public DateTime Exprise_In { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? Create_Time { get; set; }
    }
}
