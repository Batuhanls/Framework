using DevFramework.Core.DataAccess.NHiabernate;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using DevFramework.Northwind.Entities.ComplexTypes;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.Nhibernate
{
	public class NhProductDal : NhEntityRepositoryBase<Product>, IProductDal
	{

		private NHibernateHelper _helper;
		public NhProductDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
		{
			_helper = nHibernateHelper;
		}

		public List<ProductDetail> GetProductDetails()
		{
			using (var session=_helper.OpenSession())
			{
				var result = from p in session.Query<Product>()
							 join c in session.Query<Category>() on p.CategoryId equals c.CategoryId
							 select new ProductDetail
							 {
								 ProductId = p.ProductId,
								 CategorytName = c.CategoryName,
								 ProductName = p.ProductName
							 };
				
				return result.ToList();

			}
			


			
			


		}
	}
}
