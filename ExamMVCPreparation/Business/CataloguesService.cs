using Data;
using Data.Entitites;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Services
{
    public class CataloguesService
    {
        private readonly ApplicationDbContext context;

        public CataloguesService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public List<CataloguesViewModel> GetMyCatalogues(string username)
        {
            List<Catalogue> userCatalogies = context.Catalogues.Where(x => x.User.UserName == username).ToList();
            List<CataloguesViewModel> cataloguesViewModels = new List<CataloguesViewModel>();
            foreach (var catalogue in userCatalogies)
            {
                CataloguesViewModel viewModel = new CataloguesViewModel();
                viewModel.Id = catalogue.Id;
                viewModel.Name = catalogue.Name;
                viewModel.Decription = catalogue.Decription;
                cataloguesViewModels.Add(viewModel);
            }
            return cataloguesViewModels;

        }
    }
}
