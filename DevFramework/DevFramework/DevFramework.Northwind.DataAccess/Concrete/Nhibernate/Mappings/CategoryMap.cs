using DevFramework.Northwind.Entities.Concrete;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.Nhibernate.Mappings
{
	public class CategoryMap : ClassMap<Category>
	{
		public CategoryMap()
		{
			Table(@"Category");
			LazyLoad();
		
			
			Map(x => x.CategoryId).Column("CategoryID");
			Map(x => x.CategoryName).Column("CategoryName");
		




		}

	}
}
