﻿using DevFramework.Core.DataAccess.NHiabernate;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.Nhibernate
{
	public class NhCategoryDal : NhEntityRepositoryBase<Category>, ICategoryDal
	{
		public NhCategoryDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
		{
		}
	}
}
