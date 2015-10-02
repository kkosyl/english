using English.Core.DTO.GET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Service.Interfaces
{
    public interface IIntroductionService
    {
        List<IntroductionDto> GetIntroductionList();
        IntroductionContentDto GetIntroduction(int id);
    }
}
