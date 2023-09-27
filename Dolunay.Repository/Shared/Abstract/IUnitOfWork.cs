using Dolunay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolunay.Repository.Shared.Abstract
{
	public interface IUnitOfWork
	{
		IRepository<AppUser> Users { get; }
		IRepository<UserType> UserTypes { get; }
		void Save();

	}
}
