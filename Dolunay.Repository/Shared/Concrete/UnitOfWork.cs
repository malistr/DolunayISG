using Dolunay.Data;
using Dolunay.Models;
using Dolunay.Repository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolunay.Repository.Shared.Concrete
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;

		public IRepository<AppUser> Users { get; private set; }
		public IRepository<UserType> UserTypes { get; private set; }

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
			Users = new Repository<AppUser>(_context);
			UserTypes = new Repository<UserType>(_context);
		}

		

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
