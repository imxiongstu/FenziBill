using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace FenziBill.AccountBooks.Dtos
{
    public class AccountBookLineGetDto : PagedAndSortedResultRequestDto
    {
        public Guid? AccountBookId { get; set; }
    }
}
