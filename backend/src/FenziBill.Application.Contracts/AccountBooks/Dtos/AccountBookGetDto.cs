using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace FenziBill.AccountBooks.Dtos
{
    public class AccountBookGetDto : PagedResultRequestDto
    {
        public Guid? AccountBookId { get; set; }
    }
}
