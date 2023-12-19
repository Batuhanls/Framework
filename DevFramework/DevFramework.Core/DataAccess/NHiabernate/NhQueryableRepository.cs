using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.NHiabernate
{
	public class NhQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
	{
		private IQueryable<T> _entities;
		private NHibernateHelper _nHibernateHelper;

		public NhQueryableRepository(NHibernateHelper nHibernateHelper)
		{
			_nHibernateHelper = nHibernateHelper;
		}

		public IQueryable<T> Table => this.Entities;
		public virtual IQueryable<T> Entities
		{
			get
			{
				if (_entities == null)

				{
					_entities = _nHibernateHelper.OpenSession().Query<T>();
				}
				return _entities;
			}
		}
	}
}
