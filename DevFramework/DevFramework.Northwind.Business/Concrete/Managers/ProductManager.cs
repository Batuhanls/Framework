using DevFramework.Core.Aspects.Postsharp;
using DevFramework.Core.Aspects.Postsharp.AuthorizationAspects;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.Aspects.Postsharp.LogAspects;
using DevFramework.Core.Aspects.Postsharp.TransactionAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DevFramework.Northwind.Business.Concrete.Managers
{

	
	public class ProductManager : IProductService
	{
		IProductDal _productDal;

		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}

		[FluentValidationAspect(typeof(ProductValidatior))]
		[CacheRemoveAspect(typeof(MemoryCacheManager))]
		public Product Add(Product product)
		{

			return _productDal.Add(product);
		}



		[CacheAspect(typeof(MemoryCacheManager))]
		//[SecuredOperation(Roles="Admin,Editor")]
		public List<Product> GetAll()
		{
			return _productDal.GetList();
		}

		public Product GetById(int id)
		{
			return _productDal.Get(p => p.ProductId == id);

		}

		[FluentValidationAspect(typeof(ProductValidatior))]
		[TransactionScopeAspect]
		public void TransactionalOperation(Product product1, Product product2)
		{
			_productDal.Add(product1);
			//Business Code
			_productDal.Update(product2);


		}
	}
}
