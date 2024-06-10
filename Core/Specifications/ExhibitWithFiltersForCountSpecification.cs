using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ExhibitWithFiltersForCountSpecification : BaseSpecification<Exhibits>
    {
        public ExhibitWithFiltersForCountSpecification(ExhibitsSpecParams exhibitParams)
           : base(x =>
               (string.IsNullOrEmpty(exhibitParams.Search) || x.Name.ToLower().Contains(exhibitParams.Search)) &&
               (!exhibitParams.CultureId.HasValue || x.ExhibitCultureId == exhibitParams.TypeId) &&
               (!exhibitParams.TypeId.HasValue || x.ExhibitTypeId == exhibitParams.TypeId)
                 )
        {

        }
    }
}
