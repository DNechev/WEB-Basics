using Panda.Data;
using Panda.Data.Models;
using Panda.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.Services
{
    public class PackagesService : IPackagesService
    {
        private readonly PandaDbContext db;
        private readonly IReceiptsService receiptsService;

        public PackagesService(PandaDbContext db, IReceiptsService receiptsService)
        {
            this.db = db;
            this.receiptsService = receiptsService;
        }
        public void Create(string description, decimal weight, string shippingAddress, string recepientName)
        {
            string recepientId = this.db.Users.Where(u => u.Username == recepientName).Select(u => u.Id).FirstOrDefault();

            if(recepientId == null)
            {
                return;
            }

            Package package = new Package
            {
                Description = description,
                Weight = weight,
                ShippingAddress = shippingAddress,
                Status = PackageStatus.Pending,
                RecipientId = recepientId
            };

            this.db.Packages.Add(package);
            this.db.SaveChanges();
        }

        public void Deliver(string id)
        {
            var package = this.db.Packages.FirstOrDefault(p => p.Id == id);

            if(package == null)
            {
                return;
            }

            package.Status = PackageStatus.Delivered;
            db.SaveChanges();

            this.receiptsService.CreateFromPackage(package.Weight, package.Id, package.RecipientId);            
        }

        public IQueryable<Package> GetAllPackagesByStatus(PackageStatus packageStatus)
        {
            var packages = this.db.Packages.Where(p => p.Status == packageStatus);

            return packages;
        }
    }
}
