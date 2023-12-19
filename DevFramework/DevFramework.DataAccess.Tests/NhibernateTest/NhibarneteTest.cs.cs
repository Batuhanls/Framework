using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using DevFramework.Northwind.DataAccess.Concrete.Nhibernate;
using DevFramework.Northwind.DataAccess.Concrete.Nhibernate.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DevFramework.DataAccess.Tests.NhibernateTest
{
	[TestClass]
	public class EntityFrameworkTest
	{
		[TestMethod]
		public void Get_all_returns_products()
		{

			NhProductDal nhProductDal = new NhProductDal(new SqlServerHelper());

			var result = nhProductDal.GetList();

			Assert.AreEqual(78, result.Count);
		}


		[TestMethod]
		public void Get_all_with_paramater_returns_filtered_products()
		{

			NhProductDal nhProductDal = new NhProductDal(new SqlServerHelper());

			var result = nhProductDal.GetList(p => p.ProductName.Contains("ab"));

			Assert.AreEqual(4, result.Count);
		}

	}
}
