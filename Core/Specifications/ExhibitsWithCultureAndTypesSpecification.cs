using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ExhibitsWithCultureAndTypesSpecification : BaseSpecification<Exhibits>
    {
        public ExhibitsWithCultureAndTypesSpecification(ExhibitsSpecParams exhibitParams)
            : base(x =>
                (string.IsNullOrEmpty(exhibitParams.Search) || x.Name.ToLower().Contains(exhibitParams.Search)) && 
                (!exhibitParams.CultureId.HasValue || x.ExhibitCultureId == exhibitParams.CultureId) &&
                (!exhibitParams.TypeId.HasValue  || x.ExhibitTypeId == exhibitParams.TypeId)
                  )
        {
            AddInclude(x => x.ExhibitType);
            AddInclude(x => x.ExhibitCulture);
            AddOrderBy(x => x.Name);
            ApplyPaging(exhibitParams.PageSize * (exhibitParams.PageIndex - 1), exhibitParams.PageSize); //ovo stavimo da bi mogao da nam vrati i producte sa prve strane

            if (!string.IsNullOrEmpty(exhibitParams.Sort))
            {
                switch (exhibitParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public ExhibitsWithCultureAndTypesSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ExhibitType);
            AddInclude(x => x.ExhibitCulture);
        }
    }
}
